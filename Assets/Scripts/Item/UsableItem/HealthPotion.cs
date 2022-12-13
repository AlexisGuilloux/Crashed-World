using UnityEngine;

namespace CrashedWorld.Items
{
	[CreateAssetMenu(fileName = "New Potion", menuName = "Crashed World/Item/Health Potion")]
	public class HealthPotion : Item
    {
		[Space, Header("   Potion")]
        public int health;

		public override void Use()
		{
			// Give player 'health' amount of health.
		}
	}
}

