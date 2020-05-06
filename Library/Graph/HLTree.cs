using System.Collections.Generic;
namespace CompLib.Graph {

	#region HLTree
	public class HLTree {
		int n;
		public List<int>[] G;
		int[] sz, par, d;
		/// <summary><c>L[i]</c> is the position of <c>i</c> in pre-order </summary>
		public int[] L;
		int[] R, head;
		public HLTree(int N) {
			n = N;
			G = new List<int>[n];
			for (int i = 0; i < n; i++)
				G[i] = new List<int>();
			sz = new int[n];
			par = new int[n];
			d = new int[n];
			head = new int[n];
			L = new int[n];
			R = new int[n];
		}
		/// <summary>Add edge between <paramref name="u"/> and <paramref name="v"/></summary>
		public void AddEdge(int u, int v) { G[u].Add(v); G[v].Add(u); }
		/// <summary>Initialize HL decompsition</summary>
		public void Build(int root = 0) {
			dfs(root);
			int ptr = 0;
			decomposite(root, ref ptr);
		}
		void dfs(int r) {
			var iter = new int[n];
			var stack = new Stack<int>();
			stack.Push(r); d[r] = 0; par[r] = -1;
			while (stack.Count > 0) {
				var u = stack.Peek();
				var g = G[u];
				if (iter[u] < g.Count) {
					var v = g[iter[u]++];
					if (v == par[u]) continue;
					else {
						d[v] = d[u] + 1;
						par[v] = u;
						stack.Push(v);
					}
				}
				else {
					sz[u]++;
					for (int i = 0; i < g.Count; i++) {
						if (g[i] == par[u]) continue;
						sz[u] += sz[g[i]];
						if (sz[g[i]] > sz[g[0]]) { var tmp = g[0]; g[0] = g[i]; g[i] = tmp; }
					}
					stack.Pop();
				}
			}
		}

		void decomposite(int cur, ref int ptr) {
			var u = cur;
			for (; ; ) {
				L[u] = ptr++;
				head[u] = cur;
				if (G[u].Count > 0 && d[G[u][0]] > d[u]) u = G[u][0];
				else break;
			}
			for (; ; ) {
				var g = G[u];
				for (int p = 1; p < g.Count; p++)
					if (d[g[p]] > d[u]) decomposite(g[p], ref ptr);
				R[u] = ptr;
				if (u == cur) break;
				u = par[u];
			}
		}


		static void Swap<T>(ref T u, ref T v) { var tmp = u; u = v; v = tmp; }
		/// <summary>Returns the LCA of <paramref name="u"/> and <paramref name="v"/></summary>
		public int LCA(int u, int v) {
			while (head[u] != head[v]) {
				if (d[head[u]] > d[head[v]]) Swap(ref u, ref v);
				v = par[head[v]];
			}
			if (d[u] > d[v]) Swap(ref u, ref v);
			return u;
		}
	}

	#endregion

}
