namespace NET8.Module.Option;

internal class BoolDummyOption : DummyOption<string>
{
    public BoolDummyOption() : base(new string[] { "ON", "OFF" })
    {
        SetSelection(Rng.Instance.Next(2));
    }

    public override dynamic GetValue() => this.Selection > 0;
}

internal class BoolDummyFixedTypeOption : DummyFixedTypeOption<string, bool>
{
    public BoolDummyFixedTypeOption() : base(new string[] { "ON", "OFF" })
    {
        SetSelection(Rng.Instance.Next(2));
    }

    public override bool GetValue() => this.Selection > 0;
}
