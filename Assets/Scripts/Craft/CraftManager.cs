using CrashedWorld.Crafts;
using CrashedWorld.Inventories;
using CrashedWorld.Player;
using CrashedWorld.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrashedWorld.Managers
{
	public class CraftManager : Singleton<CraftManager>
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

