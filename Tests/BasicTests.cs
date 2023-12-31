﻿namespace CSSharpTests
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Plugin;
    using CounterStrikeSharp.API.Modules.Commands;
    using CounterStrikeSharp.API.Modules.Entities.Constants;

    public class BasicTests : IBaseTest
    {
        private readonly ILogger<BasicTests> Logger;

        private readonly PluginContext PluginContext;

        // CCSGameRules does not derive from CEntityInstance
        private readonly CEntityCache<CCSGameRulesProxy> GameRulesProxy = new CEntityCache<CCSGameRulesProxy>(() =>
        {
            return Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules").First();
        });

        public BasicTests(ILogger<BasicTests> logger, IPluginContext pluginContext)
        {
            this.Logger = logger;
            this.PluginContext = (pluginContext as PluginContext)!;
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
                if (player == null || !player.IsValid || player.Pawn == null || !player.Pawn.IsValid)
                    return;

                CChicken? chicken = Utilities.CreateEntityByName<CChicken>("chicken");

                // maybe do more sanity checks?
                if (chicken != null)
                {
                    chicken.Teleport(player.Pawn.Value!.AbsOrigin!, player.Pawn.Value.AbsRotation!, player.Pawn.Value.AbsVelocity);
                    chicken.DispatchSpawn();

                    // random stuff after DispatchSpawn
                    if (chicken.CBodyComponent == null || chicken.CBodyComponent.SceneNode == null)
                        return;

                    chicken.CBodyComponent.SceneNode.Scale = 5.0f;
                }
            });

            plugin.AddCommand("css_endround", "Terminate round with a reason",
                [CommandHelper(2, "<delay> <reason>", whoCanExecute: CommandUsage.CLIENT_ONLY)] (player, info) =>
            {
                if (player == null || !player.IsValid)
                    return;

                if (!float.TryParse(info.GetArg(1), out float delay))
                {
                    info.ReplyToCommand("Invalid argument");
                    return;
                }

                if (!int.TryParse(info.GetArg(2), out int roundEndReason))
                {
                    info.ReplyToCommand("Invalid argument");
                    return;
                }

                CCSGameRules? gameRules = this.GameRulesProxy.Value?.GameRules;

                if (gameRules != null)
                {
                    gameRules.TerminateRound(delay, (RoundEndReason)roundEndReason);
                }
            });
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}
