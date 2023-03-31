namespace dnd_character_sheet
{
    public class InventoryDND5E : SheetInventory
    {
        private Random _random;
        
        public InventoryDND5E()
        {
            Inventory = new Dictionary<int, Item>();
            _random = new Random();
        }

        public override void AddItem(Item item)
        {
            Inventory.Add(_random.Next(1000), item);
        }

        public override void RemoveItem(int id)
        {
            Inventory.Remove(id);
        }

        public override void EquipItem(int id)
        {

        }

        public override void TakeOffItem(int id)
        {

        }
    }
}