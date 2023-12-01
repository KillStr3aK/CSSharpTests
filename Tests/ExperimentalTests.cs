namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Plugin;
    using CounterStrikeSharp.API.Modules.Commands;
    using CounterStrikeSharp.API.Modules.Memory;
    using CounterStrikeSharp.API.Modules.Memory.DynamicFunctions;
    using CounterStrikeSharp.API.Modules.Utils;

    public unsafe class ExperimentalTests : IBaseTest
    {
        private readonly ILogger<ExperimentalTests> Logger;

        private readonly PluginContext PluginContext;

        public required MemoryFunctionWithReturn<nint, string, nint> CEconItemSchema_GetAttributeDefinitionByName;

        // this is null on hotreload unless something triggers the capturing function so imma mark it nullable
        public required CEconItemSchema? EconItemSchema;

        public ExperimentalTests(ILogger<ExperimentalTests> logger, PluginContext pluginContext)
        {
            this.Logger = logger;
            this.PluginContext = pluginContext;
        }

        public void Initialize(bool hotReload)
        {
            this.Logger.LogInformation(message: "Initializing '{0}'", this.GetType().Name);

            Plugin plugin = (this.PluginContext.Plugin as Plugin)!;

            plugin.AddCommand("css_damage", "Deal damage",
                [CommandHelper(0, whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid || player.Pawn.Value == null)
                    return;

                CWorld? world = Utilities.FindAllEntitiesByDesignerName<CWorld>("world").FirstOrDefault();

                if (world == null || !world.IsValid)
                    return;

                // Size of CTakeDamageInfo = 0x98 (https://github.com/neverlosecc/source2sdk/blob/cs2/sdk/server.hpp#L6766)
                using (NativeClass<CTakeDamageInfo> damageInfo = new NativeClass<CTakeDamageInfo>())
                {
                    damageInfo.Value.Damage = 50.0f;
                    damageInfo.Value.BitsDamageType = (int)DamageTypes_t.DMG_FALL;
                    damageInfo.Value.Inflictor.Raw = world.EntityHandle.Raw;
                    VirtualFunctions.CBaseEntity_TakeDamageOld(player.Pawn.Value, damageInfo);
                }
            });

            // !ui "panorama/layout/base_mainmenu.vxml_c" care your ears
            plugin.AddCommand("css_ui", "Display UI",
                [CommandHelper(1, "<dialog>", CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                CPointClientUIWorldPanel? panel = Utilities.CreateEntityByName<CPointClientUIWorldPanel>("point_clientui_world_panel");

                if (panel != null)
                {
                    panel.DialogXMLName = "s2r://" + info.GetArg(1);
                    panel.Width = 320;
                    panel.Health = 180;
                    panel.DPI = 3;
                    panel.Lit = false;

                    panel.Teleport(player.AbsOrigin!, player.AbsRotation!, player.AbsVelocity);
                    panel.DispatchSpawn();
                }
            });

            // name is automatically updated in the chat, but not in the scoreboard (it requires a change in the score or any network update) currently.
            plugin.AddCommand("css_rename", "Rename player", 
                [CommandHelper(1, "<name>", CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                SchemaString<CBasePlayerController> playerName = new SchemaString<CBasePlayerController>(player, "m_iszPlayerName");
                playerName.Set(info.ArgByIndex(1));
            });

            plugin.AddCommand("css_vm", "Rename player",
                [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                if (player.Pawn == null || !player.Pawn.IsValid)
                    return;

                if (player.Pawn.Value == null || !player.Pawn.Value.IsValid)
                    return;

                CHandle<CBaseViewModel>[]? viewModels = GetPlayerViewModels(player);

                if (viewModels == null)
                    return;

                CHandle<CBaseViewModel>? viewModel = viewModels[0];

                if (viewModel != null && viewModel.IsValid && viewModel.Value != null && viewModel.IsValid)
                {
                    this.Logger.LogInformation("{0}", viewModel.Value.VMName);
                }
            });

            plugin.AddCommand("css_econ", "Get econ item system pointer",
                [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                CEconItemSystem econItemSystem = new CEconItemSystem(NativeAPI.GetEconItemSystem()); // segfault
                CEconItemSchema econItemSchema = econItemSystem.GetEconItemSchema();

                this.Logger.LogInformation("{0} {1}", econItemSystem.Handle, econItemSchema.Handle);
            });

            // this currently only applies on the next spawn as we have no networkstatechanged implemented yet
            plugin.AddCommand("css_resize", "Resize player",
                [CommandHelper(1, "<size>", whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                if (player.Pawn == null || !player.Pawn.IsValid)
                    return;

                if (player.Pawn.Value == null || !player.Pawn.Value.IsValid)
                    return;

                if (player.Pawn.Value.CBodyComponent == null || player.Pawn.Value.CBodyComponent.SceneNode == null)
                    return;

                if (!float.TryParse(info.GetArg(1), out float result))
                {
                    info.ReplyToCommand("Invalid argument");
                    return;
                }

                // this is totally unneeded haha, we have SceneNode.GetSkeletonInstance() already, just testing the vfunc wrapper class
                VirtualFunctionWithReturn<nint, nint> getSkeletonInstance = new VirtualFunctionWithReturn<nint, nint>(player.Pawn.Value.CBodyComponent.SceneNode.Handle, GameData.GetOffset("CGameSceneNode_GetSkeletonInstance"));
                CSkeletonInstance skeletonInstance = new CSkeletonInstance(getSkeletonInstance.Invoke(player.Pawn.Value.CBodyComponent.SceneNode.Handle));

                if (skeletonInstance == null)
                {
                    this.Logger.LogInformation("CSkeletonInstance is null");
                    return;
                } else
                {
                    this.Logger.LogInformation("CSkeletonInstance is: {0}", $"{skeletonInstance.Handle.ToHexStr()}");
                }

                // changing player size
                skeletonInstance.Scale = result;
            });

            this.CEconItemSchema_GetAttributeDefinitionByName = new(plugin.Config.GetAttributeDefinitionByNameSignature.Get());
            this.CEconItemSchema_GetAttributeDefinitionByName.Hook(GetAttributeDefinitionByNamePre, HookMode.Pre);
        }

        private HookResult GetAttributeDefinitionByNamePre(DynamicHook h)
        {
            nint instancePtr = h.GetParam<nint>(0);

            if (this.EconItemSchema == null)
            {
                this.EconItemSchema = new CEconItemSchema(instancePtr);
                this.Logger.LogInformation("Captured {CEconItemSchema}: {1}", "CEconItemSchema", instancePtr.ToHexStr());
            }

            return HookResult.Continue;
        }

        // assume that the player has a valid pawn
        private unsafe CHandle<CBaseViewModel>[]? GetPlayerViewModels(CCSPlayerController player)
        {
            CCSPlayerPawn pawn = player.Pawn.Value!.As<CCSPlayerPawn>();

            if (pawn.ViewModelServices == null || pawn.ViewModelServices.Handle == IntPtr.Zero)
                return null;

            CCSPlayer_ViewModelServices viewModelServices = new CCSPlayer_ViewModelServices(pawn.ViewModelServices.Handle);
            return ESchema.GetFixedArray<CHandle<CBaseViewModel>>(viewModelServices.Handle, "CCSPlayer_ViewModelServices", "m_hViewModel", 3);
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
            this.CEconItemSchema_GetAttributeDefinitionByName.Unhook(GetAttributeDefinitionByNamePre, HookMode.Pre);
        }
    }
}
