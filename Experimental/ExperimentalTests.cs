namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Plugin;
    using CounterStrikeSharp.API.Modules.Memory;
    using CounterStrikeSharp.API.Modules.Memory.DynamicFunctions;

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

            plugin.AddCommand("css_damage", "Deal damage", (player, info) =>
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

            VirtualFunctions.CBaseEntity_TakeDamageOldFunc.Hook(OnTakeDamage, HookMode.Pre);
        }

        private HookResult OnTakeDamage(DynamicHook hook)
        {
            CTakeDamageInfo info = hook.GetParam<CTakeDamageInfo>(1);
            this.Logger.LogInformation("{0} {1}", info.Attacker.Value.Handle, info.Inflictor.Value.Handle);
            return HookResult.Continue;
        }

        public void Release(bool hotReload)
        {
            VirtualFunctions.CBaseEntity_TakeDamageOldFunc.Unhook(OnTakeDamage, HookMode.Pre);
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}
