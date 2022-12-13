using UnityEngine;

namespace CrashedWorld.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Crashed World/Item/Item")]
    public class Item : ScriptableObject
    {
        [Header("   General")]
        public string ID;

        public string itemName;
        [TextArea(3, 5)]
        public string description;
        public Sprite icon;

        public bool isStackable;

        public virtual void Use() { }

		public override string ToString()
		{
			return itemName;
		}
	}
}

