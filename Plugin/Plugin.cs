﻿namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Attributes;

    using CSSharpTests.Experimental;

    using Microsoft.Extensions.Logging;

    [MinimumApiVersion(78)] 
    public sealed partial class Plugin : BasePlugin, IPluginConfig<PluginConfig>
    {
        public required PluginConfig Config { get; set; } = new PluginConfig();

        private readonly BasicTests BasicTests;

        private readonly ExperimentalTests ExperimentalTests;

        public Plugin(BasicTests basicTests, ExperimentalTests experimentalTests)
        {
            this.BasicTests = basicTests;
            this.ExperimentalTests = experimentalTests;
        }

        public void OnConfigParsed(PluginConfig config)
        {
            if (config.Version < this.Config.Version)
            {
                Logger.LogWarning("Configuration version mismatch (Expected: {0} | Current: {1})", this.Config.Version, config.Version);
            }

            this.Config = config;
        }

        public override void Load(bool hotReload)
        {
            this.BasicTests.Initialize(hotReload);
            this.ExperimentalTests.Initialize(hotReload);
        }

        public override void Unload(bool hotReload)
        {
            this.BasicTests.Release(hotReload);
            this.ExperimentalTests.Release(hotReload);
        }
    }
}
