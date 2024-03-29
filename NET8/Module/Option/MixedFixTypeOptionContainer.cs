﻿using System.Collections.Frozen;

using Tuple = (int x, int y);

namespace NET8.Module.Option;

internal class MixedFixTypeOptionContainer
{
    private readonly Dictionary<int, IDummyFixedOption<int>> _intOptions = new();
    private readonly Dictionary<int, IDummyFixedOption<bool>> _boolOptions = new();
    private readonly Dictionary<int, IDummyFixedOption<float>> _floatOptions = new();

    private FrozenDictionary<int, IDummyFixedOption<int>> _intFrozenOptions;
    private FrozenDictionary<int, IDummyFixedOption<bool>> _boolFrozenOptions;
    private FrozenDictionary<int, IDummyFixedOption<float>> _floatFrozenOptions;

    public MixedFixTypeOptionContainer()
    { }

    public T Get<T>(int key)
    {
        IDummyFixedOption<T> option = null;
        if (typeof(T) == typeof(int))
        {
            option = _intFrozenOptions[key] as IDummyFixedOption<T>;
        }
        else if (typeof(T) == typeof(bool))
        {
            option = _boolFrozenOptions[key] as IDummyFixedOption<T>;
        }
        else if (typeof(T) == typeof(float))
        {
            option = _floatFrozenOptions[key] as IDummyFixedOption<T>;
        }
        return option.GetValue();
    }

    public void Freeze()
    {
        this._intFrozenOptions = this._intOptions.ToFrozenDictionary(true);
        this._floatFrozenOptions = this._floatOptions.ToFrozenDictionary(true);
        this._boolFrozenOptions = this._boolOptions.ToFrozenDictionary(true);
    }

    public void Add<T>(int key, IDummyFixedOption<T> option)
    {
        if (typeof(T) == typeof(int))
        {
            _intOptions.Add(key, (IDummyFixedOption<int>)option);
        }
        else if (typeof(T) == typeof(bool))
        {
            _boolOptions.Add(key, (IDummyFixedOption<bool>)option);
        }
        else if (typeof(T) == typeof(float))
        {
            _floatOptions.Add(key, (IDummyFixedOption<float>)option);
        }
    }

    public bool TryGetOption<T>(int key, out IDummyFixedOption<T> option)
    {
        option = null;
        if (typeof(T) == typeof(int))
        {
            if (_intOptions.TryGetValue(key, out var intOption))
            {
                option = intOption as IDummyFixedOption<T>;
                return true;
            }
        }
        else if (typeof(T) == typeof(bool))
        {
            if (_boolOptions.TryGetValue(key, out var boolOption))
            {
                option = boolOption as IDummyFixedOption<T>;
                return true;
            }
        }
        else if (typeof(T) == typeof(float))
        {
            if (_floatOptions.TryGetValue(key, out var floatOption))
            {
                option = floatOption as IDummyFixedOption<T>;
                return true;
            }
        }

        return false;
    }
}
