namespace NET8.Module.Option;

internal class SelectionDummyOption : DummyOption<string>
{
    public SelectionDummyOption(int size) : base(IDummyOption.CreateStrDummyValues(size).ToArray())
    { }

    public override dynamic GetValue() => this.Selection;
}

internal class SelectionDummyFixedTypeOption : DummyFixedTypeOption<string, int>
{
    public SelectionDummyFixedTypeOption(int size) : base(IDummyOption.CreateStrDummyValues(size).ToArray())
    { }

    public override int GetValue() => this.Selection;
}