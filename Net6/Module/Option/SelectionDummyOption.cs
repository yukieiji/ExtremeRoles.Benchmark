namespace NET6.Module.Option;

internal class SelectionDummyOption : DummyOption<string>
{
    public SelectionDummyOption(int size) : base(createDummyOption(size).ToArray())
    { }

    public override dynamic GetValue() => this.Selection;

    private static List<string> createDummyOption(int size)
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
