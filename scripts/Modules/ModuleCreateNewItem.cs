namespace dnd_character_sheet
{
    public class ModuleCreateNewItem
    {
        private Enum _choosenPoint;
        private ShowMenusCursor _showMenuCursor;
        private IUserOutput _output;
        private IUserInput _input;
        private ItemBaseDND5e _newItem;
        private PrintItemInfo _printItemInfo;
        
        public ModuleCreateNewItem()
        {
            _showMenuCursor = new ShowMenusCursor();
            _output = new ConsoleOutput();
            _input = new ConsoleInput();
            _printItemInfo = new PrintItemInfo();
        }

        public ItemBaseDND5e CreateItem()
        {
            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhatTypeOfItemShouldAdd, typeof(EnumItemTypesDND5e));
            if (Enum.TryParse<EnumItemTypesDND5e>(_choosenPoint.ToString(), out EnumItemTypesDND5e result))
            {
                switch(result)
                {
                    case EnumItemTypesDND5e.Item:
                        _newItem = new ItemRegularDND5e();
                        SetBaseItemStats(_newItem, ItemsDataBaseDND5e.ItemsDB);
                        return _newItem;

                    case EnumItemTypesDND5e.Armor:
                        _newItem = new ItemArmorDND5e();
                        SetBaseItemStats(_newItem, ItemsDataBaseDND5e.ItemsDB);
                        SetArmorStats((ItemArmorDND5e)_newItem);
                        return _newItem;

                    case EnumItemTypesDND5e.Weapon:
                        _newItem = new ItemWeaponDND5e();
                        SetBaseItemStats(_newItem, ItemsDataBaseDND5e.ItemsDB);
                        SetWeaponStats((ItemWeaponDND5e)_newItem);
                        return _newItem;

                    case EnumItemTypesDND5e.Coin:
                        _newItem = new ItemCoinDND5e();
                        SetBaseItemStats(_newItem, ItemsDataBaseDND5e.ItemsDB);
                        SetCoinStats((ItemCoinDND5e)_newItem);
                        return _newItem;
                }
            }
            
            return new ItemRegularDND5e();
        }

        private void SetBaseItemStats(ItemBaseDND5e item, Dictionary<int, ItemBaseDND5e> itemsDB)
        {
            bool isIdUniq = false;

            while (isIdUniq == false)
            {
                item.SetItemId();
                if (ItemsDataBaseDND5e.ItemsDB.ContainsKey(item.ItemId) == false)
                {
                    isIdUniq = true;
                }
            }
            
            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.NameOfTheItem] + "\n");
            item.SetName(_input.InputString());
            
            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.TheCostOfItemInGold] + "\n");
            item.SetBaseCost(Single.Parse(_input.InputString()));

            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.ItemWeightPounds] + "\n");
            item.SetWeight(Single.Parse(_input.InputString()));

            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.Rare, typeof(EnumItemRarityTypes));
            if (Enum.TryParse<EnumItemRarityTypes>(_choosenPoint.ToString(), out EnumItemRarityTypes result))
            {
                item.SetRarity(result);
            }

            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.Description] + "\n");
            item.SetDescription(_input.InputString());

            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.Magical, typeof(EnumYesNo));
            switch(_choosenPoint)
            {
                case EnumYesNo.Yes:
                    item.SetIsMagic(true);
                    break;

                case EnumYesNo.No:
                    item.SetIsMagic(false);
                    break;
            }

            _output.Clear();

        }

        private void SetWeaponStats(ItemWeaponDND5e item)
        {
            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhichGroupThisWeapon, typeof(EnumWeaponsGroupsDND5E));
            if (Enum.TryParse<EnumWeaponsGroupsDND5E>(_choosenPoint.ToString(), out EnumWeaponsGroupsDND5E group))
            {
                item.SetWeaponGroup(group);
            }

            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhichBasicWeaponCanAttributedTo, typeof(EnumWeaponsProficienciesDND5E));
            if (Enum.TryParse<EnumWeaponsProficienciesDND5E>(_choosenPoint.ToString(), out EnumWeaponsProficienciesDND5E concrete))
            {
                item.SetWeaponConcreteProf(concrete);
            }
            
            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.HowManyDamageDices] + "\n");
            item.SetDamageDiceCount(_input.InputInt());

            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.WhatDamageDice] + "\n");
            item.SetDamageDiceValue(_input.InputInt());

            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.WhatModificator] + "\n");
            item.SetDamageModificator(_input.InputInt());

            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhatWeaponProperties, typeof(EnumWeaponPropertiesDND5e));
            if (Enum.TryParse<EnumWeaponPropertiesDND5e>(_choosenPoint.ToString(), out EnumWeaponPropertiesDND5e propertie))
            {
                item.SetWeaponProperty(propertie);
            }
        }
    
        private void SetArmorStats(ItemArmorDND5e item)
        {
            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhatArmorType, typeof(EnumArmorProficienciesDND5E));
            if (Enum.TryParse<EnumArmorProficienciesDND5E>(_choosenPoint.ToString(), out EnumArmorProficienciesDND5E armorType))
            {
                item.SetArmorType(armorType);
            }

            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.WhatStrenghtRequirement] + "\n");
            item.SetStrengthRequirement(_input.InputInt());

            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.WhatArmorClass] + "\n");
            item.SetArmorClass(_input.InputInt());

            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.WhatArmorMaxDexteritiBonus] + "\n");
            item.SetMaxAgilityBonus(_input.InputInt());
        }    

        private void SetCoinStats(ItemCoinDND5e item)
        {
            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhatCoinType, typeof(EnumCoinsTypeDND5e));
            if (Enum.TryParse<EnumCoinsTypeDND5e>(_choosenPoint.ToString(), out EnumCoinsTypeDND5e coinType))
            {
                item.SetCoinType(coinType);
            }
        }    
    }
}