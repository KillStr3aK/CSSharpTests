namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Plugin;
    using CounterStrikeSharp.API.Modules.Memory.DynamicFunctions;

    using Microsoft.Extensions.Logging;

    public class ExperimentalTests : IBaseTest
    {
        private readonly ILogger<ExperimentalTests> Logger;

        private readonly PluginContext PluginContext;

        // currently the marshaling system is wrong(?) and we cannot pass 'CEntityInstance' & 'CTakeDamageInfo' even tho it is defined with those types.
        // so as a workaround we redefine these methods to use 'nint' as types so we can call it without any issues.
        private static MemoryFunctionVoid<nint, nint> CBaseEntity_TakeDamageOldFunc = new(GameData.GetSignature("CBaseEntity_TakeDamageOld"));
        private static Action<nint, nint> CBaseEntity_TakeDamageOld = CBaseEntity_TakeDamageOldFunc.Invoke;

        public ExperimentalTests(ILogger<ExperimentalTests> logger, PluginContext pluginContext)
        {
            this.Logger = logger;
            this.PluginContext = pluginContext;
        }

        public void Initialize(bool hotReload)
        {
            this.Logger.LogInformation("Initializing '{0}'", this.GetType().Name);

            Plugin plugin = (this.PluginContext.Plugin as Plugin)!;

            plugin.AddCommand("css_damage", "Deal damage", (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                // Size of CTakeDamageInfo = 0x98 (https://github.com/neverlosecc/source2sdk/blob/cs2/sdk/server.hpp#L6766)
                using (NativeClass<CTakeDamageInfo> damageInfo = new NativeClass<CTakeDamageInfo>(0x98))
                {
                    damageInfo.Value.Damage = 50.0f;
                    damageInfo.Value.BitsDamageType = (int)DamageTypes_t.DMG_HEADSHOT; // headshot should kill the entity regardless of damage
                    damageInfo.Value.Attacker.Raw = player.PlayerPawn.Raw; // with inflictor but no attacker it dealt 25 damage? haha
                    damageInfo.Value.Inflictor.Raw = player.PlayerPawn.Raw;
                    CBaseEntity_TakeDamageOld(player.PlayerPawn.Value.Handle, damageInfo);
                }
            });
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}
