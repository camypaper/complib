using System;
using System.Collections.Generic;
namespace CompLib.Collections {
	#region PriorityQueue
	public class PriorityQueue<T> {
		readonly List<T> heap = new List<T>() { default(T) };
		readonly Comparison<T> cmp;

		public PriorityQueue() { cmp = Comparer<T>.Default.Compare; }
		public PriorityQueue(int cap) { heap.Capacity = cap; cmp = Comparer<T>.Default.Compare; }
		public PriorityQueue(Comparison<T> comparison) { cmp = comparison; }
		public PriorityQueue(int cap, Comparison<T> comparison) { heap.Capacity = cap; cmp = comparison; }
		public PriorityQueue(IComparer<T> comparer) { cmp = comparer.Compare; }
		public PriorityQueue(int cap, IComparer<T> comparer) { heap.Capacity = cap; cmp = comparer.Compare; }

		/// <summary>
		/// Time complexity: <c>O(log N)</c>
		/// </summary>
		public void Enqueue(T item) {
			var pos = heap.Count;
			heap.Add(item);
			for (; pos != 1; pos >>= 1) {
				var par = pos >> 1;
				if (cmp(heap[par], item) <= 0) break;
				heap[pos] = heap[par];
			}
			heap[pos] = item;

		}

		/// <summary>
		/// Time complexity: <c>O(log N)</c>
		/// </summary>
		public T Dequeue() {
			var ret = Peek();
			var pos = 1;
			var x = heap[heap.Count - 1];
			while (pos << 1 < heap.Count) {
				var l = pos << 1;
				var r = l + 1;
				if (r < heap.Count && cmp(heap[r], heap[l]) < 0) l = r;
				if (cmp(heap[l], x) >= 0) break;
				heap[pos] = heap[l];
				pos = l;
			}
			heap[pos] = x;
			heap.RemoveAt(heap.Count - 1);
			return ret;

		}
		/// <summary>
		/// Time complexity: <c>O(1)</c>
		/// </summary>
		public T Peek() { return heap[1]; }
		/// <summary>
		/// Time complexity: <c>O(1)</c>
		/// </summary>
		public int Count { get { return heap.Count - 1; } }
		/// <summary>
		/// Time complexity: <c>O(1)</c>
		/// </summary>
		public bool Any() { return Count > 0; }

		/// <summary>
		/// Enumerate items. Time complexity: <c>O(N log N)</c>
		/// </summary>
		public T[] Items {
			get {
				var ret = new T[Count];
				for (int i = 0; i < ret.Length; i++)
					ret[i] = heap[i + 1];
				Array.Sort(ret, cmp);
				return ret;
			}
		}
	}
	#endregion
}
