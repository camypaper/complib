using System.Collections.Generic;
namespace CompLib.Collections {
	#region HashMap<K,V>
	public class HashMap<K, V> : Dictionary<K, V>
	//where V : new()
	{
		public HashMap() : base() { }
		public HashMap(int cap) : base(cap) { }
		new public V this[K i] {
			get {
				V v;
				return TryGetValue(i, out v) ? v :
				base[i] = default(V);
				// base[i] = new V();
			}
			set { base[i] = value; }
		}
	}
	#endregion

	#region SortedMap<K,V>
	public class SortedMap<K, V> : SortedDictionary<K, V>
	//where V : new()
	{
		public SortedMap() : base() { }
		public SortedMap(IComparer<K> cmp) : base(cmp) { }
		new public V this[K i] {
			get {
				V v;
				return TryGetValue(i, out v) ? v :
				base[i] = default(V);
				// base[i] = new V();
			}
			set { base[i] = value; }
		}
	}
	#endregion
}
