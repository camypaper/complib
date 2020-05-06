using Number = System.Int64;

namespace CompLib.Collections {

	#region Fenwick
	public class FenwickTree {
		int n;
		Number[] bit;
		int max = 1;
		public FenwickTree(int size) {
			n = size; bit = new Number[n + 1];
			while ((max << 1) <= n) max <<= 1;
		}
		/// <summary>Sum of <c>bit[i, j]</c>. Time complexity: <c>O(log N)</c></summary>
		public Number this[int i, int j] { get { return this[j] - this[i - 1]; } }
		/// <summary>Sum of <c>bit[0, i]</c>. Time complexity: <c>O(log N)</c></summary>
		public Number this[int i] { get { Number s = 0; for (; i > 0; i -= i & -i) s += bit[i]; return s; } }

		/// <summary>Returns the smallest <c>i</c> such that <c>bit[0, i] >= w</c>. <c>bit[i]</c> must be non-negative. Time complexity: <c>O(log N)</c></summary>
		public int LowerBound(Number w) {
			if (w <= 0) return 0;
			int x = 0;
			for (int k = max; k > 0; k >>= 1)
				if (x + k <= n && bit[x + k] < w) {
					w -= bit[x + k];
					x += k;
				}
			return x + 1;
		}
		/// <summary>Add <paramref name="v"/> to <c>bit[i]</c>(1-indexed). Time complexity: <c>O(log N)</c></summary>
		public void Add(int i, Number v) {
			for (; i < bit.Length; i += i & -i) bit[i] += v;
		}
		/// <summary>Enumerate <c>bit</c>. Time complexity: <c>O(N log N)</c></summary>
		public Number[] Items {
			get {
				var ret = new Number[n + 1];
				for (int i = 0; i < ret.Length; i++)
					ret[i] = this[i, i];
				return ret;
			}
		}
	}
	#endregion

	#region RangeAddFenwick
	public class RangeAddFenwickTree {
		int n;
		FenwickTree a, b;
		public RangeAddFenwickTree(int n) {
			this.n = n;
			a = new FenwickTree(n);
			b = new FenwickTree(n);
		}
		/// <summary>Add <paramref name="v"/> to <c>bit[i, j]</c>(1-indexed). Time complexity: <c>O(log N)</c></summary>
		public void Add(int i, int j, Number v) {
			a.Add(i, -(i - 1) * v); a.Add(j + 1, j * v);
			b.Add(i, v); b.Add(j + 1, -v);
		}
		/// <summary>Sum of <c>bit[0, i]</c>. Time complexity: <c>O(log N)</c></summary>
		public Number this[int i] { get { return a[i] + b[i] * i; } }
		/// <summary>Sum of <c>bit[i, j]</c>. Time complexity: <c>O(log N)</c></summary>
		public Number this[int i, int j] { get { return this[j] - this[i - 1]; } }
		/// <summary>Enumerate <c>bit</c>. Time complexity: <c>O(N log N)</c></summary>
		public Number[] Items {
			get {
				var ret = new Number[n + 1];
				for (int i = 0; i < ret.Length; i++)
					ret[i] = this[i, i];
				return ret;
			}
		}
	}
	#endregion

}
