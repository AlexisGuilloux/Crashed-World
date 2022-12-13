using CrashedWorld.Attribute;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CrashedWorld.Crafts
{
	[CreateAssetMenu(fileName = "New Recipe", menuName = "Crashed World/Craft/Recipe")]
	public class Recipe : ScriptableObject
	{
		public string ID;
		public List<RecipeItem> recipies = new List<RecipeItem>();
		[Item] public string result;

		public bool CanBeCrafted(/* Inventory ? */)
		{
			//Compare recipes and inventory
			return true;
		}

		[Serializable]
		public class RecipeItem
		{
			[Item] public string Item;
			public int amount;
		}
	}
}


