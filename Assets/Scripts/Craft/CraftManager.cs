using CrashedWorld.Inventories;
using CrashedWorld.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrashedWorld.Crafts
{
	public class CraftManager : MonoBehaviour
	{
		public static event Action<Recipe> OnCraftSucceed;

		public List<Recipe> recipes;

		public List<Recipe> availableRecipe => recipes.Where(r => r.CanBeCrafted(PlayerInventory.Instance.bag)).ToList();

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

