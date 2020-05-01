#load "../../Library/Graph/HLTree.cs"
#pragma PROBLEM https://judge.yosupo.jp/problem/lca

using System;
using System.Collections.Generic;
using CompLib.Graph;

var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, q) = (nq[0], nq[1]);
var hl = new HLTree(n);
for (int i = 0; i < n - 1; i++) {
	var uv = Console.ReadLine().Split().Select(int.Parse).ToArray();
	var (u, v) = (uv[0], uv[1]);
	hl.AddEdge(u, v);
}
hl.Build(0);
for (int i = 0; i < q; i++) {
	var uv = Console.ReadLine().Split().Select(int.Parse).ToArray();
	var (u, v) = (uv[0], uv[1]);
	Console.WriteLine(hl.LCA(u, v));
}
