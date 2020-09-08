#r "./../../bin/complib.dll"
/* dependency
#load "../../Library/Strings/Z.cs"
//*/
#pragma PROBLEM https://judge.yosupo.jp/problem/zalgorithm
#load "../VerifyTestAttribute.csx"
using System;
using System.Collections.Generic;
using CompLib.Strings;

[VerifyType(typeof(StringEx))]
var s = Console.ReadLine();
var a = StringEx.Z(s.ToCharArray());
Console.WriteLine(string.Join(' ', a));
