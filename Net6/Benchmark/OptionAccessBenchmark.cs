﻿using BenchmarkDotNet.Attributes;
using NET6.Module.Option;

namespace NET6.Benchmark;

[Config(typeof(BenchmarkConfig))]
public class OptionAccessBenchmark
{
    private Dictionary<int, IntDummyFixedTypeOption> intOption = new();
    private Dictionary<int, FloatDummyFixedTypeOption> floatOption = new();
    private Dictionary<int, BoolDummyFixedTypeOption> boolOption = new();
    private Dictionary<int, SelectionDummyFixedTypeOption> selectionOption = new();


    private Dictionary<int, IDummyOption> intDynamicOption = new ();
    private Dictionary<int, IDummyOption> floatDynamicOption = new();
    private Dictionary<int, IDummyOption> boolDynamicOption = new();
    private Dictionary<int, IDummyOption> selectionDynamicOption = new();

    private Dictionary<int, IDummyOption> mixedOption = new();


    private DynamicOptionValueCacher<int> intValueCacher = null;
    private DynamicOptionValueCacher<float> floatValueCacher = null;
    private DynamicOptionValueCacher<bool> boolValueCacher = null;
    private DynamicOptionValueCacher<int> selectionValueCacher = null;

    private DynamicOptionCacher<int> intOptionCacher = null;
    private DynamicOptionCacher<float> floatOptionCacher = null;
    private DynamicOptionCacher<bool> boolOptionCacher = null;
    private DynamicOptionCacher<int> selectionOptionCacher = null;

    private DynamicNoneCheckOptionCacher<int> intNoneCheckOptionCacher = null;
    private DynamicNoneCheckOptionCacher<float> floatNoneCheckOptionCacher = null;
    private DynamicNoneCheckOptionCacher<bool> boolNoneCheckOptionCacher = null;
    private DynamicNoneCheckOptionCacher<int> selectionNoneCheckOptionCacher = null;

    private MixedFixTypeOptionContainer allOption = null;
    private ExRImpOptionContainerV7100 allOptionExR = null;
    private ExRImpOptionContainerV7130 allOptionExRNew = null;
    private int intAccessKey;
    private int floatAccessKey;
    private int boolAccessKey;

    private List<int> randomAccessKey = new List<int>();
    private int getAccessKey;

    [Params(100, 500, 1000, 5000, 10000)]
    public int OptionNum;

    private const int SizeMin = 10;
    private const int SizeMax = 100;

