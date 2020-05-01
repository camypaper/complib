#load "../../Library/Strings/Z.csx"
#pragma warning disable 1633
#pragma PROBLEM https://judge.yosupo.jp/problem/zalgorithm
#pragma warning restore

using System;
using System.Collections.Generic;

var s = Console.ReadLine();
var a = stringEx.Z(s.ToCharArray());
Console.WriteLine(string.Join(' ', a));
