namespace dnd_character_sheet
{
    public class PrintItemInfo
    {
        public static void ShowItemInfo(ItemBaseDND5e item)
        {
            PrintBaseStats(item);
            
            switch(item.ItemType)
            {
                case EnumItemTypesDND5e.Armor:
                    ShowArmorInfo((ItemArmorDND5e)item);
                    break;
                
                case EnumItemTypesDND5e.Weapon:
                    ShowWeaponInfo((ItemWeaponDND5e)item);
                    break;

                case EnumItemTypesDND5e.Coin:
                    ShowCoinInfo((ItemCoinDND5e)item);
                    break;
            }
        }

        private static void PrintBaseStats(ItemBaseDND5e item)
        {
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ItemId] + " " + item.ItemId);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Name] + " " + item.Name);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.BaseCost] + " " + item.BaseCost);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Weight] + " " + item.Weight);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Rarity] + " " + LocalizationsStash.SelectedLocalization[item.Rarity]);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Description]+ " " + item.Description);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ItemType]+ " " + LocalizationsStash.SelectedLocalization[item.ItemType]);
        }

        private static void ShowWeaponInfo(ItemWeaponDND5e item) 
        {
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageDiceCount]+ " " + item.DamageDiceCount);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageDiceValue]+ " " + item.DamageDiceValue);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageModificator]+ " " + item.DamageModificator);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageType]+ " " + LocalizationsStash.SelectedLocalization[item.DamageType]);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProficiencyConcrete]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProficiencyConcrete]);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProficiencyGroup]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProficiencyGroup]);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProperty]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProperty]);
        }

        private static void ShowArmorInfo(ItemArmorDND5e item) 
        {
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.StrengthRequirement]+ " " + item.StrengthRequirement);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ArmorClass]+ " " + item.ArmorClass);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.MaxAgilityBonus]+ " " + item.MaxAgilityBonus);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ArmorType]+ " " +  LocalizationsStash.SelectedLocalization[item.ArmorType]);
        }

        private static void ShowCoinInfo(ItemCoinDND5e item)
        {
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.CoinType] + " " + LocalizationsStash.SelectedLocalization[item.CoinType]);
        }
    }
}