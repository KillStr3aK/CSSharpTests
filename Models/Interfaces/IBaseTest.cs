namespace CSSharpTests
{
    public interface IBaseTest
    {
        public void Initialize(bool hotReload);

        public void Release(bool hotReload);
    }
}
