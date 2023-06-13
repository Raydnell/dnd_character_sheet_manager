using Spectre.Console;

namespace dnd_character_sheet
{
    public class EquipmentSystem : IEquipmentSystem
    {
        private List<string> _filtredItems;
        private ConsoleKeyInfo _pressedKey;

        public EquipmentSystem()
        {
            _filtredItems = new List<string>();
        }

        public string ChooseAction()
        {
            _pressedKey = Console.ReadKey();    
            switch (_pressedKey.Key)
            {
                case ConsoleKey.A:
                    EquipArmor();
                    break;

                case ConsoleKey.R:
                    EquipHand(EnumEquipmentSlotsDND5e.RightHand);
                    break;

                case ConsoleKey.L:
                    EquipHand(EnumEquipmentSlotsDND5e.LeftHand);
                    break;

                case ConsoleKey.T:
                    CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.UnEquipSlot(EnumEquipmentSlotsDND5e.LeftHand);
                    break;

                case ConsoleKey.Y:
                    CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.UnEquipSlot(EnumEquipmentSlotsDND5e.RightHand);
                    break;

                case ConsoleKey.U:
                    CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.UnEquipSlot(EnumEquipmentSlotsDND5e.BodyArmor);
                    break;
            }

            SheetFormulas.CalculateArmorClass();

            return "Было какое-то действие с экипировкой";
        }
        
        public void EquipArmor()
        {
            Console.Clear();
            MakeArmorSlotList();
            
            var fruit = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Выбери броню из инвентаря, которую хочешь одеть")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(_filtredItems));
            AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");

            string itemId = fruit.Substring(0, 4);
            if (int.TryParse(itemId, out int result))
            {
                CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipItem(EnumEquipmentSlotsDND5e.BodyArmor, ItemsDataBaseDND5e.ItemsDB[result]);
            }
        }

        public void EquipHand(EnumEquipmentSlotsDND5e slot)
        {
            Console.Clear();
            MakeHandSlotList();

            var fruit = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Выбери броню из инвентаря, которую хочешь одеть")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(_filtredItems));
            AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");

            string itemId = fruit.Substring(0, 4);
            if (int.TryParse(itemId, out int result))
            {
                CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipItem(slot, ItemsDataBaseDND5e.ItemsDB[result]);
            }
        }

        public void MakeArmorSlotList()
        {
            _filtredItems.Clear();
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetInventory.Inventory)
            {
                if (ItemsDataBaseDND5e.ItemsDB[item.Key].ItemType == EnumItemTypesDND5e.Armor)
                {
                    var ItemArmorDND5e = (ItemArmorDND5e)ItemsDataBaseDND5e.ItemsDB[item.Key];

                    if (ItemArmorDND5e.ArmorType != EnumArmorProficienciesDND5E.Shield)
                    {
                        _filtredItems.Add(item.Key + " - " + ItemsDataBaseDND5e.ItemsDB[item.Key].Name);
                    }
                }
            }
        }

        public void MakeHandSlotList()
        {
            _filtredItems.Clear();
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetInventory.Inventory)
            {
                if (ItemsDataBaseDND5e.ItemsDB[item.Key].ItemType == EnumItemTypesDND5e.Armor)
                {
                    var ItemArmorDND5e = (ItemArmorDND5e)ItemsDataBaseDND5e.ItemsDB[item.Key];

                    if (ItemArmorDND5e.ArmorType == EnumArmorProficienciesDND5E.Shield)
                    {
                        _filtredItems.Add(item.Key + " - " + ItemsDataBaseDND5e.ItemsDB[item.Key].Name);
                    }
                }
                else
                {
                    _filtredItems.Add(item.Key + " - " + ItemsDataBaseDND5e.ItemsDB[item.Key].Name);
                }
            }
        }
    }
}