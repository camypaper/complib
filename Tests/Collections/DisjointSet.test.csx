#r "./../../bin/complib.dll"
/* dependency
#load "../../Library/Collections/DisjointSet.cs"
//*/
#pragma PROBLEM https://judge.yosupo.jp/problem/unionfind

using System;
using System.Collections.Generic;
using CompLib.Collections;

int[] read() => Console.ReadLine().Split().Select(int.Parse).ToArray();

var nq = read();
var (n, q) = (nq[0], nq[1]);
var set = new DisjointSet(n);
for (int _ = 0; _ < q; _++) {
	var query = read();
	var (t, u, v) = (query[0], query[1], query[2]);
	if (t == 0) set.Unite(u, v);
	else Console.WriteLine(set.Same(u, v) ? 1 : 0);
}
