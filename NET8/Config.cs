﻿using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;

namespace NET8;

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddExporter(MarkdownExporter.GitHub); // ベンチマーク結果を書く時に出力させとくとベンリ
        // Add(MemoryDiagnoser.Default);

        // ShortRunを使うとサクッと終わらせられる、デフォルトだと本気で長いので短めにしとく。
        // ShortRunは LaunchCount=1  TargetCount=3 WarmupCount = 3 のショートカット
        AddJob(Job.ShortRun);
    }
}
