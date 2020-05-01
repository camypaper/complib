using System;
#region Z algorithm
static public partial class stringEx {
	/// <summary> <paramref name="s"/> と <paramref name="s"/>[i:] の最長共通接頭辞を O(|<paramref name="s"/>|) で求める。</summary>
	static public int[] Z<T>(T[] s)
		where T : IEquatable<T> {
		var a = new int[s.Length];
		a[0] = s.Length;
		int i = 1, j = 0;
		while (i < s.Length) {
			while (i + j < s.Length && s[j].Equals(s[i + j])) ++j;
			a[i] = j;
			if (j == 0) { ++i; continue; }
			int k = 1;
			while (i + k < s.Length && k + a[k] < j) { a[i + k] = a[k]; ++k; }
			i += k; j -= k;
		}
		return a;
	}
}
#endregion
