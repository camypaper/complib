using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Complib.Benchmark {
	[MinColumn, MaxColumn, MeanColumn, MedianColumn]
	[MarkdownExporterAttribute.GitHub]
	public class BinarySearchBenchmark {
		private int[] a, b;
		private List<int> c;
		Random rnd;
		public BinarySearchBenchmark() {
			rnd = new Random(0);
			a = new int[10000000];
			for (int i = 0; i < a.Length; i++) a[i] = rnd.Next();
			Array.Sort(a);
			c = a.ToList();
			b = new int[10000000];
			for (int i = 0; i < b.Length; i++) b[i] = rnd.Next();
		}
		[Benchmark(Baseline = true)]
		public int iListBinarySearch() {
			int ret = 0;
			foreach (var x in b) ret ^= IListBinarySearch.LowerBound(a, x);
			return ret;
		}
		[Benchmark]
		public int arrayBinarySearch() {
			int ret = 0;
			foreach (var x in b) ret ^= ArrayBinarySearch.LowerBound(a, x);
			return ret;
		}
		[Benchmark]
		public int listBinarySearch() {
			int ret = 0;
			foreach (var x in b) ret ^= ListBinarySearch.LowerBound(c, x);
			return ret;
		}

	}
}
