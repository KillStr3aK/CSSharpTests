namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;

    public sealed class PluginConfig : BasePluginConfig
    {
        public WIN_LINUX<string> GetAttributeDefinitionByNameSignature { get; set; } = new WIN_LINUX<string>(string.Empty, string.Empty);

        public WIN_LINUX<string> NetworkStateChangedSignature { get; set; } = new WIN_LINUX<string>(string.Empty, string.Empty);

        public WIN_LINUX<string> StateChangedSignature { get; set; } = new WIN_LINUX<string>(string.Empty, string.Empty);
    }
}
