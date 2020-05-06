using System.Collections.Generic;
namespace CompLib.Mathematics {
	#region PrimeSieve
	public static partial class MathEx {
		/// <summary>
		/// エラトステネスの篩により、1 ~ N までの整数が素数かどうかを求めます。
		/// O(N loglog N) で実行されます
		/// </summary>
		public static bool[] Sieve(int N) {
			var ret = new bool[N + 1];
			for (int i = 2; i < ret.Length; i++) ret[i] = true;
			for (long i = 2; i * i <= N; i++)
				if (!ret[i]) continue;
				else for (long j = i * i; j < ret.Length; j += i) ret[j] = false;
			return ret;
		}
		/// <summary>
		/// エラトステネスの篩により、1 ~ N までの整数が素数かどうかを求め、素数のみの一覧を返します。
		/// O(N loglog N) で実行されます
		/// </summary>
		public static List<int> SieveList(int N) {
			var res = Sieve(N);
			var ret = new List<int>();
			for (int i = 0; i < res.Length; i++)
				if (res[i]) ret.Add(i);
			return ret;
		}
	}
	#endregion
}
