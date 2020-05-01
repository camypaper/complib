#load "../../Library/Mathematics/GCDLCM.csx"
#pragma PROBLEM "https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/all/DSL_1_A"

using System;
using System.Collections.Generic;

var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
long x, y;
MathEx.ExGCD(a[0], a[1], out x, out y);
Console.WriteLine($"{x} {y}");
