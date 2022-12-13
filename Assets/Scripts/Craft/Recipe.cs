using CrashedWorld.Attribute;
using CrashedWorld.Inventories;
using System.Collections.Generic;
using UnityEngine;

namespace CrashedWorld.Crafts
{
	[CreateAssetMenu(fileName = "New Recipe", menuName = "Crashed World/Craft/Recipe")]
	public class Recipe : ScriptableObject
	{
		public string ID;
		public List<ItemAmount> recipies = new List<ItemAmount>();
		[Item] public string result;

		public bool CanBeCrafted(Inventory inventory)
		{
			return inventory.Contains(recipies);
		}
	}
}


