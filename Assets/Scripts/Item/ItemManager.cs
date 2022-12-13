using CrashedWorld.Attribute;
using CrashedWorld.Items;
using CrashedWorld.Loots;
using CrashedWorld.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrashedWorld.Managers
{
	public class ItemManager : Singleton<ItemManager>
	{
		[Header("   Debug")]
		public bool verbose;

		[Header("   References")]
		public ItemDatabase database;
		public Loot lootPrefab;

		protected override void OnAwake()
		{
			Loot.OnTriggerEnterLoot += OnTriggerEnterLoot;
			Loot.OnTriggerExitLoot += OnTriggerExitLoot;
		}

		public void OnDestroy()
		{
			Loot.OnTriggerEnterLoot -= OnTriggerEnterLoot;
			Loot.OnTriggerExitLoot -= OnTriggerExitLoot;
		}

		public void Spawn(List<string> list, Vector3 position)
		{
			foreach(Item item in list.Select(i => database.Get(i)))
			{
				Instantiate(lootPrefab, position, Quaternion.identity).Init(item);
			}
		}

		private void OnTriggerEnterLoot(Item item)
		{
			if (verbose)
				Debug.Log($"Player enter trigger of {item.itemName}.");
		}

		private void OnTriggerExitLoot(Item item)
		{
			if (verbose)
				Debug.Log($"Player exit trigger of {item.itemName}.");
		}
	}
}


