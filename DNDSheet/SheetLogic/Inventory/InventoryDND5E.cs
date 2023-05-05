namespace dnd_character_sheet
{
    public class InventoryDND5E : SheetInventory
    {
        private Random _random;
        
        public InventoryDND5E()
        {
            Inventory = new Dictionary<int, int>();
            _random = new Random();
        }

        public override void AddItem(int item)
        {
            if (Inventory.ContainsKey(item))
            {
                Inventory[item]++;
            }
            else
            {
                Inventory[item] = 1;
            }
        }

        public override void RemoveItem(int item)
        {
            if (Inventory.ContainsKey(item))
            {
                if (Inventory[item]-- == 0)
                {
                    Inventory.Remove(item);
                }
                else
                {
                    Inventory[item]--;
                }
            }
        }
    }
}