    [GlobalSetup]
    public void Setup()
    {
        createDynamicOption();
        createBaseLineOption();
        createDynamicOptionValueCacher();
        createDynamicOptionCacher();
        createDynamicOptionCacherWithNoneCheck();
        createMixedFixOption();
        createExROptions();

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
    public void SequentialAllAccessDynamicIntOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            int intValue = this.intDynamicOption[i].GetValue();
        }
    }
    [Benchmark]
    public void SequentialAllAccessDynamicFloatOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            float floatValue = this.floatDynamicOption[i].GetValue();
        }
    }
    [Benchmark]
    public void SequentialAllAccessDynamicBoolOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            bool boolValue = this.boolDynamicOption[i].GetValue();
        }
    }
    [Benchmark]
    public void SequentialAllAccessDynamicSelectionOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            int selection = this.selectionDynamicOption[i].GetValue();
        }
    }
    [Benchmark]
    public void SequentialAllAccessDynamicMixedOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            dynamic value = this.mixedOption[i].GetValue();
        }
    }
    [Benchmark]
    public void SequentialAllAccessMixedFixOption()
    {
        foreach (var opt in this.allOption.GetAllOption())
        {
            int value = opt.GetSelection();
        }
    }
    [Benchmark]
    public void SequentialAllAccessMixedFixExRImpV7100Option()
    {
        foreach (var opt in this.allOptionExR.GetAllOption())
        {
            int value = opt.GetSelection();
        }
    }
    [Benchmark]
    public void SequentialAllAccessMixedFixExRImpV7130Option()
    {
        foreach (var opt in this.allOptionExRNew.GetAllOption())
        {
            int value = opt.GetSelection();
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
    public void RandomAllAccessDynamicIntOption()
    {
        foreach (int key in randomAccessKey)
        {
            int intValue = this.intDynamicOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandomAllAccessDynamicFloatOption()
    {
        foreach (int key in randomAccessKey)
        {
            float floatValue = this.floatDynamicOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandomAllAccessDynamicBoolOption()
    {
        foreach (int key in randomAccessKey)
        {
            bool boolValue = this.boolDynamicOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandomAllAccessDynamicSelectionOption()
    {
        foreach (int key in randomAccessKey)
        {
            int selection = this.selectionDynamicOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandomAllAccessMixedOption()
    {
        foreach (int key in randomAccessKey)
        {
            dynamic value = this.mixedOption[key].GetValue();
        }
    }
    [Benchmark]
    public void RandomAllAccessMixedFixOption()
    {
        foreach (int key in randomAccessKey)
        {
            int value = this.allOption.GetIOption(key).GetSelection();
        }
    }
    [Benchmark]
    public void RandomAllAccessMixedFixExRImpV7100Option()
    {
        foreach (int key in randomAccessKey)
        {
            int value = this.allOptionExR.GetIOption(key).GetSelection();
        }
    }
    [Benchmark]
    public void RandomAllAccessMixedFixExRImpV7130Option()
    {
        foreach (int key in randomAccessKey)
        {
            int value = this.allOptionExRNew.GetIOption(key).GetSelection();
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
    public int DynamicIntOptionAccess() => this.intDynamicOption[this.getAccessKey].GetValue();
    [Benchmark]
    public float DynamicFloatOptionAccess() => this.floatDynamicOption[this.getAccessKey].GetValue();
    [Benchmark]
    public bool DynamicBoolOptionAccess() => this.boolDynamicOption[this.getAccessKey].GetValue();
    [Benchmark]
    public int DynamicSelectionOptionAccess() => this.selectionDynamicOption[this.getAccessKey].GetValue();
    [Benchmark]
    public dynamic MixedOptionAccess() => this.mixedOption[this.getAccessKey].GetValue();
    [Benchmark]
    public int CacheIntOptionValueAccess() => this.intValueCacher.Value;
    [Benchmark]
    public float CacheFloatOptionValueAccess() => this.floatValueCacher.Value;
    [Benchmark]
    public bool CacheBoolOptionValueAccess() => this.boolValueCacher.Value;
    [Benchmark]
    public int CacheSelectionOptionValueAccess() => this.selectionValueCacher.Value;
    
    [Benchmark]
    public int CacheIntOptionValueImplicitAccess() => this.intValueCacher;
    [Benchmark]
    public float CacheFloatOptionValueImplicitAccess() => this.floatValueCacher;
    [Benchmark]
    public bool CacheBoolOptionValueImplicitAccess() => this.boolValueCacher;
    [Benchmark]
    public int CacheSelectionOptionValueImplicitAccess() => this.selectionValueCacher;
    
    [Benchmark]
    public int CacheIntOptionAccess() => this.intOptionCacher.Value;
    [Benchmark]
    public float CacheFloatOptionAccess() => this.floatOptionCacher.Value;
    [Benchmark]
    public bool CacheBoolOptionAccess() => this.boolOptionCacher.Value;
    [Benchmark]
    public int CacheSelectionOptionAccess() => this.selectionOptionCacher.Value;
    [Benchmark]
    public int CacheNoneCheckIntOptionAccess() => this.intNoneCheckOptionCacher.Value;
    [Benchmark]
    public float CacheNoneCheckFloatOptionAccess() => this.floatNoneCheckOptionCacher.Value;
    [Benchmark]
    public bool CacheNoneCheckBoolOptionAccess() => this.boolNoneCheckOptionCacher.Value;
    [Benchmark]
    public int CacheNoneCheckSelectionOptionAccess() => this.selectionNoneCheckOptionCacher.Value;
    
    [Benchmark]
    public float MixedFixFloatOptionAccess() => this.allOption.Get<float>(this.floatAccessKey);
    [Benchmark]
    public bool MixedFixBoolOptionAccess() => this.allOption.Get<bool>(this.boolAccessKey);
    [Benchmark]
    public int MixedFixIntOptionAccess() => this.allOption.Get<int>(this.intAccessKey);
    [Benchmark]
    public float MixedFixExRImpV7100FloatOptionAccess() => this.allOptionExR.Get<float>(this.floatAccessKey);
    [Benchmark]
    public bool MixedFixExRImpV7100BoolOptionAccess() => this.allOptionExR.Get<bool>(this.boolAccessKey);
    [Benchmark]
    public int MixedFixExRImpV7100IntOptionAccess() => this.allOptionExR.Get<int>(this.intAccessKey);
    [Benchmark]
    public float MixedFixExRImpV7130FloatOptionAccess() => this.allOptionExRNew.Get<float>(this.floatAccessKey);
    [Benchmark]
    public bool MixedFixExRImpV7130BoolOptionAccess() => this.allOptionExRNew.Get<bool>(this.boolAccessKey);
    [Benchmark]
    public int MixedFixExRImpV7130IntOptionAccess() => this.allOptionExRNew.Get<int>(this.intAccessKey);


    private void createBaseLineOption()
    {
        createIntOption();
        createFloatOption();
        createBoolOption();
        createSelectionOption();
    }

    private void createIntOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            var option = new IntDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

            intOption.Add(i, option);
        }
    }

    private void createFloatOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            var option = new FloatDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

            floatOption.Add(i, option);
        }
    }

    private void createBoolOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            boolOption.Add(i, new BoolDummyFixedTypeOption());
        }
    }

    private void createSelectionOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            var option = new SelectionDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

            selectionOption.Add(i, option);
        }
    }


    private void createDynamicOption()
    {
        createDynamicIntOption();
        createDynamicFloatOption();
        createDynamicBoolOption();
        createDynamicSelectionOption();
        createDynamicMixedOption();
    }

    private void createDynamicIntOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            var option = new IntDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

            intDynamicOption.Add(i, option);
        }
    }

    private void createDynamicFloatOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            var option = new FloatDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

            floatDynamicOption.Add(i, option);
        }
    }

    private void createDynamicBoolOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            boolDynamicOption.Add(i, new BoolDummyOption());
        }
    }

    private void createDynamicSelectionOption()
    {
        for (int i = 0; i < OptionNum; ++i)
        {
            var option = new SelectionDummyOption(Rng.Instance.Next(SizeMin, SizeMax));
            option.SetSelection(Rng.Instance.Next(SizeMax));

            selectionDynamicOption.Add(i, option);
        }
    }

    private void createDynamicMixedOption()
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


    private void createDynamicOptionValueCacher()
    {
        int key = Rng.Instance.Next(0, OptionNum);

        this.intValueCacher = new DynamicOptionValueCacher<int>(key, this.intDynamicOption);
        this.floatValueCacher = new DynamicOptionValueCacher<float>(key, this.floatDynamicOption);
        this.boolValueCacher = new DynamicOptionValueCacher<bool>(key, this.boolDynamicOption);
        this.selectionValueCacher = new DynamicOptionValueCacher<int>(key, this.selectionDynamicOption);
    }
    private void createDynamicOptionCacher()
    {
        int key = Rng.Instance.Next(0, OptionNum);

        this.intOptionCacher = new DynamicOptionCacher<int>(this.intDynamicOption[key]);
        this.floatOptionCacher = new DynamicOptionCacher<float>(this.floatDynamicOption[key]);
        this.boolOptionCacher = new DynamicOptionCacher<bool>(this.boolDynamicOption[key]);
        this.selectionOptionCacher = new DynamicOptionCacher<int>(this.selectionDynamicOption[key]);
    }
    private void createDynamicOptionCacherWithNoneCheck()
    {
        int key = Rng.Instance.Next(0, OptionNum);

        this.intNoneCheckOptionCacher = new DynamicNoneCheckOptionCacher<int>(
            this.intDynamicOption[key]);
        this.floatNoneCheckOptionCacher = new DynamicNoneCheckOptionCacher<float>(
            this.floatDynamicOption[key]);
        this.boolNoneCheckOptionCacher = new DynamicNoneCheckOptionCacher<bool>(
            this.boolDynamicOption[key]);
        this.selectionNoneCheckOptionCacher = new DynamicNoneCheckOptionCacher<int>(
            this.selectionDynamicOption[key]);
    }

    private void createMixedFixOption()
    {
        this.allOption = new MixedFixTypeOptionContainer();

        int repeatNum = OptionNum / 4;
        int key = 0;

        List<int> intKeys = new List<int>();
        List<int> floatKeys = new List<int>();
        List<int> boolKeys = new List<int>();

        for (int i = 0; i < repeatNum; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                switch (j)
                {
                    case 0:
                        var intOpt = new IntDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
                        intOpt.SetSelection(Rng.Instance.Next(SizeMax));
                        this.allOption.Add(key, intOpt);
                        intKeys.Add(key);
                        break;
                    case 1:
                        var floatOpt = new FloatDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
                        floatOpt.SetSelection(Rng.Instance.Next(SizeMax));
                        this.allOption.Add(key, floatOpt);
                        floatKeys.Add(key);
                        break;
                    case 2:
                        var boolOpt = new BoolDummyFixedTypeOption();
                        this.allOption.Add(key, boolOpt);
                        boolKeys.Add(key);
                        break;
                    case 3:
                        var selOpt = new SelectionDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
                        selOpt.SetSelection(Rng.Instance.Next(SizeMax));
                        this.allOption.Add(key, selOpt);
                        intKeys.Add(key);
                        break;
                    default:
                        continue;
                }
                key++;
            }
        }
        this.intAccessKey = getRandomListValue(intKeys);
        this.floatAccessKey = getRandomListValue(floatKeys);
        this.boolAccessKey = getRandomListValue(boolKeys);
    }

    private void createExROptions()
    {
        this.allOptionExR = new ();
        this.allOptionExRNew = new();

        int repeatNum = OptionNum / 4;
        int key = 0;

        for (int i = 0; i < repeatNum; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                switch (j)
                {
                    case 0:
                        var intOpt = new IntDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
                        intOpt.SetSelection(Rng.Instance.Next(SizeMax));
                        this.allOptionExR.Add(key, intOpt);
                        this.allOptionExRNew.Add(key, intOpt);
                        break;
                    case 1:
                        var floatOpt = new FloatDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
                        floatOpt.SetSelection(Rng.Instance.Next(SizeMax));
                        this.allOptionExR.Add(key, floatOpt);
                        this.allOptionExRNew.Add(key, floatOpt);
                        break;
                    case 2:
                        var boolOpt = new BoolDummyFixedTypeOption();
                        this.allOptionExR.Add(key, boolOpt);
                        this.allOptionExRNew.Add(key, boolOpt);
                        break;
                    case 3:
                        var selOpt = new SelectionDummyFixedTypeOption(Rng.Instance.Next(SizeMin, SizeMax));
                        selOpt.SetSelection(Rng.Instance.Next(SizeMax));
                        this.allOptionExR.Add(key, selOpt);
                        this.allOptionExRNew.Add(key, selOpt);
                        break;
                    default:
                        continue;
                }
                key++;
            }
        }
    }

    private static T getRandomListValue<T>(List<T> list)
    {
        return list[Rng.Instance.Next(0, list.Count)];
    }
}
