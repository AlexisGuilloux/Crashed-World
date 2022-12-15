using CrashedWorld.Attribute;
using CrashedWorld.Items;
using CrashedWorld.Managers;
using CrashedWorld.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrashedWorld.Loots
{
	[RequireComponent(typeof(Collider))]
	public class LootHolder : MonoBehaviour, IDamageable
	{
		[Header("   Health")]
		public int health;

		[Header("   Resistance")]
		public List<WeaponTypeMultiplier> weaponTypeMultipliers = new List<WeaponTypeMultiplier>();
		public float defaultMultiplier;

		[Header("   Loot")]
		public List<LootData> lootsData = new List<LootData>();

		public void TryDamage(int targetDamage, WeaponTypes weaponType)
		{
			int damageValue = Mathf.RoundToInt(targetDamage * GetMultiplier(weaponType));
			Damage(damageValue);
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

		private float GetMultiplier(WeaponTypes type)
		{
			WeaponTypeMultiplier weaponMultiplier = weaponTypeMultipliers.FirstOrDefault(wtm => wtm.type == type);

			if (weaponMultiplier == null)
				return defaultMultiplier;

			return weaponMultiplier.multiplier;
		}

		[Serializable]
		public class LootData
		{
			public int weight;
			[Item] public List<string> items;
		}
	}
}
