namespace CSSharpTests
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Plugin;

    using Microsoft.Extensions.Logging;

    public class BasicTests : IBaseTest
    {
        private readonly ILogger<BasicTests> Logger;

        private readonly PluginContext PluginContext;

        public BasicTests(ILogger<BasicTests> logger, PluginContext pluginContext)
        {
            this.Logger = logger;
            this.PluginContext = pluginContext;
        }

        public void Initialize(bool hotReload)
        {
            this.Logger.LogInformation("Initializing '{0}'", this.GetType().Name);

            Plugin plugin = (this.PluginContext.Plugin as Plugin)!;

            plugin.AddCommand("css_html", "Display html text", (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                var @event = new EventShowSurvivalRespawnStatus(true)
                {
                    LocToken = info.GetArg(1),
                    Duration = 10,
                    Userid = player
                };

                @event.FireEventToClient(player);
            });

            plugin.RegisterEventHandler<EventPlayerJump>((EventPlayerJump @event, GameEventInfo info) =>
            {
                CCSPlayerController player = @event.Userid;

                if (player is null || !player.IsValid || !player.PlayerPawn.IsValid)
                    return HookResult.Continue;

                CChicken? chicken = Utilities.CreateEntityByName<CChicken>("chicken");

                // maybe do more sanity checks?
                if (chicken != null)
                {
                    chicken.Teleport(player.PlayerPawn.Value!.AbsOrigin!, player.PlayerPawn.Value.AbsRotation!, player.PlayerPawn.Value.AbsVelocity);
                    chicken.DispatchSpawn();

                    // random stuff after DispatchSpawn
                    if (chicken.CBodyComponent == null || chicken.CBodyComponent.SceneNode == null)
                        return HookResult.Continue;

                    chicken.CBodyComponent.SceneNode.Scale = 5.0f;
                    chicken.CBodyComponent.SceneNode.GetSkeletonInstance().ModelState.MeshGroupMask = 2;
                }

                return HookResult.Continue;
            });
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}
