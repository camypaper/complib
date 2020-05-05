using BenchmarkDotNet.Running;

namespace Complib.Benchmark {
	public class Benchmark {
		static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Benchmark).Assembly).Run(args);
	}
}
