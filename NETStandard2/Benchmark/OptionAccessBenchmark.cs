using BenchmarkDotNet.Attributes;

using System.Collections.Generic;
using System.Linq;

using NETStandard2.Module.Option;

namespace NETStandard2.Benchmark
{
    internal class OptionAccessBenchmark
    {
        private Dictionary<int, IDummyOption> intOption = new ();
        private Dictionary<int, IDummyOption> floatOption = new();
        private Dictionary<int, IDummyOption> boolOption = new();
        private Dictionary<int, IDummyOption> selectionOption = new();

        private Dictionary<int, IDummyOption> mixedOption = new();

        private List<int> randomAccessKey = new List<int>(); 

        [Params(100, 500, 1000, 5000, 10000)]
        public int OptionNum;

        private const int SizeMin = 10;
        private const int SizeMax = 100;

        [GlobalSetup]
        public void Setup()
        {
            createIntOption();
            createFloatOption();
            createBoolOption();
            createSelectionOption();
            createMixedOption();

            randomAccessKey = Enumerable.Range(0, OptionNum).OrderBy(x => Program.Rng.Next()).ToList();
        }

        // シーケンシャルアクセス
        [Benchmark]
        public void SequentialAccessIntOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                int intValue = this.intOption[i].GetValue();
            }
        }

        [Benchmark]
        public void SequentialAccessFloatOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                float floatValue = this.floatOption[i].GetValue();
            }
        }

        [Benchmark]
        public void SequentialAccessBoolOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                bool boolValue = this.boolOption[i].GetValue();
            }
        }

        [Benchmark]
        public void SequentialAccessSelectionOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                int selection = this.selectionOption[i].GetValue();
            }
        }

        [Benchmark]
        public void SequentialAccessMixedOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                dynamic value = this.selectionOption[i].GetValue();
            }
        }


        // ランダムアクセス
        [Benchmark]
        public void RandomAccessIntOption()
        {
            foreach (int key in randomAccessKey)
            {
                int intValue = this.intOption[key].GetValue();
            }
        }

        [Benchmark]
        public void RandomAccessFloatOption()
        {
            foreach (int key in randomAccessKey)
            {
                float floatValue = this.floatOption[key].GetValue();
            }
        }

        [Benchmark]
        public void RandomAccessBoolOption()
        {
            foreach (int key in randomAccessKey)
            {
                bool boolValue = this.boolOption[key].GetValue();
            }
        }

        [Benchmark]
        public void RandomAccessSelectionOption()
        {
            foreach (int key in randomAccessKey)
            {
                int selection = this.selectionOption[key].GetValue();
            }
        }

        [Benchmark]
        public void RandomAccessMixedOption()
        {
            foreach (int key in randomAccessKey)
            {
                dynamic value = this.selectionOption[key].GetValue();
            }
        }

        private void createIntOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                var option = new IntDummyOption(Program.Rng.Next(SizeMin, SizeMax));
                option.SetSelection(Program.Rng.Next(SizeMax));

                intOption.Add(i, option);
            }
        }

        private void createFloatOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                var option = new FloatDummyOption(Program.Rng.Next(SizeMin, SizeMax));
                option.SetSelection(Program.Rng.Next(SizeMax));

                floatOption.Add(i, option);
            }
        }

        private void createBoolOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                boolOption.Add(i, new BoolDummyOption());
            }
        }

        private void createSelectionOption()
        {
            for (int i = 0; i < OptionNum; ++i)
            {
                var option = new SelectionDummyOption(Program.Rng.Next(SizeMin, SizeMax));
                option.SetSelection(Program.Rng.Next(SizeMax));

                selectionOption.Add(i, option);
            }
        }

        private void createMixedOption()
        {
            int repeatNum = OptionNum / 4;
            int key = 0;

            for (int i = 0; i < repeatNum; ++i)
            {
                for (int j = 0; j < 0; ++j)
                {
                    IDummyOption option;
                    switch (j)
                    {
                        case 0:
                            option = new IntDummyOption(Program.Rng.Next(SizeMin, SizeMax));
                            option.SetSelection(Program.Rng.Next(SizeMax));
                            break;
                        case 1:
                            option = new FloatDummyOption(Program.Rng.Next(SizeMin, SizeMax));
                            option.SetSelection(Program.Rng.Next(SizeMax));
                            break;
                        case 2:
                            option = new BoolDummyOption();
                            break;
                        case 3:
                            option = new SelectionDummyOption(Program.Rng.Next(SizeMin, SizeMax));
                            option.SetSelection(Program.Rng.Next(SizeMax));
                            break;
                        default:
                            continue;
                    }
                    mixedOption.Add(key, option);
                    key++;
                }
            }
        }
    }
}
