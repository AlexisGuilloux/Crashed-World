using CrashedWorld.Inventories;
using CrashedWorld.Items;
using CrashedWorld.Managers;
using CrashedWorld.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CrashedWorld.UI
{
	public class RecipeRequirementUI : MonoBehaviour
    {
        public Image icon;
        public TextMeshProUGUI label;

        public void Init(ItemAmount itemAmount)
		{
			Item item = ItemManager.Instance.database.Get(itemAmount.itemID);
			icon.sprite = item.icon;
			label.text = $"{PlayerInventory.Instance.bag.Count(item)}/{itemAmount.amount}";
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}

