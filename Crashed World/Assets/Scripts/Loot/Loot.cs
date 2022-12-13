using System;
using UnityEngine;
using CrashedWorld.Items;

namespace CrashedWorld.Loots
{
	[RequireComponent(typeof(Collider), typeof(SpriteRenderer))]
	public class Loot : MonoBehaviour
	{
		public static event Action<Item> OnTriggerEnterLoot;
		public static event Action<Item> OnTriggerExitLoot;

		private Item loot;

		public void Init(Item loot)
		{
			this.loot = loot;
			GetComponent<SpriteRenderer>().sprite = loot.icon;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!IsPlayer(other))
				return;

			OnTriggerEnterLoot?.Invoke(loot);
		}

		private void OnTriggerExit(Collider other)
		{
			if (!IsPlayer(other))
				return;

			OnTriggerExitLoot?.Invoke(loot);
		}

		private bool IsPlayer(Collider other)
		{
			return true;
		}
	}
}