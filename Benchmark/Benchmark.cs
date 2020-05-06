using BenchmarkDotNet.Running;

namespace CompLib.Benchmark {
	public class Benchmark {
		static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Benchmark).Assembly).Run(args);
	}
}
