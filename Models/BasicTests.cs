namespace CSSharpTests
{
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
            this.Logger.LogInformation(message: "Initializing '{0}'", this.GetType().Name);
        }

        public void Release(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.GetType().Name);
        }
    }
}
