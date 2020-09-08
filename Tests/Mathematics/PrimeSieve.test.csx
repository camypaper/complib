#r "./../../bin/complib.dll"
/* dependency
#load "../../Library/Mathematics/PrimeSieve.cs"
//*/
#pragma PROBLEM https://judge.yosupo.jp/problem/enumerate_primes
#load "../VerifyTestAttribute.csx"
using System;
using System.Collections.Generic;
using CompLib.Mathematics;

[VerifyType(typeof(MathEx))]
var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, a, b) = (nab[0], nab[1], nab[2]);

var cnt = 0;

var ans = new List<int>();
foreach (var p in MathEx.SieveList(n)) {
	if (cnt % a == b) ans.Add(p);
	cnt++;
}

Console.WriteLine($"{cnt} {ans.Count}");
Console.WriteLine(String.Join(' ', ans));
