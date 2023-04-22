using System.Drawing;

namespace NET8.Module.Option;

internal class FloatDummyOption : DummyOption<float>
{
    public FloatDummyOption(int size) : base(IDummyOption.CreateFloatDummyValues(size).ToArray())
    { }

    public override dynamic GetValue() => this.OptionValue[this.Selection];
}

internal class FloatDummyFixedTypeOption : DummyFixedTypeOption<float, float>
{
    public FloatDummyFixedTypeOption(int size) : base(IDummyOption.CreateFloatDummyValues(size).ToArray())
    { }

    public override float GetValue() => this.OptionValue[this.Selection];
}
