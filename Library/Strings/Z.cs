using System;
namespace CompLib.Strings {
	#region Z algorithm
	static public partial class StringEx {
		/// <summary> Calculate <c>LCP(s,s[i,N])</c> for all <c>i</c>. Time complexity: <c>O(N)</summary>
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
}
