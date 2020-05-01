#load "../../Library/Mathematics/GCDLCM.csx"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/all/NTL_1_E

using System;
using System.Collections.Generic;

var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
long x, y;
if (a[0] == a[1]) Console.WriteLine("0 1");
else {
	MathEx.ExGCD(a[0], a[1], out x, out y);
	Console.WriteLine($"{x} {y}");
}
