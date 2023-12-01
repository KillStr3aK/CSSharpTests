namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;

    public unsafe class CEconItemSchema : NativeObject
    {
        public CEconItemSchema(nint ptr) : base(ptr)
            { }

        public CUtlMap<int, CEconItemDefinition> GetItemDefinitionMap()
        {
            return new CUtlMap<int, CEconItemDefinition>(*(nint*)(this.Handle + 0x120));
        }
    }
}
