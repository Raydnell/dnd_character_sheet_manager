namespace dnd_character_sheet
{
    public abstract class SheetInventory
    {
        private Dictionary<int, BaseItem> _inventory;
        public Dictionary<int, BaseItem> Inventory
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

        public abstract void AddItem(BaseItem item);
        public abstract void RemoveItem(int id);
        public abstract void EquipItem(int id);
        public abstract void TakeOffItem(int id);
    }
}