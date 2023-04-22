namespace NET7.Module.Option;

public interface IDummyOption
{
    public void SetSelection(int newSelection);
    public dynamic GetValue();

    public static List<float> CreateFloatDummyValues(int size)
    {
        List<float> result = new List<float>();
        for (int i = 0; i < size; ++i)
        {
            result.Add((float)Rng.Instance.NextDouble());
        }
        return result;
    }

    public static List<int> CreateIntDummyValues(int size)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < size; ++i)
        {
            result.Add(Rng.Instance.Next());
        }
        return result;
    }

    public static List<string> CreateStrDummyValues(int size)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < size; ++i)
        {
            Guid guid = Guid.NewGuid();
            result.Add(guid.ToString("N"));
        }
        return result;
    }
}

public interface IDummyFixedOption<T>
{
    public void SetSelection(int newSelection);
    public T GetValue();
}


public abstract class DummyOption<T> : IDummyOption
{
    protected T[] OptionValue;
    protected int Selection;

    public DummyOption(T[] value)
    {
        this.OptionValue = value;
    }

    public void SetSelection(int newSelection)
    {
        this.Selection = Math.Clamp(newSelection, 0, OptionValue.Length - 1);
    }

    public abstract dynamic GetValue();

}

public abstract class DummyFixedTypeOption<T, Out> : IDummyFixedOption<Out>
{
    protected T[] OptionValue;
    protected int Selection;

    public DummyFixedTypeOption(T[] value)
    {
        this.OptionValue = value;
    }

    public void SetSelection(int newSelection)
    {
        this.Selection = Math.Clamp(newSelection, 0, OptionValue.Length - 1);
    }

    public abstract Out GetValue();
}
