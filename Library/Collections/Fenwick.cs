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
		/// <summary>sum[a,b]</summary>
		public Number this[int i, int j] { get { return this[j] - this[i - 1]; } }
		/// <summary>sum[0,i]</summary>
		public Number this[int i] { get { Number s = 0; for (; i > 0; i -= i & -i) s += bit[i]; return s; } }
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
		/// <summary>add v to bit[i]</summary>
		public void Add(int i, Number v) {
			for (; i < bit.Length; i += i & -i) bit[i] += v;
		}
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
		/// <summary>Add V to[i,j]</summary>
		public void Add(int i, int j, Number v) {
			a.Add(i, -(i - 1) * v); a.Add(j + 1, j * v);
			b.Add(i, v); b.Add(j + 1, -v);
		}
		/// <summary>Sum [0,i]</summary>
		public Number this[int i] { get { return a[i] + b[i] * i; } }
		/// <summary>Sum [i,j]</summary>
		public Number this[int i, int j] { get { return this[j] - this[i - 1]; } }
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
