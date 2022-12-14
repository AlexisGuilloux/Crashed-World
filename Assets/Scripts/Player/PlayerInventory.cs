using CrashedWorld.Utilities;
using CrashedWorld.Inventories;
using System.Collections.Generic;
using CrashedWorld.Attribute;

namespace CrashedWorld.Player
{
    public class PlayerInventory : Singleton<PlayerInventory>
    {
        public const int MAX_SIZE = 32;

        public List<ItemAmount> startItems;

        public Inventory bag = new Inventory(MAX_SIZE);

		void Start()
		{
			foreach(ItemAmount itemAmount in startItems)
			{
				bag.Add(itemAmount);
			}	
		}
	}
}
