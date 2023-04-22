// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;

using NET7.Benchmark;

var switcher = new BenchmarkSwitcher(new[]
{
    typeof(OptionAccessBenchmark)
});

args = new string[] { "0" };
switcher.Run(args);
