#r "./../../bin/complib.dll"
/* dependency
#load "../../Library/Graph/HLTree.cs"
//*/
#pragma PROBLEM https://judge.yosupo.jp/problem/lca
#load "../VerifyTestAttribute.csx"
using System;
using System.Collections.Generic;
using CompLib.Graph;

[VerifyType(typeof(HLTree))]
var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, q) = (nq[0], nq[1]);
var hl = new HLTree(n);

var par = Console.ReadLine().Split().Select(int.Parse).ToArray();
for (int i = 0; i < par.Length; i++) {
	hl.AddEdge(par[i], i + 1);
}
hl.Build(0);
for (int i = 0; i < q; i++) {
	var uv = Console.ReadLine().Split().Select(int.Parse).ToArray();
	var (u, v) = (uv[0], uv[1]);
	Console.WriteLine(hl.LCA(u, v));
}
