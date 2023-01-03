using System.Collections.Generic;

namespace NETStandard2.Module.Option
{
    internal class FloatDummyOption : DummyOption<float>
    {
        public FloatDummyOption(int size) : base(createDummyOption(size).ToArray())
        { }

        public override dynamic GetValue() => this.Selection;
    
        private static List<float> createDummyOption(int size)
        {
            List<float> result = new List<float>();
            for (int i = 0; i < size; ++i)
            {
                result.Add((float)Program.Rng.NextDouble());
            }
            return result;
        }
    }
}
