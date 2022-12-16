using CrashedWorld.Crafts;
using System.Collections.Generic;
using UnityEngine;

namespace CrashedWorld.Items
{
	[CreateAssetMenu(fileName = "New Weapon", menuName = "Crashed World/Item/Weapon")]
	public class Weapon : Item, IUsable, IUpgradable
	{
		[Space, Header("   Weapon")]
		public List<Recipe> upgradeRecipe = new List<Recipe>();

		public WeaponTypes weaponType;

		[Tooltip("Target damage deal to other entity")]
		public int damageValue;

		public void Use()
		{
			// Instantiate a prefab that contain a hitbox and damage things ?
		}

		public List<Recipe> GetUpgradeRecipes()
		{
			return new List<Recipe>(upgradeRecipe);
		}
	}
}
