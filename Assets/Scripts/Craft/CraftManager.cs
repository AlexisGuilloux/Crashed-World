using CrashedWorld.Inventories;
using System;
using UnityEngine;

namespace CrashedWorld.Crafts
{
	public class CraftManager : MonoBehaviour
	{
		public static event Action<Recipe> OnCraftSucceed;

		public void CraftRecipe(Recipe recipe, Inventory inventory)
		{
			if (recipe.CanBeCrafted(inventory))
			{
				inventory.Remove(recipe.recipies);
				inventory.Add(recipe.result);
				OnCraftSucceed?.Invoke(recipe);
			}
		}
	}
}

