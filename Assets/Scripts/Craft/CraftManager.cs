using CrashedWorld.Crafts;
using CrashedWorld.Inventories;
using CrashedWorld.Player;
using CrashedWorld.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrashedWorld.Managers
{
	public class CraftManager : Singleton<CraftManager>
	{
		public static event Action<Recipe> OnRecipeSelected;
		public static event Action<Recipe> OnCraftSucceed;

		public List<Recipe> recipes;

		public List<Recipe> BasicRecipes => recipes.Where(r => !r.isUpgradeRecipe).ToList();
		public List<Recipe> AvailableRecipe => recipes.Where(r => r.CanBeCrafted(PlayerInventory.Instance.bag)).ToList();

		public Recipe selectedRecipe { get; private set; }

		public bool TryCraftRecipe(Recipe recipe, Inventory inventory)
		{
			if (recipe.CanBeCrafted(inventory))
			{
				inventory.Remove(recipe.recipies);
				inventory.Add(recipe.result);
				OnCraftSucceed?.Invoke(recipe);
				return true;
			}

			return false;
		}

		public void SelectRecipe(Recipe recipe)
		{
			selectedRecipe = recipe;
			OnRecipeSelected?.Invoke(recipe);
		}

		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.F))
				TryCraftRecipe(selectedRecipe, PlayerInventory.Instance.bag);
		}
	}
}

