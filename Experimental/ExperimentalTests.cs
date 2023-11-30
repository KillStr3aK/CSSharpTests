﻿namespace CSSharpTests.Experimental
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

            // !ui "panorama/layout/base_mainmenu.vxml_c" care your ears
            plugin.AddCommand("css_ui", "Display UI", (player, info) =>
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
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}
