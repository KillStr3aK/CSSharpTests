namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;

    public unsafe class CUtlVector<T> : NativeObject
    {
        public CUtlVector(nint ptr) : base(ptr)
            { }
    }
}
