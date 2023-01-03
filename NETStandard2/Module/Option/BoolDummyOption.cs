namespace NETStandard2.Module.Option
{
    internal class BoolDummyOption : DummyOption<string>
    {
        public BoolDummyOption() : base(new string[] { "ON", "OFF" })
        {
            SetSelection(Program.Rng.Next(2));
        }

        public override dynamic GetValue() => this.Selection > 0;
    }
}
