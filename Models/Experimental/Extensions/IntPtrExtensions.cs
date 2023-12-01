namespace CSSharpTests.Experimental
{
    public static class IntPtrExtensions
    {
        public static IntPtr AddOffset(this IntPtr ptr, int offset)
        {
            return ptr + offset;
        }

        public static unsafe IntPtr ToAbsolute(this IntPtr ptr, int preOffset, int postOffset)
        {
            if (ptr != IntPtr.Zero)
            {
                ptr.AddOffset(preOffset);
                ptr = ptr + sizeof(int) + *(int*)(ptr);
                ptr.AddOffset(postOffset);
            }

            return ptr;
        }
    }
}
