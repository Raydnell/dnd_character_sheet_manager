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
            var textToMessageLog = string.Empty;
            
            _pressedKey = Console.ReadKey();    
            switch (_pressedKey.Key)
            {
                case ConsoleKey.A:
                    return EquipArmor();

                case ConsoleKey.R:
                    return EquipHand(EnumEquipmentSlotsDND5e.RightHand);

                case ConsoleKey.L:
                    return EquipHand(EnumEquipmentSlotsDND5e.LeftHand);

                case ConsoleKey.T:
                    CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.UnEquipSlot(EnumEquipmentSlotsDND5e.LeftHand);
                    return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.LeftHandOff];

                case ConsoleKey.Y:
                    CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.UnEquipSlot(EnumEquipmentSlotsDND5e.RightHand);
                    return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.RightHandOff];

                case ConsoleKey.U:
                    CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.UnEquipSlot(EnumEquipmentSlotsDND5e.BodyArmor);
                    return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.ArmorOff];

                default:
                    return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.EquipmentWasChange];
            }
        }
        
        public string EquipArmor()
        {
            Console.Clear();
            MakeArmorSlotList();

            if (_filtredItems.Count == 0)
            {
                return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.NoArmorInInventory];
            }
            else
            {
                var armor = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title(LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.ChooseArmor])
                        .PageSize(10)
                        .MoreChoicesText($"[grey]({LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.ArrowsControl]})[/]")
                        .AddChoices(_filtredItems));

                string itemId = armor.Substring(0, 4);
                if (int.TryParse(itemId, out int result))
                {
                    CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipItem(EnumEquipmentSlotsDND5e.BodyArmor, ItemsDataBaseDND5e.ItemsDB[result]);
                }

                return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.ArmorEquip];
            }
        }

        public string EquipHand(EnumEquipmentSlotsDND5e slot)
        {
            Console.Clear();
            MakeHandSlotList();

            if (_filtredItems.Count == 0)
            {
                return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.NoArmorInInventory];
            }
            else
            {
                var handSlot = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title(LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.ChooseWhatEquipInHand])
                        .PageSize(10)
                        .MoreChoicesText($"[grey]({LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.ArrowsControl]})[/]")
                        .AddChoices(_filtredItems));

                string itemId = handSlot.Substring(0, 4);
                if (int.TryParse(itemId, out int result))
                {
                    CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipItem(slot, ItemsDataBaseDND5e.ItemsDB[result]);
                }

                if (slot == EnumEquipmentSlotsDND5e.RightHand)
                {
                    return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.RightHandEquip];
                }
                else
                {
                    return LocalizationsStash.SelectedLocalization[EnumWorkWithEquipment.LeftHandEquip];
                }
            }
        }

        public void MakeArmorSlotList()
        {
            _filtredItems.Clear();
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetInventory.Inventory)
            {
                if (ItemsDataBaseDND5e.ItemsDB[item.Key].ItemType == EnumItemTypesDND5e.Armor)
                {
                    var itemArmorDND5e = (ItemArmorDND5e)ItemsDataBaseDND5e.ItemsDB[item.Key];
                    if (itemArmorDND5e.ArmorType != EnumArmorProficienciesDND5E.Shield)
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
                    var itemArmorDND5e = (ItemArmorDND5e)ItemsDataBaseDND5e.ItemsDB[item.Key];

                    if (itemArmorDND5e.ArmorType == EnumArmorProficienciesDND5E.Shield)
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