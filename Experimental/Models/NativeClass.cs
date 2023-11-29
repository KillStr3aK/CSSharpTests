namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Modules.Memory;

    using System.Runtime.InteropServices;

    // it'd be good if we could get the size of any schema class by a native
    class NativeClass<T> : IDisposable
        where T : NativeObject
    {
        private T UnmanagedInstance;

        private nint UnmanagedPtr;

        private bool Disposed = false;

        public ref T Value => ref this.UnmanagedInstance;

        /*
        public NativeClass() : this(Schema.GetClassSize(typeof(T)))
            { }
        */

        public NativeClass(int size)
        {
            this.UnmanagedPtr = Marshal.AllocHGlobal(size);
            this.UnmanagedInstance = (T)Activator.CreateInstance(typeof(T), this.UnmanagedPtr)!;
        }

        ~NativeClass()
        {
            if (!this.Disposed)
            {
                this.Dispose();
            }
        }

        public void Dispose()
        {
            if (!this.Disposed)
            {
                Marshal.FreeHGlobal(this.UnmanagedPtr);
                this.Disposed = true;
            }
        }

        public static implicit operator T(NativeClass<T> nc) => nc.UnmanagedInstance;

        public static implicit operator nint(NativeClass<T> nc) => nc.UnmanagedInstance.Handle;
    }
}
