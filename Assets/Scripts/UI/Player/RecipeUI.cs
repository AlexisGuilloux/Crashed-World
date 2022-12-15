using CrashedWorld.Crafts;
using CrashedWorld.Managers;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
	public class RecipeUI : MonoBehaviour, IPointerClickHandler
    {
        public TextMeshProUGUI label;
        public Image resultIcon;
        public List<RecipeRequirementUI> requirements;

		private Recipe recipe;

        public void Init(Recipe recipe)
		{
			this.recipe = recipe;

			resultIcon.sprite = ItemManager.Instance.database.Get(recipe.result).icon;
            label.text = ItemManager.Instance.database.Get(recipe.result).itemName;
            requirements.ForEach(r => r.Hide());
            for(int i = 0; i < recipe.recipies.Count; i++)
			{
                requirements[i].Init(recipe.recipies[i]);
                requirements[i].Show();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			CraftManager.Instance.SelectRecipe(recipe);
			Locator.playerInventory.recipeList.Hide();
		}
	}
}


