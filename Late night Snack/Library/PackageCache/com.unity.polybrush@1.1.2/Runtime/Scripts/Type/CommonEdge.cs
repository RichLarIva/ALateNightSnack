using UnityEngine;
using System.Collections.Generic;

namespace UnityEngine.Polybrush
{
    /// <summary>
    /// Contains PolyEdge with it's accompanying common lookup edge.
    /// </summary>
    public struct CommonEdge : System.IEquatable<CommonEdge>
	{
		internal PolyEdge edge, common;

		internal int x { get { return edge.x; } }
		internal int y { get { return edge.y; } }

		internal int cx { get { return common.x; } }
		internal int cy { get { return common.y; } }

		internal CommonEdge(int _x, int _y, int _cx, int _cy)
		{
			this.edge = new PolyEdge(_x, _y);
			this.common = new PolyEdge(_cx, _cy);
		}

        /// <summary>
        /// Equality comparer for CommonEdge
        /// </summary>
        /// <param name="b"> CommonEdge to compare to this</param>
        /// <returns>true if the 2 CommonEdge are equals</returns>
		public bool Equals(CommonEdge b)
		{
			return common.Equals(b.common);
		}

        /// <summary>
        /// Equality comparer for CommonEdge
        /// </summary>
        /// <param name="b"> System.Object that should be compare to this</param>
        /// <returns>true if the 2 elements are CommonEdge and are equals</returns>
		public override bool Equals(System.Object b)
		{
			return b is CommonEdge && common.Equals(((CommonEdge)b).common);
		}

        /// <summary>
        /// Equality comparer for CommonEdge with == operator
        /// </summary>
        /// <param name="a"> CommonEdge to compare</param>
        /// <param name="b"> CommonEdge to compare to</param>
        /// <returns>true if the 2 elements are equals</returns>
		public static bool operator ==(CommonEdge a, CommonEdge b)
		{
			return a.Equals(b);
		}

        /// <summary>
        /// Equality comparer for CommonEdge with != operator
        /// </summary>
        /// <param name="a"> CommonEdge to compare</param>
        /// <param name="b"> CommonEdge to compare to</param>
        /// <returns>true if the 2 elements are different</returns>
		public static bool operator !=(CommonEdge a, CommonEdge b)
		{
			return !a.Equals(b);
		}

        /// <summary>
        /// HashCode Generation
        /// </summary>
        /// <returns>unique hashcode for CommonEdge</returns>
		public override int GetHashCode()
		{
			// http://stackoverflow.com/questions/5221396/what-is-an-appropriate-gethashcode-algorithm-for-a-2d-point-struct-avoiding
			return common.GetHashCode();
		}

        /// <summary>
        /// Stringification of the CommonEdge data
        /// </summary>
        /// <returns>String representing the CommonEdge</returns>
		public override string ToString()
		{
			return string.Format("{{ {{{0}:{1}}}, {{{2}:{3}}} }}", edge.x, common.x, edge.y, common.y);
		}

        /// <summary>
        /// Returns a new list of indices by selecting the x,y of each edge (discards common).
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        internal static List<int> ToList(IEnumerable<CommonEdge> edges)
		{
			List<int> list = new List<int>();

			foreach(CommonEdge e in edges)
			{
				list.Add(e.edge.x);
				list.Add(e.edge.y);
			}

			return list;
		}

        /// <summary>
        /// Returns a new hashset of indices by selecting the x,y of each edge (discards common).
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        internal static HashSet<int> ToHashSet(IEnumerable<CommonEdge> edges)
		{
			HashSet<int> hash = new HashSet<int>();

			foreach(CommonEdge e in edges)
			{
				hash.Add(e.edge.x);
				hash.Add(e.edge.y);
			}

			return hash;
		}
	}
}
