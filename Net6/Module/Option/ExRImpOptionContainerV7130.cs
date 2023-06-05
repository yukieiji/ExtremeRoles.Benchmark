using System.Runtime.CompilerServices;

namespace NET6.Module.Option
{
    internal sealed class ExRImpOptionContainerV7130
    {
        internal enum DType
        {
            Int,
            Float,
            Bool,
        }

        private readonly Dictionary<int, DType> _ids = new();

        private readonly Dictionary<int, IDummyFixedOption<int>> _intOptions = new();
        private readonly Dictionary<int, IDummyFixedOption<bool>> _boolOptions = new();
        private readonly Dictionary<int, IDummyFixedOption<float>> _floatOptions = new();

        public ExRImpOptionContainerV7130()
        { }

        public IEnumerable<IFixedOption> GetAllOption()
        {
            foreach (var (id, type) in _ids)
            {
                yield return type switch
                {
                    DType.Int => _intOptions[id],
                    DType.Float => _floatOptions[id],
                    DType.Bool => _boolOptions[id],
                    _ => throw new InvalidOperationException(),
                };
            }
        }

        public IFixedOption GetIOption(int id)
            => this._ids[id] switch
            {
                DType.Int => _intOptions[id],
                DType.Float => _floatOptions[id],
                DType.Bool => _boolOptions[id],
                _ => throw new ArgumentException("Invalided Option Id"),
            };

        public T Get<T>(int key)
        {
            if (typeof(T) == typeof(int))
            {
                var intOption = _intOptions[key];
                int intValue = intOption.GetValue();
                return Unsafe.As<int, T>(ref intValue);
            }
            else if (typeof(T) == typeof(float))
            {
                var floatOption = _floatOptions[key];
                float floatValue = floatOption.GetValue();
                return Unsafe.As<float, T>(ref floatValue);
            }
            else if (typeof(T) == typeof(bool))
            {
                var boolOption = _boolOptions[key];
                bool boolValue = boolOption.GetValue();
                return Unsafe.As<bool, T>(ref boolValue);
            }
            return default(T);
        }

        public void Add<T>(int key, IDummyFixedOption<T> option)
        {
            if (option is IDummyFixedOption<int> intOption)
            {
                _ids.Add(key, DType.Int);
                _intOptions.Add(key, intOption);
            }
            else if (option is IDummyFixedOption<bool> boolOption)
            {
                _ids.Add(key, DType.Bool);
                _boolOptions.Add(key, boolOption);
            }
            else if (option is IDummyFixedOption<float> floatOption)
            {
                _ids.Add(key, DType.Float);
                _floatOptions.Add(key, floatOption);
            }
        }
    }
}
