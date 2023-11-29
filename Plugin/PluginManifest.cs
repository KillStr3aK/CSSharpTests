namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;

    public sealed partial class Plugin : BasePlugin
    {
        public override string ModuleName => "CSSharp Tests";

        public override string ModuleDescription => "Code Playground";

        public override string ModuleAuthor => "Nexd @ Eternar (https://eternar.dev)";

        public override string ModuleVersion => "1.0.1 " +
#if RELEASE
            "(release)";
#else
            "(debug)";
#endif
    }
}
