namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Modules.Memory;

    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public unsafe class NativeClass<SchemaClass> : IDisposable
        where SchemaClass : NativeObject
    {
        private SchemaClass UnmanagedInstance;

        private nint UnmanagedPtr;

        public ref SchemaClass Value => ref this.UnmanagedInstance;

        private bool disposed = false;

        public NativeClass() : this(Schema.GetClassSize(typeof(SchemaClass).Name))
            { }

        public NativeClass(int size)
        {
            this.UnmanagedPtr = Marshal.AllocHGlobal(size);
            Unsafe.InitBlockUnaligned((void*)this.UnmanagedPtr, 0x0, (uint)size);
            this.UnmanagedInstance = (SchemaClass)Activator.CreateInstance(typeof(SchemaClass), this.UnmanagedPtr)!;
        }

        ~NativeClass()
        {
            this.Dispose(disposing: false);
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (this.UnmanagedPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(this.UnmanagedPtr);
                    this.UnmanagedPtr = IntPtr.Zero;
                }

                this.disposed = true;
            }
        }

        public static implicit operator SchemaClass(NativeClass<SchemaClass> nc) => nc.UnmanagedInstance;

        public static implicit operator nint(NativeClass<SchemaClass> nc) => nc.UnmanagedInstance.Handle;
    }
}
