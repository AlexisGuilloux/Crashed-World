using CrashedWorld.Utilities;
using CrashedWorld.Inventories;

namespace CrashedWorld.Player
{
    public class PlayerInventory : Singleton<PlayerInventory>
    {
        public const int MAX_SIZE = 32;

        public Inventory bag = new Inventory(MAX_SIZE);
    }
}
