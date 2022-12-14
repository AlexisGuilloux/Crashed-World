using CrashedWorld.Items;
using CrashedWorld.Managers;
using CrashedWorld.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
	//TODO - Handle inventory full (but not in ui)
	public class PlayerInventoryUI : MonoBehaviour
	{
		[Header("   Display")]
		public CanvasGroup canvas;

		[Header("   References")]
		public GridLayoutGroup grid;
		public Image dragImage;
		public RecipeListUI recipeList;

		public bool IsOpen => canvas.alpha > 0;

		private List<GridSlotUI> slots = new List<GridSlotUI>();

		void Awake()
		{
			Hide();
			Locator.playerInventory = this;
			PlayerInventory.Instance.bag.OnAddItem += Bag_OnAddItem;
			PlayerInventory.Instance.bag.OnRemoveItem += Bag_OnRemoveItem;
			InitSlot();
		}

		private void OnDestroy()
		{
			PlayerInventory.Instance.bag.OnAddItem -= Bag_OnAddItem;
			PlayerInventory.Instance.bag.OnRemoveItem -= Bag_OnRemoveItem;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.B))
				Toggle(!IsOpen);
		}

		public void Toggle(bool isON)
		{
			if (isON)
				Show();
			else
				Hide();
		}

		public void Show()
		{
			canvas.alpha = 1;
			canvas.interactable = true;
			canvas.blocksRaycasts = true;
		}

		public void Hide()
		{
			canvas.alpha = 0;
			canvas.interactable = false;
			canvas.blocksRaycasts = false;
		}

		private void Bag_OnAddItem(string itemID, int value)
		{
			Item item = ItemManager.Instance.database.Get(itemID);

			if (item.isStackable)
				AddStackableItem(itemID, value, item);
			else
				AddNotStackableItem(value, item);
		}

		private void Bag_OnRemoveItem(string itemID, int value)
		{
			GridSlotUI slot = slots.FirstOrDefault(s => !s.Empty && s.ItemID.Equals(itemID));
			slot.RemoveAmount(value);
		}

		private void AddNotStackableItem(int value, Item item)
		{
			for (int i = 0; i < value; i++)
			{
				GridSlotUI slot = slots.FirstOrDefault(s => s.Empty);
				slot.SetItem(item);
			}
		}

		private void AddStackableItem(string itemID, int value, Item item)
		{
			GridSlotUI slot = null;

			slot = slots.FirstOrDefault(s => !s.Empty && s.item.ID.Equals(itemID));

			if (slot == null)
			{
				slot = slots.FirstOrDefault(s => s.Empty);
				slot.SetItem(item, value);
			}
			else
			{
				slot.AddAmount(value);
			}
		}

		public void OnClickSlot(Item item, Vector3 position)
		{
			if (item == null)
			{
				recipeList.Init(CraftManager.Instance.BasicRecipes);
				recipeList.Show();
			}
			else if (item is IUpgradable upgradableItem && upgradableItem.GetUpgradeRecipes().Count > 0)
			{
				recipeList.Init(upgradableItem.GetUpgradeRecipes());
				recipeList.Show();
			}
		}

		private void InitSlot()
		{
			int childIndex = 0;
			foreach (Transform child in grid.transform)
			{
				if (child.TryGetComponent(out GridSlotUI slot))
				{
					slot.Init(null, childIndex);
					slots.Add(slot);
				}
				childIndex++;
			}
		}
	}
}


