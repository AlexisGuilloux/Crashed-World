using System;
using UnityEngine;

namespace CrashedWorld.Crafts
{
	public class CraftManager : MonoBehaviour
	{
		public static event Action<Recipe> OnCraftSucceed;

		public void CraftRecipe(Recipe recipe)
		{
			if (recipe.CanBeCrafted(/* Inventory ? */))
			{
				// Remove recipies from inventory ??
				// Add recipe result to inventory ??
				OnCraftSucceed?.Invoke(recipe);
			}
		}
	}
}

