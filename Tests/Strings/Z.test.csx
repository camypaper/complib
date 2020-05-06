#r "./../../bin/complib.dll"
#pragma PROBLEM https://judge.yosupo.jp/problem/zalgorithm

using System;
using System.Collections.Generic;
using CompLib.Strings;

var s = Console.ReadLine();
var a = stringEx.Z(s.ToCharArray());
Console.WriteLine(string.Join(' ', a));
