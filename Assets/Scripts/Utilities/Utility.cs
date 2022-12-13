using System;
using System.Collections.Generic;
using System.Linq;

namespace CrashedWorld.Utilities
{
	public static class Utility
	{
		public static T GetRandomWeighted<T>(List<T> list, Func<T, int> GetWeight)
		{
			if (list == null || list.Count == 0)
				throw new ArgumentNullException();

			int max = list.Sum(x => GetWeight(x));
			int random = UnityEngine.Random.Range(0, max + 1); // +1 because unity random int has his maximum boundary exclusive
			int current = 0;

			foreach (T item in list)
			{
				current += GetWeight(item);
				if (random < current)
					return item;
			}

			return list.First();
		}
	}
}


