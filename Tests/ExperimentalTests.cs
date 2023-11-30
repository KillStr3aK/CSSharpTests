﻿namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Plugin;
    using CounterStrikeSharp.API.Modules.Commands;
    using CounterStrikeSharp.API.Modules.Memory;
    using CounterStrikeSharp.API.Modules.Utils;

    using Microsoft.Extensions.Logging;

    public class ExperimentalTests : IBaseTest
    {
        private readonly ILogger<ExperimentalTests> Logger;

        private readonly PluginContext PluginContext;

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
                if (player == null || !player.IsValid || player.PlayerPawn.Value == null)
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
                    VirtualFunctions.CBaseEntity_TakeDamageOld(player.PlayerPawn.Value, damageInfo);
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

                CHandle<CBaseViewModel> viewModel = GetPlayerViewModels(player)[0];

                if (viewModel.IsValid && viewModel.Value != null)
                {
                    this.Logger.LogInformation("{0}", viewModel.Value.VMName);
                }
            });
        }

        private unsafe CHandle<CBaseViewModel>[] GetPlayerViewModels(CCSPlayerController player)
        {
            CCSPlayer_ViewModelServices viewModelServices = new CCSPlayer_ViewModelServices(player.PlayerPawn.Value.ViewModelServices!.Handle);
            return ESchema.GetFixedArray<CHandle<CBaseViewModel>>(viewModelServices.Handle, "CCSPlayer_ViewModelServices", "m_hViewModel", 3);
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}