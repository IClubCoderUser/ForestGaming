using System.Collections.Generic;

using UnityEngine;

namespace Assets.scripts.Selector
{
	/// <summary>Поиск решения.</summary>
	internal static class OptimizatorMinDistance
	{
		public static List<HexHelper> Optimaze(HexHelper current, Vector3 value, int maxLength, out int step)
		{
			int iter = 0;

			if(maxLength == 0)
			{
				step = 0;
				return null;
			}

			var list = new List<HexHelper>();
			while(current.transform.position != value && iter < maxLength)
			{
				float d = float.MaxValue;
				HexHelper select = null;
				foreach(var hexagon in current.Hexs)
				{
					var dist = Vector2.Distance(hexagon.transform.position, value);
					if(dist < d)
					{
						d = dist;
						select = hexagon;
					}
				}

				if(select != null)
				{
					list.Add(select);
					current = select;
				}
				else
				{
					step = iter;
					return null;
				}

				iter++;
			}

			step = iter--;
			return list;
		}
	}
}
