namespace dnd_character_sheet
{
    public abstract class SheetInventory
    {
        private Dictionary<int, Item> _inventory = new Dictionary<int, Item>();
        public Dictionary<int, Item> Inventory
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

        public abstract void AddItem(Item item);
        public abstract void RemoveItem(int id);
        public abstract void EquipItem(int id);
        public abstract void TakeOffItem(int id);
    }
}