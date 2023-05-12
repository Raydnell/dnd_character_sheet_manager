namespace dnd_character_sheet
{
    public class PrintItemInfo
    {
        private IUserOutput _output;

        public PrintItemInfo()
        {
            _output = new ConsoleOutput();
        }
        
        public void ShowItemInfo(ItemBaseDND5e item)
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

        private void PrintBaseStats(ItemBaseDND5e item)
        {
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ItemId] + " " + item.ItemId);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Name] + " " + item.Name);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.BaseCost] + " " + item.BaseCost);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Weight] + " " + item.Weight);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Rarity] + " " + LocalizationsStash.SelectedLocalization[item.Rarity]);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Description]+ " " + item.Description);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ItemType]+ " " + LocalizationsStash.SelectedLocalization[item.ItemType]);
        }

        private void ShowWeaponInfo(ItemWeaponDND5e item) 
        {
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageDiceCount]+ " " + item.DamageDiceCount);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageDiceValue]+ " " + item.DamageDiceValue);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageModificator]+ " " + item.DamageModificator);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageType]+ " " + LocalizationsStash.SelectedLocalization[item.DamageType]);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProficiencyConcrete]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProficiencyConcrete]);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProficiencyGroup]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProficiencyGroup]);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProperty]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProperty]);
        }

        private void ShowArmorInfo(ItemArmorDND5e item) 
        {
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.StrengthRequirement]+ " " + item.StrengthRequirement);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ArmorClass]+ " " + item.ArmorClass);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.MaxAgilityBonus]+ " " + item.MaxAgilityBonus);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ArmorType]+ " " +  LocalizationsStash.SelectedLocalization[item.ArmorType]);
        }

        private void ShowCoinInfo(ItemCoinDND5e item)
        {
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.CoinType] + " " + LocalizationsStash.SelectedLocalization[item.CoinType]);
        }
    }
}