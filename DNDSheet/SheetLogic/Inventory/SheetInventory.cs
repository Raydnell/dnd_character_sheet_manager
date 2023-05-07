using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetInventory
    {
        private Dictionary<int, int> _inventory;

        [JsonProperty("Inventory")]
        public Dictionary<int, int> Inventory
        {
            get
            {
                return _inventory;
            }
            protected set
            {
                _inventory = value;
            }
        }

        public abstract void AddItem(int item);
        public abstract void RemoveItem(int item);
    }
}