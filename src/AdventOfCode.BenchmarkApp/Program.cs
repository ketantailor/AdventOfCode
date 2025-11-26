using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

var config = ManualConfig.Create(DefaultConfig.Instance);
config.AddDiagnoser(MemoryDiagnoser.Default);
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);