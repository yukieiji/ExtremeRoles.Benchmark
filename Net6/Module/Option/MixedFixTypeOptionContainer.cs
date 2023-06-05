namespace NET6.Module.Option
{
    internal class MixedFixTypeOptionContainer
    {
        private readonly Dictionary<int, IDummyFixedOption<int>> _intOptions = new();
        private readonly Dictionary<int, IDummyFixedOption<bool>> _boolOptions = new();
        private readonly Dictionary<int, IDummyFixedOption<float>> _floatOptions = new();

        public MixedFixTypeOptionContainer()
        { }

        public IEnumerable<IFixedOption> GetAllOption()
        {
            foreach (var opt in _intOptions.Values)
            {
                yield return opt;
            }
            foreach (var opt in _floatOptions.Values)
            {
                yield return opt;
            }
            foreach (var opt in _boolOptions.Values)
            {
                yield return opt;
            }
        }

        public IFixedOption GetIOption(int id)
        {
            if (_intOptions.TryGetValue(id, out var intOption))
            {
                return intOption;
            }
            else if (_floatOptions.TryGetValue(id, out var floatOption))
            {
                return floatOption;
            }
            else if (_boolOptions.TryGetValue(id, out var boolOption))
            {
                return boolOption;
            }
            else
            {
                throw new ArgumentException("Invalided Option Id");
            }
        }

        public T Get<T>(int key)
        {
            IDummyFixedOption<T> option = null;
            if (typeof(T) == typeof(int))
            {
                option = _intOptions[key] as IDummyFixedOption<T>;
            }
            else if (typeof(T) == typeof(bool))
            {
                option = _boolOptions[key] as IDummyFixedOption<T>;
            }
            else if (typeof(T) == typeof(float))
            {
                option = _floatOptions[key] as IDummyFixedOption<T>;
            }
            return option.GetValue();
        }

        public void Add<T>(int key, IDummyFixedOption<T> option)
        {
            if (typeof(T) == typeof(int))
            {
                _intOptions.Add(key, (IDummyFixedOption<int>)option);
            }
            else if (typeof(T) == typeof(bool))
            {
                _boolOptions.Add(key, (IDummyFixedOption<bool>)option);
            }
            else if (typeof(T) == typeof(float))
            {
                _floatOptions.Add(key, (IDummyFixedOption<float>)option);
            }
        }

        public bool TryGetOption<T>(int key, out IDummyFixedOption<T> option)
        {
            option = null;
            if (typeof(T) == typeof(int))
            {
                if (_intOptions.TryGetValue(key, out var intOption))
                {
                    option = intOption as IDummyFixedOption<T>;
                    return true;
                }
            }
            else if (typeof(T) == typeof(bool))
            {
                if (_boolOptions.TryGetValue(key, out var boolOption))
                {
                    option = boolOption as IDummyFixedOption<T>;
                    return true;
                }
            }
            else if (typeof(T) == typeof(float))
            {
                if (_floatOptions.TryGetValue(key, out var floatOption))
                {
                    option = floatOption as IDummyFixedOption<T>;
                    return true;
                }
            }

            return false;
        }
    }
}
