namespace CSSharpTests
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Plugin;
    using CounterStrikeSharp.API.Modules.Commands;

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

            plugin.AddCommand("css_html", "Display html text",
                [CommandHelper(1, "<html>", whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
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

            plugin.AddCommand("css_r", "Respawn player",
                [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                player.Respawn();
            });

            plugin.AddCommand("css_model", "Respawn player",
                [CommandHelper(1, "<model>", whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                if (player.Pawn == null || !player.Pawn.IsValid)
                    return;

                if (player.Pawn.Value == null || !player.Pawn.Value.IsValid)
                    return;

                player.Pawn.Value.SetModel(info.GetArg(1));
            });

            plugin.AddCommand(name: "css_chicken", "Spawns a big ass chicken",
                [CommandHelper(0, whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                CChicken? chicken = Utilities.CreateEntityByName<CChicken>("chicken");

                // maybe do more sanity checks?
                if (chicken != null)
                {
                    chicken.Teleport(player.PlayerPawn.Value!.AbsOrigin!, player.PlayerPawn.Value.AbsRotation!, player.PlayerPawn.Value.AbsVelocity);
                    chicken.DispatchSpawn();

                    // random stuff after DispatchSpawn
                    if (chicken.CBodyComponent == null || chicken.CBodyComponent.SceneNode == null)
                        return;

                    chicken.CBodyComponent.SceneNode.Scale = 5.0f;
                }
            });
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}
