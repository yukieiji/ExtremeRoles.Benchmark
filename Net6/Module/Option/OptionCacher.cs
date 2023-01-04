namespace NET6.Module.Option
{
    internal class DynamicOptionValueCacher<T> where T : struct
    {
        public T Value
        { 
            get
            {
                if (!value.HasValue)
                {
                    value = globalOption[this.key].GetValue();
                }
                return value.Value;
            }
        }

        private T? value = null;
        private int key;
        private IReadOnlyDictionary<int, IDummyOption> globalOption;

        public DynamicOptionValueCacher(int key, Dictionary<int, IDummyOption> option)
        {
            this.globalOption = option;
            this.key = key;
        }
    }

    internal class DynamicOptionCacher<T> where T : struct
    {
        public T Value
        {
            get
            {
                if (!value.HasValue)
                {
                    value = option.GetValue();
                }
                return value.Value;
            }
        }

        private T? value = null;
        private IDummyOption option;

        public DynamicOptionCacher(IDummyOption option)
        {
            this.option = option;
        }
    }
}
