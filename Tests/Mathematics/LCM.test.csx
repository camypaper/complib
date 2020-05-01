#load "../../Library/Mathematics/GCDLCM.csx"
#pragma PROBLEM "https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/all/DSL_1_A"

using System;
using System.Collections.Generic;

var n = int.Parse(Console.ReadLine());
var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
var ans = 1L;
foreach (var x in a) ans = MathEx.LCM(ans, x);
Console.WriteLine(ans);
