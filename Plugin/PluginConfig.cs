namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;

    using System.Text.Json.Serialization;

    public sealed class PluginConfig : BasePluginConfig
    {
        public WIN_LINUX<string> GetAttributeDefinitionByNameSignature { get; set; } = new WIN_LINUX<string>(string.Empty, string.Empty);
    }
}
