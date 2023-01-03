using BenchmarkDotNet.Attributes;
using NET6.Module.Option;

namespace NET6.Benchmark;

[Config(typeof(BenchmarkConfig))]
public class OptionAccessBenchmark
{
    private Dictionary<int, IDummyOption> intOption = new ();
    private Dictionary<int, IDummyOption> floatOption = new();
    private Dictionary<int, IDummyOption> boolOption = new();
    private Dictionary<int, IDummyOption> selectionOption = new();

    private Dictionary<int, IDummyOption> mixedOption = new();

    private List<int> randomAccessKey = new List<int>();
    private int getAccessKey;

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

        randomAccessKey = Enumerable.Range(0, OptionNum).OrderBy(x => Rng.Instance.Next()).ToList();
        getAccessKey = Rng.Instance.Next(0, OptionNum);
    }

    // 全アクセスベンチ
    // シーケンシャルアクセス
    [Benchmark]
    public void SequentialAllAccessIntOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            int intValue = this.intOption[i].GetValue();
        }
    }

    [Benchmark]
    public void SequentialAllAccessFloatOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            float floatValue = this.floatOption[i].GetValue();
        }
    }

    [Benchmark]
    public void SequentialAllAccessBoolOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            bool boolValue = this.boolOption[i].GetValue();
        }
    }

    [Benchmark]
    public void SequentialAllAccessSelectionOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            int selection = this.selectionOption[i].GetValue();
        }
    }

    [Benchmark]
    public void SequentialAllAccessMixedOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            dynamic value = this.mixedOption[i].GetValue();
        }
    }


    // ランダム全要素アクセス
    [Benchmark]
    public void RandomAllAccessIntOption()
    {
        foreach (int key in randomAccessKey)
        {
            int intValue = this.intOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandomAllAccessFloatOption()
    {
        foreach (int key in randomAccessKey)
        {
            float floatValue = this.floatOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandomAllAccessBoolOption()
    {
        foreach (int key in randomAccessKey)
        {
            bool boolValue = this.boolOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandomAllAccessSelectionOption()
    {
        foreach (int key in randomAccessKey)
        {
            int selection = this.selectionOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandoAllmAccessMixedOption()
    {
        foreach (int key in randomAccessKey)
        {
            dynamic value = this.mixedOption[key].GetValue();
        }
    }

    // 要素アクセス
    [Benchmark]
    public int IntOptionAccess() => this.intOption[this.getAccessKey].GetValue();
    [Benchmark]
    public float FloatOptionAccess() => this.floatOption[this.getAccessKey].GetValue();
    [Benchmark]
    public bool BoolOptionAccess() => this.boolOption[this.getAccessKey].GetValue();
    [Benchmark]
    public int SelectionOptionAccess() => this.selectionOption[this.getAccessKey].GetValue();
    [Benchmark]
    public dynamic MixedOptionAccess() => this.mixedOption[this.getAccessKey].GetValue();

    private void createIntOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            var option = new IntDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

            intOption.Add(i, option);
        }
    }

    private void createFloatOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            var option = new FloatDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

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
            var option = new SelectionDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

            selectionOption.Add(i, option);
        }
    }

    private void createMixedOption()
    {
        int repeatNum = OptionNum / 4;
        int key = 0;

        for (int i = 0; i < repeatNum; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                IDummyOption option;
                switch (j)
                {
                    case 0:
                        option = new IntDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
                        option.SetSelection(Rng.Instance.Next(SizeMax));
                        break;
                    case 1:
                        option = new FloatDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
                        option.SetSelection(Rng.Instance.Next(SizeMax));
                        break;
                    case 2:
                        option = new BoolDummyOption();
                        break;
                    case 3:
                        option = new SelectionDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
                        option.SetSelection(Rng.Instance.Next(SizeMax));
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
