namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API.Modules.Memory;

    public partial class VirtualFunctionVoid
    {
        private Action Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid(signature);
        }

        public void Invoke()
        {
            this.Function();
        }
    }

    public partial class VirtualFunctionVoid<TArg1>
    {
        private Action<TArg1> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1)
        {
            this.Function(arg1);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2>
    {
        private Action<TArg1, TArg2> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2)
        {
            this.Function(arg1, arg2);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2, TArg3>
    {
        private Action<TArg1, TArg2, TArg3> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            this.Function(arg1, arg2, arg3);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2, TArg3, TArg4>
    {
        private Action<TArg1, TArg2, TArg3, TArg4> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            this.Function(arg1, arg2, arg3, arg4);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        private Action<TArg1, TArg2, TArg3, TArg4, TArg5> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            this.Function(arg1, arg2, arg3, arg4, arg5);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        private Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            this.Function(arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        private Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            this.Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    {
        private Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            this.Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
    {
        private Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            this.Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }

    public partial class VirtualFunctionVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
    {
        private Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> Function;

        public VirtualFunctionVoid(string signature)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(signature);
        }

        public VirtualFunctionVoid(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.CreateVoid<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(objectPtr, offset);
        }

        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            this.Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }
    }

    public partial class VirtualFunctionWithReturn<TResult>
    {
        private Func<TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TResult>(objectPtr, offset);
        }

        public TResult Invoke()
        {
            return this.Function();
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TResult>
    {
        private Func<TArg1, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1)
        {
            return this.Function(arg1);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TResult>
    {
        private Func<TArg1, TArg2, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2)
        {
            return this.Function(arg1, arg2);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TArg3, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            return this.Function(arg1, arg2, arg3);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TArg3, TArg4, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TArg4, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            return this.Function(arg1, arg2, arg3, arg4);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            return this.Function(arg1, arg2, arg3, arg4, arg5);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            return this.Function(arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            return this.Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            return this.Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            return this.Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }

    public partial class VirtualFunctionWithReturn<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Function;

        public VirtualFunctionWithReturn(string signature)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(signature);
        }

        public VirtualFunctionWithReturn(IntPtr objectPtr, int offset)
        {
            this.Function = VirtualFunction.Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(objectPtr, offset);
        }

        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            return this.Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }
    }
}
