using CrashedWorld.Crafts;
using CrashedWorld.Items;
using CrashedWorld.Managers;
using CrashedWorld.Player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
	public class PinRecipeUI : MonoBehaviour
	{
		[Header("   Display")]
		public CanvasGroup canvas;

		[Header("   References")]
		public RecipeUI recipeUI;
		public GameObject keycodeContainer;
		public TextMeshProUGUI keycodeLabel;
		public Animator anim;

		private Recipe recipe;
		private bool selected;

		public PinRecipeUI Init(Recipe recipe)
		{
			this.recipe = recipe;
			recipeUI.Init(recipe);

			return this;
		}

		public void Delete()
		{
			Destroy(gameObject);
		}

		public void Update()
		{
			if (selected && recipe != null)
				keycodeContainer.SetActive(recipe.CanBeCrafted(PlayerInventory.Instance.bag));
		}

		private void Toggle(bool select)
		{
			selected = select;
			anim.SetBool("selected", selected);
		}

		public void Select() => Toggle(true);
		public void UnSelect() => Toggle(false);
	}
}

