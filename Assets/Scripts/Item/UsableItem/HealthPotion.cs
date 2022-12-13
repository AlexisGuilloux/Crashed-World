using CrashedWorld.Crafts;
using UnityEngine;

namespace CrashedWorld.Items
{
	[CreateAssetMenu(fileName = "New Potion", menuName = "Crashed World/Item/Health Potion")]
	public class HealthPotion : Item, IUsable, IUpgradable
    {
		[Space, Header("   Potion")]
        public int health;
		public Recipe upgradeRecipe;

		public void Use()
		{
			// Give player 'health' amount of health.
		}

		public Recipe GetUpgradeRecipe()
		{
			return upgradeRecipe;
		}
	}
}

