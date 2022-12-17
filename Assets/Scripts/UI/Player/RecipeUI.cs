using CrashedWorld.Crafts;
using CrashedWorld.Managers;
using CrashedWorld.Player;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
	public class RecipeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public TextMeshProUGUI label;
        public Image resultIcon;
        public Image leftBarImage;
		public Color hoverColor = Color.white;
		public Button craftBtn;
		public Button prepareBtn;
        public List<RecipeRequirementUI> requirements;

		public Recipe recipe { get; private set; }

        public void Init(Recipe recipe)
		{
			this.recipe = recipe;

			resultIcon.sprite = ItemManager.Instance.database.Get(recipe.result).icon;
            label.text = ItemManager.Instance.database.Get(recipe.result).itemName;
            requirements.ForEach(r => r.Hide());

			craftBtn?.onClick.AddListener(() => CraftManager.Instance.TryCraftRecipe(recipe, PlayerInventory.Instance.bag));
			prepareBtn?.onClick.AddListener(() => CraftManager.Instance.SelectRecipe(recipe));

            for(int i = 0; i < recipe.recipies.Count; i++)
			{
                requirements[i].Init(recipe.recipies[i]);
                requirements[i].Show();
			}

			PlayerInventory.Instance.bag.OnAddItem += Bag_OnAddItem;
			PlayerInventory.Instance.bag.OnRemoveItem += Bag_OnRemoveItem;
		}

		private void OnDestroy()
		{
			PlayerInventory.Instance.bag.OnAddItem -= Bag_OnAddItem;
			PlayerInventory.Instance.bag.OnRemoveItem -= Bag_OnRemoveItem;
		}

		private void Bag_OnAddItem(string itemID, int amount)
		{
			for (int i = 0; i < recipe.recipies.Count; i++)
			{
				requirements[i].Init(recipe.recipies[i]);
			}
		}

		private void Bag_OnRemoveItem(string itemID, int amount)
		{
			for (int i = 0; i < recipe.recipies.Count; i++)
			{
				requirements[i].Init(recipe.recipies[i]);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			CraftManager.Instance.SelectRecipe(recipe);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if(leftBarImage != null)
				leftBarImage.color = hoverColor;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (leftBarImage != null)
				leftBarImage.color = Color.white;
		}
	}
}


