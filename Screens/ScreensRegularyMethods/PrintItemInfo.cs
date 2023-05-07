namespace dnd_character_sheet
{
    public class PrintItemInfo
    {
        private IUserOutput _output;

        public PrintItemInfo()
        {
            _output = new ConsoleOutput();
        }
        
        public void ShowItemInfo(ItemRegularDND5e item)
        {
            PrintBaseStats(item);
        }

        public void PrintBaseStats(ItemBaseDND5e item)
        {
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ItemId] + " " + item.ItemId);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Name] + " " + item.Name);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.BaseCost] + " " + item.BaseCost);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Weight] + " " + item.Weight);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Rarity] + " " + LocalizationsStash.SelectedLocalization[item.Rarity]);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.Description]+ " " + item.Description);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ItemType]+ " " + LocalizationsStash.SelectedLocalization[item.ItemType]);
        }

        public void ShowItemInfo(ItemWeaponDND5e item) 
        {
            PrintBaseStats(item);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageDiceCount]+ " " + item.DamageDiceCount);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageDiceValue]+ " " + item.DamageDiceValue);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageModificator]+ " " + item.DamageModificator);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.DamageType]+ " " + LocalizationsStash.SelectedLocalization[item.DamageType]);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProficiencyConcrete]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProficiencyConcrete]);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProficiencyGroup]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProficiencyGroup]);
                    _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.WeaponProperty]+ " " + LocalizationsStash.SelectedLocalization[item.WeaponProperty]);
        }

        public void ShowItemInfo(ItemArmorDND5e item) 
        {
            PrintBaseStats(item);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.StrengthRequirement]+ " " + item.StrengthRequirement);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ArmorClass]+ " " + item.ArmorClass);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.MaxAgilityBonus]+ " " + item.MaxAgilityBonus);
            _output.Print(LocalizationsStash.SelectedLocalization[EnumItemStatsDND5e.ArmorType]+ " " + item.ArmorType);
        }
    }
}