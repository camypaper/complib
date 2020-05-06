#r "./../../bin/complib.dll"
/* dependency
#load "../../Library/Collections/Fenwick.cs"
//*/
#pragma PROBLEM https://judge.yosupo.jp/problem/point_add_range_sum

using System;
using System.Collections.Generic;
using CompLib.Collections;

int[] read() => Console.ReadLine().Split().Select(int.Parse).ToArray();

var nq = read();
var (n, q) = (nq[0], nq[1]);
var fenwick = new FenwickTree(n);
var a = read();
for (int i = 0; i < n; i++) fenwick.Add(i + 1, a[i]);
for (int _ = 0; _ < q; _++) {
	var query = read();
	var (t, x, y) = (query[0], query[1], query[2]);
	if (t == 0) fenwick.Add(x + 1, y);
	else Console.WriteLine(fenwick[x + 1, y]);
}
