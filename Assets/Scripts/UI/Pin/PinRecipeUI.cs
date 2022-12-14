using CrashedWorld.Crafts;
using CrashedWorld.Items;
using CrashedWorld.Managers;
using CrashedWorld.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
	public class PinRecipeUI : MonoBehaviour
	{
		public RecipeUI recipeUI;
		public Image resultImage;
		public GameObject keycodeContainer;
		public TextMeshProUGUI keycodeLabel;

		private Recipe recipe;

		void Awake()
		{
			Locator.pinRecipe = this;
		}

		void Start()
		{
			CraftManager.OnRecipeSelected += CraftManager_OnRecipeSelected;
			CraftManager.OnCraftSucceed += CraftManager_OnCraftSucceed;
			Hide();
		}

		private void CraftManager_OnRecipeSelected(Recipe recipe)
		{
			Init(recipe);
		}

		private void CraftManager_OnCraftSucceed(Recipe recipe)
		{
			if (this.recipe == recipe)
				Delete();
		}

		public void Init(Recipe recipe)
		{
			this.recipe = recipe;

			Item item = ItemManager.Instance.database.Get(recipe.result);
			resultImage.sprite = item.icon;

			recipeUI.Init(recipe);

			Show();
		}

		public void Delete()
		{
			recipe = null;
			Hide();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Update()
		{
			if (recipe != null)
				keycodeContainer.SetActive(recipe.CanBeCrafted(PlayerInventory.Instance.bag));
		}
	}
}

