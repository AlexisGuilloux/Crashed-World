using CrashedWorld.Attribute;
using CrashedWorld.Items;
using CrashedWorld.Utilities;
using System;
using System.Collections.Generic;

namespace CrashedWorld.Inventories
{
	public class Inventory
	{
		/// <summary>
		/// string ItemID, int Amount
		/// </summary>
		public event Action<string, int> OnAddItem;

		/// <summary>
		/// string ItemID, int Amount
		/// </summary>
		public event Action<string, int> OnRemoveItem;

		public Dictionary<string, int> items = new Dictionary<string, int>();

		public void Add(List<ItemAmount> items) => items.ForEach(i => Add(i));
		public void Add(ItemAmount itemAmount) => Add(itemAmount.itemID, itemAmount.amount);
		public void Add(Item item, int value = 1) => Add(item.ID, value);
		public void Add(string item, int value = 1)
		{
			if (items.ContainsKey(item))
				items[item] += value;
			else
				items.Add(item, value);

			OnAddItem?.Invoke(item, value);
		}

		public void Remove(List<ItemAmount> items)
		{
			if (Contains(items))
				items.ForEach(i => Remove(i));
		}
		public void Remove(ItemAmount itemAmount) => Remove(itemAmount.itemID, itemAmount.amount);
		public void Remove(Item item, int value = 1) => Remove(item.ID, value);
		public void Remove(string item, int value = 1)
		{
			if (Contains(item, value))
			{
				items[item] -= value;
				OnRemoveItem?.Invoke(item, value);
			}
		}

		public bool Contains(List<ItemAmount> items) => items.TrueForAll(i => Contains(i));
		public bool Contains(ItemAmount itemAmount) => Contains(itemAmount.itemID, itemAmount.amount);
		public bool Contains(string item, int value = 1)
		{
			return items.ContainsKey(item) && items[item] >= value;
		}
	}

	[Serializable]
	public class ItemAmount
	{
		[Item] public string itemID;
		public int amount;
	}
}


