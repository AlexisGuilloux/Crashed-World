using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CrashedWorld.Items
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "Crashed World/Item/Database")]
    public class ItemDatabase : DatabaseSingleton<ItemDatabase>
    {
		public List<Item> items;

        /// <summary>
        /// Get an item from the database.
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>The item or null if not found</returns>
        public Item Get(string id)
		{
            Item item = items.FirstOrDefault(i => i.ID == id);

            if (item == null)
                Debug.Log($"Item id {id} not found in the item database");

            return item;
		}
    }
}


