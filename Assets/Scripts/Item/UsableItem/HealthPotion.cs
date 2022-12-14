using CrashedWorld.Crafts;
using System.Collections.Generic;
using UnityEngine;

namespace CrashedWorld.Items
{
	[CreateAssetMenu(fileName = "New Potion", menuName = "Crashed World/Item/Health Potion")]
	public class HealthPotion : Item, IUsable, IUpgradable
    {
		[Space, Header("   Potion")]
        public int health;
		public List<Recipe> upgradeRecipe = new List<Recipe>();

		public void Use()
		{
			// Give player 'health' amount of health.
		}

		public List<Recipe> GetUpgradeRecipes()
		{
			return new List<Recipe>(upgradeRecipe);
		}
	}
}

