using System.Collections.Generic;

namespace NETStandard2.Module.Option
{
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
                result.Add(Program.Rng.Next());
            }
            return result;
        }
    }
}
