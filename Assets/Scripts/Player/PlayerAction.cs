using CrashedWorld.Items;
using CrashedWorld.Utilities;
using System;
using UnityEngine;

namespace CrashedWorld.Player
{
	public class PlayerAction : Singleton<PlayerAction>
	{
		public static event Action<Item> OnSelectItem;
		public static event Action<Item> OnUseItem;

		private Item selectedItem;
		private IUsable usableItem;

		public void SelectItem(Item item)
		{
			selectedItem = item;
			if (selectedItem is IUsable usable)
				usableItem = usable;
			else
				usableItem = null;

			OnSelectItem?.Invoke(item);
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && usableItem != null)
			{
				usableItem.Use();
				OnUseItem?.Invoke(selectedItem);
			}
		}
	}
}
