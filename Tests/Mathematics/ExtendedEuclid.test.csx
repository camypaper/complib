#load "../../Library/Mathematics/GCDLCM.csx"
#pragma PROBLEM "https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/1/NTL_1_E"

using System;
using System.Collections.Generic;

var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
long x, y;
MathEx.ExGCD(a[0], a[1], out x, out y);
Console.WriteLine($"{x} {y}");
