namespace NET8.Module.Option;

internal class IntDummyOption : DummyOption<int>
{
    public IntDummyOption(int size) : base(IDummyOption.CreateIntDummyValues(size).ToArray())
    { }

    public override dynamic GetValue() => this.OptionValue[this.Selection];
}

internal class IntDummyFixedTypeOption : DummyFixedTypeOption<int, int>
{
    public IntDummyFixedTypeOption(int size) : base(IDummyOption.CreateIntDummyValues(size).ToArray())
    { }

    public override int GetValue() => this.OptionValue[this.Selection];
}
