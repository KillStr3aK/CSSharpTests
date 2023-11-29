namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;
    using Microsoft.Extensions.DependencyInjection;
    using CSSharpTests.Experimental;

    public class PluginServices : IPluginServiceCollection<Plugin>
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<BasicTests>();
            serviceCollection.AddSingleton<ExperimentalTests>();
        }
    }
}
