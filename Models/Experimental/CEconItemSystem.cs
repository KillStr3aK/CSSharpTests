namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;

    public unsafe class CEconItemSystem : NativeObject
    {
        public CEconItemSystem(nint ptr) : base(ptr)
            { }

        public CEconItemSchema GetEconItemSchema()
        {
            return new CEconItemSchema(*(nint*)((nint**)(this.Handle + 0x8)));
        }
    }
}
