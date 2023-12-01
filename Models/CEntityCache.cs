namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;

    public class CEntityCache<T> where T : CEntityInstance
    {
        private readonly Func<T?> ValueFactory;
        private Lazy<T?> LazyValue;

        public CEntityCache(Func<T> valueFactory)
        {
            ValueFactory = valueFactory;
            LazyValue = new Lazy<T?>(ValueFactory);
        }

        public bool IsValid => LazyValue.Value != null && LazyValue.Value.IsValid;

        public T? Value
        {
            get
            {
                if (!IsValid)
                {
                    LazyValue = new Lazy<T?>(() => ValueFactory());
                }

                return LazyValue.Value;
            }
        }
    }
}
