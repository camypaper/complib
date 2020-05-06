using System;
using System.Collections.Generic;
namespace CompLib.Misc {

	#region BinarySearch List<T>
	static public partial class Algorithm {
		static int lb<T>(List<T> a, T v, IComparer<T> cmp) {
			int l = 0, r = a.Count - 1;
			while (l <= r) {
				var m = (l + r) >> 1;
				var res = cmp.Compare(a[m], v);
				if (res < 0) l = m + 1;
				else r = m - 1;
			}
			return l;
		}
		static int ub<T>(List<T> a, T v, IComparer<T> cmp) {
			int l = 0, r = a.Count - 1;
			while (l <= r) {
				var m = (l + r) >> 1;
				var res = cmp.Compare(a[m], v);
				if (res <= 0) l = m + 1;
				else r = m - 1;
			}
			return l;
		}
		public static int LowerBound<T>(this List<T> a, T v, Comparison<T> f) { return lb(a, v, Comparer<T>.Create(f)); }
		public static int LowerBound<T>(this List<T> a, T v) { return lb(a, v, Comparer<T>.Default); }
		public static int UpperBound<T>(this List<T> a, T v, Comparison<T> cmp) { return ub(a, v, Comparer<T>.Create(cmp)); }
		public static int UpperBound<T>(this List<T> a, T v) { return ub(a, v, Comparer<T>.Default); }
	}
	#endregion

	#region BinarySearch T[]
	static public partial class Algorithm {
		static int lb<T>(T[] a, T v, IComparer<T> cmp) {
			int l = 0, r = a.Length - 1;
			while (l <= r) {
				var m = (l + r) >> 1;
				var res = cmp.Compare(a[m], v);
				if (res < 0) l = m + 1;
				else r = m - 1;
			}
			return l;
		}
		static int ub<T>(T[] a, T v, IComparer<T> cmp) {
			int l = 0, r = a.Length - 1;
			while (l <= r) {
				var m = (l + r) >> 1;
				var res = cmp.Compare(a[m], v);
				if (res <= 0) l = m + 1;
				else r = m - 1;
			}
			return l;
		}
		public static int LowerBound<T>(this T[] a, T v, Comparison<T> f) { return lb(a, v, Comparer<T>.Create(f)); }
		public static int LowerBound<T>(this T[] a, T v) { return lb(a, v, Comparer<T>.Default); }
		public static int UpperBound<T>(this T[] a, T v, Comparison<T> cmp) { return ub(a, v, Comparer<T>.Create(cmp)); }
		public static int UpperBound<T>(this T[] a, T v) { return ub(a, v, Comparer<T>.Default); }
	}
	#endregion
}
