#load "../../Library/Strings/Z.csx"
#pragma PROBLEM https://judge.yosupo.jp/problem/zalgorithm

using System;
using System.Collections.Generic;

var s = Console.ReadLine();
var a = stringEx.Z(s.ToCharArray());
Console.WriteLine(string.Join(' ', a));
