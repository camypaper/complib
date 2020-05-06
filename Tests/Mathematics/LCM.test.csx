#r "./../../bin/complib.dll"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/all/NTL_1_C

using System;
using System.Collections.Generic;

var n = int.Parse(Console.ReadLine());
var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
var ans = 1L;
foreach (var x in a) ans = MathEx.LCM(ans, x);
Console.WriteLine(ans);
