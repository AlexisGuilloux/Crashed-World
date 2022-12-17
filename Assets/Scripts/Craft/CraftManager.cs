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
		public static event Action<int> OnRecipeSelectedIndexChange;
		public static event Action<Recipe> OnCraftSucceed;

		public int maxSelectableRecipe = 4;
		public List<Recipe> recipes;

		public List<Recipe> BasicRecipes => recipes.Where(r => !r.isUpgradeRecipe).ToList();
		public List<Recipe> AvailableRecipe => recipes.Where(r => r.CanBeCrafted(PlayerInventory.Instance.bag)).ToList();

		public List<Recipe> selectedRecipes { get; private set; } = new List<Recipe>();
		private int recipeIndex;
		public Recipe SelectedRecipe => selectedRecipes[recipeIndex];

		public bool TryCraftRecipe(Recipe recipe, Inventory inventory, bool pinCraft = false)
		{
			if (recipe.CanBeCrafted(inventory))
			{
				if(pinCraft)
					selectedRecipes.Remove(recipe);
				
				inventory.Remove(recipe.recipies);
				inventory.Add(recipe.result);
				OnCraftSucceed?.Invoke(recipe);
				
				if(pinCraft)
					SetRecipeIndex(recipeIndex);
				return true;
			}

			return false;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Tab))
				IncrementRecipeIndex();

			if (Input.GetKeyDown(KeyCode.F))
				TryCraftRecipe(selectedRecipes[recipeIndex], PlayerInventory.Instance.bag, true);
		}

		public void SelectRecipe(Recipe recipe)
		{
			if (selectedRecipes.Count < maxSelectableRecipe)
			{
				selectedRecipes.Add(recipe);
				OnRecipeSelected?.Invoke(recipe);
				SetRecipeIndex(selectedRecipes.Count - 1);
			}
		}

		private void IncrementRecipeIndex()
		{
			SetRecipeIndex(recipeIndex == selectedRecipes.Count - 1 ? 0 : recipeIndex + 1); 
		}

		private void SetRecipeIndex(int index)
		{
			recipeIndex = Mathf.Clamp(index, 0, selectedRecipes.Count - 1);

			OnRecipeSelectedIndexChange?.Invoke(recipeIndex);
		}
	}
}

