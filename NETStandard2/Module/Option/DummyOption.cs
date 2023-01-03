using System;

namespace NETStandard2.Module.Option
{
    public interface IDummyOption
    {
        public void SetSelection(int newSelection);
        public dynamic GetValue();
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
            this.Selection = Math.Clamp(newSelection, 0, OptionValue.Length);
        }

        public abstract dynamic GetValue();
    }
}
