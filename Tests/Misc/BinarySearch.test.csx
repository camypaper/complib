#r "./../../bin/complib.dll"
/* dependency
#load "../../Library/Misc/BinarySearch.cs"
//*/
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/7/DPL/1/DPL_1_D
#load "../VerifyTestAttribute.csx"
using System;
using System.Collections.Generic;
using CompLib.Misc;

[VerifyType(typeof(Algorithm))]
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
