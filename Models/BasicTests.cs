namespace CSSharpTests
{
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
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}
