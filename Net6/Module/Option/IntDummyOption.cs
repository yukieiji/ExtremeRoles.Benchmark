namespace NET6.Module.Option;

internal class IntDummyOption : DummyOption<int>
{
    public IntDummyOption(int size) : base(createDummyOption(size).ToArray())
    { }

    public override dynamic GetValue() => this.OptionValue[this.Selection];

    private static List<int> createDummyOption(int size)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < size; ++i)
        {
            result.Add(Rng.Instance.Next());
        }
        return result;
    }
}
