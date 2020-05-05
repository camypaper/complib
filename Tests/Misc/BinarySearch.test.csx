// #load "../../Library/Misc/BinarySearch.cs"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/7/DPL/1/DPL_1_D

using System;
using System.Collections.Generic;

// begin here
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
public static int LowerBound<T>(this IList<T> a, T v, Comparison<T> f) { return lb(a, v, Comparer<T>.Create(f)); }
public static int LowerBound<T>(this IList<T> a, T v) { return lb(a, v, Comparer<T>.Default); }
public static int UpperBound<T>(this IList<T> a, T v, Comparison<T> cmp) { return ub(a, v, Comparer<T>.Create(cmp)); }
public static int UpperBound<T>(this IList<T> a, T v) { return ub(a, v, Comparer<T>.Default); }
// end here

var n = int.Parse(Console.ReadLine());
var ans = new long[n + 5];
for (int i = 0; i < ans.Length; i++) ans[i] = long.MaxValue;
for (int i = 0; i < n; i++) {
	var v = int.Parse(Console.ReadLine());
	ans[ans.LowerBound(v)] = v;
}
Console.Error.WriteLine(string.Join(" ", ans));
for (int i = ans.Length - 1; i >= 0; i--)
	if (ans[i] != long.MaxValue) {
		Console.WriteLine(i + 1);
		break;
	}
