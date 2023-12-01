namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;

    public unsafe class CUtlMap<K, V> : NativeObject
        where V: NativeObject
    {
        public CUtlMap(nint ptr) : base(ptr)
            { }
    }
}
