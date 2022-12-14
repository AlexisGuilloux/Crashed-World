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
		[Header("   References")]
		public GridLayoutGroup grid;
		public Image dragImage;
		public RecipeListUI recipeList;

		private List<GridSlotUI> slots = new List<GridSlotUI>();

		void Awake()
		{
			Locator.playerInventory = this;
		}

		void Start()
		{
			PlayerInventory.Instance.bag.OnAddItem += Bag_OnAddItem;

			InitSlot();
		}

		private void OnDestroy()
		{
			PlayerInventory.Instance.bag.OnAddItem -= Bag_OnAddItem;
		}

		private void Bag_OnAddItem(string itemID, int value)
		{
			Item item = ItemManager.Instance.database.Get(itemID);

			if (item.isStackable)
				AddStackableItem(itemID, value, item);
			else
				AddNotStackableItem(value, item);
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
				slot.AddMore(value);
			}
		}

		public void OnClickSlot(Item item, Vector3 position)
		{
			if(item == null)
			{
				recipeList.Init();
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


