# Envs
- BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
- AMD Ryzen Threadripper 1950X, 1 CPU, 32 logical and 16 physical cores
- .NET SDK=7.0.100
   - [Host]   : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2 [AttachedDebugger]
   - ShortRun : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2

- Job=ShortRun  IterationCount=3  LaunchCount=1  
- WarmupCount=3  

# Result
|                             Method | OptionNum |          Mean |          Error |        StdDev |
|----------------------------------- |---------- |--------------:|---------------:|--------------:|
|       **SequentialAllAccessIntOption** |       **100** |   **1,501.66 ns** |     **318.854 ns** |     **17.477 ns** |
|     SequentialAllAccessFloatOption |       100 |   1,689.03 ns |     894.330 ns |     49.021 ns |
|      SequentialAllAccessBoolOption |       100 |   1,393.68 ns |      38.118 ns |      2.089 ns |
| SequentialAllAccessSelectionOption |       100 |   1,453.36 ns |     244.024 ns |     13.376 ns |
|     SequentialAllAccessMixedOption |       100 |   1,452.04 ns |      78.228 ns |      4.288 ns |
|           RandomAllAccessIntOption |       100 |   1,606.28 ns |     778.857 ns |     42.692 ns |
|         RandomAllAccessFloatOption |       100 |   1,727.67 ns |     100.653 ns |      5.517 ns |
|          RandomAllAccessBoolOption |       100 |   1,498.88 ns |     839.289 ns |     46.004 ns |
|     RandomAllAccessSelectionOption |       100 |   1,517.24 ns |     215.556 ns |     11.815 ns |
|         RandoAllmAccessMixedOption |       100 |   2,632.78 ns |     514.388 ns |     28.195 ns |
|                    IntOptionAccess |       100 |      19.59 ns |      10.693 ns |      0.586 ns |
|                  FloatOptionAccess |       100 |      21.09 ns |       1.879 ns |      0.103 ns |
|                   BoolOptionAccess |       100 |      18.53 ns |       3.761 ns |      0.206 ns |
|              SelectionOptionAccess |       100 |      18.92 ns |       5.158 ns |      0.283 ns |
|                  MixedOptionAccess |       100 |      13.11 ns |       3.308 ns |      0.181 ns |
|       **SequentialAllAccessIntOption** |       **500** |   **7,552.63 ns** |   **1,225.397 ns** |     **67.168 ns** |
|     SequentialAllAccessFloatOption |       500 |   8,468.96 ns |     664.252 ns |     36.410 ns |
|      SequentialAllAccessBoolOption |       500 |   7,016.22 ns |   1,578.025 ns |     86.497 ns |
| SequentialAllAccessSelectionOption |       500 |   7,449.18 ns |   2,561.579 ns |    140.409 ns |
|     SequentialAllAccessMixedOption |       500 |   7,597.50 ns |     328.032 ns |     17.981 ns |
|           RandomAllAccessIntOption |       500 |   8,766.92 ns |   2,495.107 ns |    136.765 ns |
|         RandomAllAccessFloatOption |       500 |   9,243.63 ns |   1,727.081 ns |     94.667 ns |
|          RandomAllAccessBoolOption |       500 |   7,937.71 ns |   1,551.858 ns |     85.063 ns |
|     RandomAllAccessSelectionOption |       500 |   8,072.21 ns |   1,722.225 ns |     94.401 ns |
|         RandoAllmAccessMixedOption |       500 |  15,847.85 ns |   5,064.994 ns |    277.629 ns |
|                    IntOptionAccess |       500 |      18.92 ns |       7.394 ns |      0.405 ns |
|                  FloatOptionAccess |       500 |      20.77 ns |       3.843 ns |      0.211 ns |
|                   BoolOptionAccess |       500 |      18.46 ns |       6.377 ns |      0.350 ns |
|              SelectionOptionAccess |       500 |      18.83 ns |       0.882 ns |      0.048 ns |
|                  MixedOptionAccess |       500 |      14.91 ns |       1.309 ns |      0.072 ns |
|       **SequentialAllAccessIntOption** |      **1000** |  **14,896.43 ns** |   **2,313.904 ns** |    **126.833 ns** |
|     SequentialAllAccessFloatOption |      1000 |  17,219.85 ns |   8,856.190 ns |    485.438 ns |
|      SequentialAllAccessBoolOption |      1000 |  13,970.66 ns |   2,470.951 ns |    135.441 ns |
| SequentialAllAccessSelectionOption |      1000 |  15,827.20 ns |   2,959.306 ns |    162.210 ns |
|     SequentialAllAccessMixedOption |      1000 |  15,265.12 ns |   8,281.894 ns |    453.959 ns |
|           RandomAllAccessIntOption |      1000 |  18,826.31 ns |   2,349.205 ns |    128.768 ns |
|         RandomAllAccessFloatOption |      1000 |  19,863.42 ns |   2,388.084 ns |    130.899 ns |
|          RandomAllAccessBoolOption |      1000 |  15,888.40 ns |     998.214 ns |     54.715 ns |
|     RandomAllAccessSelectionOption |      1000 |  17,385.20 ns |   8,709.668 ns |    477.406 ns |
|         RandoAllmAccessMixedOption |      1000 |  32,596.59 ns |   8,785.397 ns |    481.557 ns |
|                    IntOptionAccess |      1000 |      19.73 ns |      14.506 ns |      0.795 ns |
|                  FloatOptionAccess |      1000 |      20.47 ns |       5.036 ns |      0.276 ns |
|                   BoolOptionAccess |      1000 |      18.69 ns |       1.994 ns |      0.109 ns |
|              SelectionOptionAccess |      1000 |      18.86 ns |       5.731 ns |      0.314 ns |
|                  MixedOptionAccess |      1000 |      14.61 ns |       3.831 ns |      0.210 ns |
|       **SequentialAllAccessIntOption** |      **5000** |  **83,104.11 ns** |  **19,427.287 ns** |  **1,064.875 ns** |
|     SequentialAllAccessFloatOption |      5000 |  90,152.84 ns |  12,071.600 ns |    661.685 ns |
|      SequentialAllAccessBoolOption |      5000 |  73,635.25 ns |  31,202.811 ns |  1,710.331 ns |
| SequentialAllAccessSelectionOption |      5000 | 122,548.87 ns |  14,874.245 ns |    815.308 ns |
|     SequentialAllAccessMixedOption |      5000 | 107,513.75 ns |  26,157.824 ns |  1,433.799 ns |
|           RandomAllAccessIntOption |      5000 | 135,103.68 ns |  12,584.722 ns |    689.811 ns |
|         RandomAllAccessFloatOption |      5000 | 150,494.88 ns |  65,393.378 ns |  3,584.432 ns |
|          RandomAllAccessBoolOption |      5000 | 103,121.92 ns |  26,860.501 ns |  1,472.315 ns |
|     RandomAllAccessSelectionOption |      5000 | 152,345.95 ns |  11,111.954 ns |    609.084 ns |
|         RandoAllmAccessMixedOption |      5000 | 217,303.84 ns |  28,378.774 ns |  1,555.536 ns |
|                    IntOptionAccess |      5000 |      18.81 ns |       0.658 ns |      0.036 ns |
|                  FloatOptionAccess |      5000 |      20.42 ns |       3.252 ns |      0.178 ns |
|                   BoolOptionAccess |      5000 |      18.49 ns |       5.100 ns |      0.280 ns |
|              SelectionOptionAccess |      5000 |      19.67 ns |       1.454 ns |      0.080 ns |
|                  MixedOptionAccess |      5000 |      15.04 ns |       0.865 ns |      0.047 ns |
|       **SequentialAllAccessIntOption** |     **10000** | **169,551.17 ns** |  **32,279.326 ns** |  **1,769.339 ns** |
|     SequentialAllAccessFloatOption |     10000 | 186,286.89 ns |  53,587.798 ns |  2,937.328 ns |
|      SequentialAllAccessBoolOption |     10000 | 144,430.19 ns |  33,391.927 ns |  1,830.324 ns |
| SequentialAllAccessSelectionOption |     10000 | 246,404.98 ns |  70,256.308 ns |  3,850.985 ns |
|     SequentialAllAccessMixedOption |     10000 | 253,177.78 ns |  50,824.981 ns |  2,785.889 ns |
|           RandomAllAccessIntOption |     10000 | 318,370.93 ns | 142,487.799 ns |  7,810.237 ns |
|         RandomAllAccessFloatOption |     10000 | 331,810.64 ns |  13,904.155 ns |    762.134 ns |
|          RandomAllAccessBoolOption |     10000 | 246,168.27 ns |  28,725.288 ns |  1,574.530 ns |
|     RandomAllAccessSelectionOption |     10000 | 354,321.39 ns | 101,063.002 ns |  5,539.604 ns |
|         RandoAllmAccessMixedOption |     10000 | 578,129.13 ns | 245,598.731 ns | 13,462.095 ns |
|                    IntOptionAccess |     10000 |      18.81 ns |       1.154 ns |      0.063 ns |
|                  FloatOptionAccess |     10000 |      20.79 ns |       0.675 ns |      0.037 ns |
|                   BoolOptionAccess |     10000 |      18.44 ns |       2.905 ns |      0.159 ns |
|              SelectionOptionAccess |     10000 |      18.56 ns |       1.470 ns |      0.081 ns |
|                  MixedOptionAccess |     10000 |      13.79 ns |       4.851 ns |      0.266 ns |
