namespace dnd_character_sheet
{
    public class ItemsDataBaseDND5e
    {
        private Dictionary<int, ItemBaseDND5e> _itemsBase;

        public Dictionary<int, ItemBaseDND5e> ItemsBase
        {
            get
            {
                return _itemsBase;
            }
            private set
            {
                _itemsBase = value;
            }
        }
        
        public ItemsDataBaseDND5e()
        {
            _itemsBase = new Dictionary<int, ItemBaseDND5e>();
        }

        public void LoadItemsBase(Dictionary<int, ItemBaseDND5e> items)
        {
            _itemsBase = items;
        }

        public ItemBaseDND5e GetItem(int id)
        {
            return _itemsBase[id];
        }

        public void AddItem(ItemBaseDND5e item)
        {
            ItemsBase[item.ItemId] = item;
        }
    }
}