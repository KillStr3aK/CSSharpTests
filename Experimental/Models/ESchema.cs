namespace CSSharpTests.Experimental
{
    using System.Runtime.InteropServices;

    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Modules.Memory;

    public unsafe class ESchema
    {
        public unsafe T[] GetFixedArray<T>(nint pointer, string @class, string member, int length) where T : NativeObject
        {
            nint ptr = pointer + Schema.GetSchemaOffset(@class, member);
            Span<nint> references = MemoryMarshal.CreateSpan<nint>(ref ptr, length);
            T[] values = new T[length];

            for (int i = 0; i < length; i++)
            {
                values[i] = (T)Activator.CreateInstance(typeof(T), references[i])!;
            }

            return values;
        }
    }
}
