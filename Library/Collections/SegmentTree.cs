using System;
namespace CompLib.Collections {
	using RmQ = SegmentTree<long, MinData>;
	using RMQ = SegmentTree<long, MaxData>;
	#region SegTree Operator
	public interface IData<T> {
		T Merge(T l, T r);
		T Identity { get; }
	}
	#endregion
	#region Segment Tree

	public class SegmentTree<T, U>
	   where U : struct, IData<T> {
		int sz;
		int n;
		T[] data;
		U op;
		public SegmentTree(int size) {
			sz = size;
			n = 1;
			while (n < size) n *= 2;
			data = new T[n * 2];
			for (int i = 0; i < data.Length; i++)
				data[i] = op.Identity;
		}
		public SegmentTree(T[] a) {
			sz = a.Length;
			n = 1;
			while (n < sz) n *= 2;
			data = new T[n * 2];
			for (int i = 0; i < n; i++)
				data[i + n] = (i < a.Length) ? a[i] : op.Identity;
			for (int i = n - 1; i >= 0; i--)
				data[i] = op.Merge(data[i * 2], data[i * 2 + 1]);
		}
		public void Update(int k, T v) {
			k += n;
			data[k] = v;
			for (k = k / 2; k > 0; k /= 2)
				data[k] = op.Merge(data[k * 2], data[k * 2 + 1]);

		}
		public T Query(int a, int b) {
			T L = op.Identity, R = op.Identity;
			for (a += n, b += n; a < b; a /= 2, b /= 2) {
				if ((a & 1) == 1) L = op.Merge(L, data[a++]);
				if ((b & 1) == 1) R = op.Merge(data[--b], R);
			}
			return op.Merge(L, R);
		}
		public T[] Items {
			get {
				var ret = new T[sz];
				for (int i = 0; i < sz; i++)
					ret[i] = data[i + n];
				return ret;
			}
		}

	}
	#endregion
	#region RmQ
	public struct MinData : IData<long> {
		public long Identity { get { return long.MaxValue; } }
		public long Merge(long l, long r) { return Math.Min(l, r); }
	}
	#endregion
	#region RMQ

	public struct MaxData : IData<long> {
		public long Identity { get { return long.MinValue; } }
		public long Merge(long l, long r) { return Math.Max(l, r); }
	}
	#endregion


	#region Lazy Propagation
	public interface ILazyData<T1, T2> {
		T1 Merge(T1 l, T1 r);
		T1 Identity { get; }
		T1 InitValue { get; }
		T1 Apply(int l, int r, T1 val, T2 x);
		T2 Push(T2 val, T2 x);
		T2 Zero { get; }
	}
	#endregion
	#region LazyPropagation Segment Tree
	public class LazyPropagationSegmentTree<T1, T2, U>
		where U : struct, ILazyData<T1, T2> {
		int sz;
		int n;
		T1[] data;
		T2[] lazy;
		bool[] flag;
		U op;
		public LazyPropagationSegmentTree(int size) {
			sz = size;
			n = 1;
			while (n < sz)
				n <<= 1;
			data = new T1[n * 2];
			lazy = new T2[n * 2];
			flag = new bool[n * 2];
			for (int i = 1; i < n * 2; i++) {
				data[i] = op.InitValue;
				lazy[i] = op.Zero;
			}
		}
		public LazyPropagationSegmentTree(T1[] a) {

			sz = a.Length;
			n = 1;
			while (n < sz)
				n <<= 1;
			data = new T1[n * 2];
			lazy = new T2[n * 2];
			flag = new bool[n * 2];
			for (int i = 0; i < n; i++) {
				if (i < sz)
					data[i + n] = a[i];
				else data[i + n] = op.InitValue;
				lazy[i + n] = op.Zero;
			}
			for (int i = n - 1; i >= 1; i--) {
				data[i] = op.Merge(data[i * 2], data[i * 2 + 1]);
				lazy[i] = op.Zero;

			}
		}
		private void lazyEval(int k, int a, int b) {
			if (!flag[k])
				return;
			push(a, (a + b) / 2, lazy[k], k * 2, a, (a + b) / 2);
			push((a + b) / 2, b, lazy[k], k * 2 + 1, (a + b) / 2, b);
			lazy[k] = op.Zero;
			flag[k] = false;
		}
		private void eval(int k) {
			data[k] = op.Merge(data[k * 2], data[k * 2 + 1]);
		}

		public void Push(int a, int b, T2 v) {
			push(a, b, v, 1, 0, n);
		}
		private void push(int a, int b, T2 x, int k, int l, int r) {
			if (r <= a || b <= l)
				return;
			else if (a <= l && r <= b) {
				flag[k] = true;
				lazy[k] = op.Push(lazy[k], x);
				data[k] = op.Apply(l, r, data[k], x);
			}
			else {
				lazyEval(k, l, r);
				push(a, b, x, k << 1, l, (l + r) >> 1);
				push(a, b, x, (k << 1) + 1, (l + r) >> 1, r);
				eval(k);
			}
		}
		public T1 Query(int a, int b) { return query(a, b, 1, 0, n); }
		private T1 query(int a, int b, int k, int l, int r) {
			if (r <= a || b <= l)
				return op.Identity;
			if (a <= l && r <= b)
				return data[k];
			else {
				lazyEval(k, l, r);
				var vl = query(a, b, k << 1, l, (l + r) >> 1);
				var vr = query(a, b, (k << 1) + 1, (l + r) >> 1, r);
				eval(k);
				return op.Merge(vl, vr);
			}
		}
		public T1[] Items {
			get {
				var ret = new T1[sz];
				for (int i = 0; i < ret.Length; i++)
					ret[i] = Query(i, i + 1);
				return ret;
			}
		}
	}
	#endregion

	#region StarrySkyTree
	public class StarrySkyTree : LazyPropagationSegmentTree<long, long, StarySky> {
		public StarrySkyTree(long[] a) : base(a) { }
	}
	public struct StarySky : ILazyData<long, long> {
		public long Identity { get { return long.MinValue / 4; } }
		public long InitValue { get { return 0; } }
		public long Zero { get { return 0; } }
		public long Apply(int l, int r, long val, long x) { return val + x; }
		public long Merge(long l, long r) { return Math.Max(l, r); }
		public long Push(long val, long x) { return val + x; }
	}
	#endregion
	#region Set Sum Tree
	public class SetSumTree : LazyPropagationSegmentTree<long, long, SetSum> {
		public SetSumTree(int size) : base(size) { }
	}
	public struct SetSum : ILazyData<long, long> {
		public long Identity { get { return 0; } }
		public long InitValue { get { return 0; } }
		public long Zero { get { return 0; } }
		public long Apply(int l, int r, long val, long x) { return (r - l) * x; }
		public long Merge(long l, long r) { return l + r; }
		public long Push(long val, long x) { return x; }
	}
	#endregion
}
