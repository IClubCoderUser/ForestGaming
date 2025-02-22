﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.Selector
{
	/// <summary>Поиск решения.</summary>
	internal static class OptimizatorMinDistance
	{
		public static List<HexHelper> Optimaze(HexHelper current, Vector3 value)
		{
			int iter = 0;

			var list = new List<HexHelper>();
			while(current.transform.position != value && iter < 5)
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
					return null;
				}

				iter++;
			}

			return list;
		}
	}
}
