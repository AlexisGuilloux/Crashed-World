using CrashedWorld.Crafts;
using CrashedWorld.Managers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
	public class PinListRecipeUI : MonoBehaviour
	{
		private List<PinRecipeUI> recipes = new List<PinRecipeUI>();

		public PinRecipeUI recipePrefab;
		public VerticalLayoutGroup recipeContainer;

		private void Awake()
		{
			Locator.PinListRecipeUI = this;
			CraftManager.OnRecipeSelected += CraftManager_OnRecipeSelected;
			CraftManager.OnRecipeSelectedIndexChange += CraftManager_OnRecipeSelectedIndexChange;
			CraftManager.OnCraftSucceed += CraftManager_OnCraftSucceed;
		}

		private void OnDestroy()
		{
			CraftManager.OnRecipeSelected -= CraftManager_OnRecipeSelected;
			CraftManager.OnRecipeSelectedIndexChange -= CraftManager_OnRecipeSelectedIndexChange;
			CraftManager.OnCraftSucceed -= CraftManager_OnCraftSucceed;
		}

		private void CraftManager_OnRecipeSelectedIndexChange(int index)
		{
			recipes.ForEach(r => r.UnSelect());
			recipes[index].Select();
		}

		private void CraftManager_OnRecipeSelected(Recipe recipe)
		{
			recipes.Add(Instantiate(recipePrefab, recipeContainer.transform).Init(recipe));
		}

		private void CraftManager_OnCraftSucceed(Recipe recipe)
		{
			PinRecipeUI pinRecipeUI = recipes.FirstOrDefault(r => r.recipeUI.recipe == recipe);
			if(pinRecipeUI != null)
			{
				recipes.Remove(pinRecipeUI);
				pinRecipeUI.Delete();
			}
		}
	}
}
