using CrashedWorld.Attribute;
using CrashedWorld.Items;
using CrashedWorld.Managers;
using CrashedWorld.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CrashedWorld.Loots
{
	[RequireComponent(typeof(Collider))]
	public class LootHolder : MonoBehaviour
	{
		public int health;

		public List<LootData> lootsData = new List<LootData>();

		private void OnTriggerEnter(Collider other)
		{
			if (!CanBeDamagedBy(other))
				return;

			//GetDamageValueOfOther

			Damage(1);
		}

		private bool CanBeDamagedBy(Collider other)
		{
			return true;
		}

		private void Damage(int value)
		{
			health -= value;

			if (health <= 0)
				Die();
		}

		private void Die()
		{
			ItemManager.Instance.Spawn(Drop(), transform.position);
			Destroy(gameObject);
		}

		public List<string> Drop()
		{
			return Utility.GetRandomWeighted(lootsData, ld => ld.weight).items;
		}

		[Serializable]
		public class LootData
		{
			public int weight;
			[Item] public List<string> items;
		}
	}
}
