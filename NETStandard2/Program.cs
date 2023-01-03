using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;
using NETStandard2.Benchmark;
using System;

namespace NETStandard2
{
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            AddExporter(MarkdownExporter.GitHub); // ベンチマーク結果を書く時に出力させとくとベンリ
        }
    }

    internal class Program
    {
        // シード値をとりあえずセットしておく
        public static Random Rng = new Random(0);

        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(OptionAccessBenchmark)
            });

            args = new string[] { "0" };
            switcher.Run(args);
        }
    }
}
