#r "./../../bin/complib.dll"
/* dependency
#load "../../Library/Collections/PriorityQueue.cs"
//*/
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/9/ALDS1_9_C
#load "../VerifyTestAttribute.csx"
using System;
using System.Collections.Generic;
using CompLib.Collections;

[VerifyType(typeof(PriorityQueue<int>))]
var pq = new PriorityQueue<int>((l, r) => r.CompareTo(l));
for (; ; ) {
	var s = Console.ReadLine();
	if (s == "end") return;
	else if (s == "extract") {
		Console.WriteLine(pq.Dequeue());
	}
	else {
		var v = s.Split().Skip(1).Select(int.Parse).First();
		pq.Enqueue(v);
	}
}
