namespace NET6.Module.Option;

internal sealed class ExRImpOptionContainerV7100
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

    public ExRImpOptionContainerV7100()
    { }

    public T Get<T>(int key)
    {
        DType type = _ids[key];

        switch (type)
        {
            case DType.Int:
                var intOption = _intOptions[key] as IDummyFixedOption<T>;
                return intOption!.GetValue();
            case DType.Float:
                var floatOption = _floatOptions[key] as IDummyFixedOption<T>;
                return floatOption!.GetValue();
            case DType.Bool:
                var boolOption = _boolOptions[key] as IDummyFixedOption<T>;
                return boolOption!.GetValue();
            default:
                return default(T);
        }
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
