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
		
		[Tooltip("Damage deal to enemy entities")]
		public int enemyDamage;
		
		[Tooltip("Damage deal to trees, minerals and so on...")]
		public int environmentDamage;

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
