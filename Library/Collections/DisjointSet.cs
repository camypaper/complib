using System.Collections.Generic;

namespace CompLib.Collections {

	#region Disjoint Set
	public class DisjointSet {
		int[] par;
		byte[] rank;
		public DisjointSet(int N) {
			par = new int[N];
			rank = new byte[N];
			for (int i = 0; i < N; i++) { par[i] = -1; }
		}
		/// <summary>Find root of <c>id</c>. Time complexity: <c>O(α(N))</c></summary>
		public int this[int id] {
			get {
				if ((par[id] < 0)) return id;
				return par[id] = this[par[id]];
			}
		}
		/// <summary>Unite <paramref name="x"/> and <paramref name="y"/>. Time complexity: <c>O(α(N))</c></summary>
		public bool Unite(int x, int y) {
			x = this[x]; y = this[y];
			if (x == y) return false;
			if (rank[x] < rank[y]) { var tmp = x; x = y; y = tmp; }
			par[x] += par[y];
			par[y] = x;
			if (rank[x] == rank[y])
				rank[x]++;
			return true;
		}
		/// <summary>Size of <paramref name="x"/>. Time complexity: <c>O(α(N))</c></summary>
		public int Size(int x) { return -par[this[x]]; }
		public bool Same(int x, int y) { return this[x] == this[y]; }

	}
	#endregion

	#region RollbackDisjointSet
	public class RollbackDisjointSet {
		int n;
		int[] par;
		Stack<int> history = new Stack<int>();
		public RollbackDisjointSet(int N) {
			n = N;
			par = new int[n];
			for (int i = 0; i < n; i++) par[i] = -1;
		}
		public RollbackDisjointSet(int N, int[] p, byte[] r) {
			n = N;
			par = new int[2 * N];
			for (int i = 0; i < n; i++) {
				par[i] = p[i];
				par[i + n] = r[i];
			}
		}
		public int this[int id] {
			get {
				if ((par[id] < 0)) return id;
				return this[par[id]];
			}
		}
		public bool Unite(int x, int y) {
			x = this[x]; y = this[y];
			if (x == y) return false;
			if (par[x + n] < par[y + n]) { var z = x; x = y; y = z; }
			history.Push(par[x]);
			history.Push(x);
			history.Push(par[y]);
			history.Push(y);

			par[x] += par[y];
			par[y] = x;
			if (par[x + n] == par[y + n]) {
				history.Push(par[x + n]);
				history.Push(x + n);
				par[x + n]++;
			}
			return true;
		}
		public void Back() {
			if (history.Count == 0) return;
			for (int t = history.Peek() >= n ? 3 : 2; t > 0; t--) {
				var p = history.Pop();
				var v = history.Pop();
				par[p] = v;
			}

		}
		public int Size(int x) { return -par[this[x]]; }
		public bool IsUnited(int x, int y) { return this[x] == this[y]; }

	}
	#endregion

}
