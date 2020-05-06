using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using CompLib.Misc;
namespace CompLib.Benchmark {
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
			foreach (var x in b) ret ^= _Algorithm.LowerBound(a, x);
			return ret;
		}
		[Benchmark]
		public int arrayBinarySearch() {
			int ret = 0;
			foreach (var x in b) ret ^= Algorithm.LowerBound(a, x);
			return ret;
		}
		[Benchmark]
		public int listBinarySearch() {
			int ret = 0;
			foreach (var x in b) ret ^= Algorithm.LowerBound(c, x);
			return ret;
		}


		static public class _Algorithm {
			static int lb<T>(IList<T> a, T v, IComparer<T> cmp) {
				int l = 0, r = a.Count - 1;
				while (l <= r) {
					var m = (l + r) >> 1;
					var res = cmp.Compare(a[m], v);
					if (res < 0) l = m + 1;
					else r = m - 1;
				}
				return l;
			}
			static int ub<T>(IList<T> a, T v, IComparer<T> cmp) {
				int l = 0, r = a.Count - 1;
				while (l <= r) {
					var m = (l + r) >> 1;
					var res = cmp.Compare(a[m], v);
					if (res <= 0) l = m + 1;
					else r = m - 1;
				}
				return l;
			}
			public static int LowerBound<T>(IList<T> a, T v, Comparison<T> f) { return lb(a, v, Comparer<T>.Create(f)); }
			public static int LowerBound<T>(IList<T> a, T v) { return lb(a, v, Comparer<T>.Default); }
			public static int UpperBound<T>(IList<T> a, T v, Comparison<T> cmp) { return ub(a, v, Comparer<T>.Create(cmp)); }
			public static int UpperBound<T>(IList<T> a, T v) { return ub(a, v, Comparer<T>.Default); }
		}
	}
}
