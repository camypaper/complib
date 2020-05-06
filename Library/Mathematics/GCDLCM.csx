using System;

#region GCD LCM
public static partial class MathEx {
	/// <summary>
	/// GCD(n,m) を O(log N) で計算します
	/// </summary>
	public static int GCD(int n, int m) { return (int)GCD((long)n, m); }

	/// <summary>
	/// GCD(n,m) を O(log N) で計算します
	/// </summary>
	public static long GCD(long n, long m) {
		n = Math.Abs(n);
		m = Math.Abs(m);
		while (n != 0) {
			m %= n;
			if (m == 0) return n;
			n %= m;
		}
		return m;
	}

	/// <summary>
	/// LCM(n,m) を O(log N) で計算します
	/// </summary>
	public static long LCM(long n, long m) { return (n / GCD(n, m)) * m; }
}
#endregion

#region Extended Euclid
static partial class MathEx {
	/// <summary>
	/// g = GCD(a,b) を求め，ax+by = g なる (x,y) も求める
	/// </summary>
	static public long ExGCD(long a, long b, out long x, out long y) {
		a = Math.Abs(a);
		b = Math.Abs(b);
		x = 0;
		var u = y = 1;
		var v = x = 0;
		while (a > 0) {
			var q = b / a;
			{ var t = x - q * u; x = u; u = t; }
			{ var t = y - q * v; y = v; v = t; }
			{ var t = b - q * a; b = a; a = t; }
		}
		return b;
	}
}
#endregion
