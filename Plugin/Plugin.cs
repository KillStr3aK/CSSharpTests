namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Attributes;

    using CSSharpTests.Experimental;

    [MinimumApiVersion(83)]
    public sealed partial class Plugin : BasePlugin
    {
        private readonly BasicTests BasicTests;

        private readonly ExperimentalTests ExperimentalTests;

        public Plugin(BasicTests basicTests, ExperimentalTests experimentalTests)
        {
            this.BasicTests = basicTests;
            this.ExperimentalTests = experimentalTests;
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
