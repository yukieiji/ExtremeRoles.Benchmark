namespace NET7.Module.Option
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
        public static implicit operator T(DynamicOptionValueCacher<T> cacher)
        {
            return cacher.Value;
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

    internal class DynamicNoneCheckOptionCacher<T> where T : struct
    {
        public T Value
        {
            get
            {
                return option.GetValue();
            }
        }
        private IDummyOption option;

        public DynamicNoneCheckOptionCacher(IDummyOption option)
        {
            this.option = option;
        }
    }
}
