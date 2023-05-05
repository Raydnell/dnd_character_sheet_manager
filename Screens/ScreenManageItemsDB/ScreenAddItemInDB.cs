namespace dnd_character_sheet
{
    public class ScreenAddItemInDB : IScreen
    {
        private Enum _choosenPoint;
        private ShowMenusCursor _showMenuCursor;
        private IUserInput _input;
        private IUserOutput _output;
        private bool _isNeedToStay;
        private ItemBaseDND5e _newItem;
        private ItemsFabricDND5e _itemFabric;
        private ItemsDataBaseDND5e _itemDB;
        private PrintItemInfo _printItemInfo;

        public ScreenAddItemInDB()
        {
            _showMenuCursor = new ShowMenusCursor();
            _input = new ConsoleInput();
            _output = new ConsoleOutput();
            _itemFabric = new ItemsFabricDND5e();
            _itemDB = new ItemsDataBaseDND5e();
            _printItemInfo = new PrintItemInfo();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            //Загрузка базы
            
            _isNeedToStay = true;
            while (_isNeedToStay == true)
            {
                _newItem = _itemFabric.CreateItem(_showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhatTypeOfItemShouldAdd, typeof(EnumItemTypesDND5e)));

                //Проверка, что в базе нет такого ID
                _newItem.SetItemId();

                //Указание базовых параметров
                SetBaseItemStats(_newItem);

                //Указание отличительных параметров
                switch(_newItem.ItemType)
                {
                    case EnumItemTypesDND5e.Armor:
                        SetArmorStats(_newItem);
                        break;
                    
                    case EnumItemTypesDND5e.Weapon:
                        SetWeaponStats(_newItem);
                        break;
                }

                _output.Clear();
                _printItemInfo.ShowItemInfo(_newItem);
                _input.InputKey();

                _itemDB.AddItem(_newItem);
                JsonSaveLoad.JsonSave("DND5eItemsDB", _itemDB, @"DB\");

                _isNeedToStay = BreakOrContinue();
            }
        }

        private void SetBaseItemStats(ItemBaseDND5e item)
        {
            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.NameOfTheItem] + "\n");
            item.SetName(_input.InputString());
            
            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.TheCostOfItemInGold] + "\n");
            item.SetBaseCost(_input.InputInt());

            _output.Clear();
            _output.Print(LocalizationsStash.SelectedLocalization[EnumAddItemInDBTitles.ItemWeightPounds] + "\n");
            item.SetWeight(_input.InputInt());

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

        private void SetWeaponStats(ItemBaseDND5e item)
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

            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhatDamageType, typeof(EnumItemDamageTypesDND5e));
            if (Enum.TryParse<EnumItemDamageTypesDND5e>(_choosenPoint.ToString(), out EnumItemDamageTypesDND5e damageType))
            {
                item.SetDamageType(damageType);
            }

            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumAddItemInDBTitles.WhatWeaponProperties, typeof(EnumWeaponPropertiesDND5e));
            if (Enum.TryParse<EnumWeaponPropertiesDND5e>(_choosenPoint.ToString(), out EnumWeaponPropertiesDND5e propertie))
            {
                item.SetWeaponProperty(propertie);
            }
        }
    
        private void SetArmorStats(ItemBaseDND5e item)
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
    
        private bool BreakOrContinue()
        {
            _choosenPoint = _showMenuCursor.ShowMenuPoints(EnumSheetCreateTitles.AddMore, typeof(EnumYesNo));
            if (Enum.TryParse<EnumYesNo>(_choosenPoint.ToString(), out EnumYesNo result))
            {
                switch(result)
                {
                    case EnumYesNo.Yes:
                        return true;

                    case EnumYesNo.No:
                        return false;
                }
            }

            return false;
        }
    }
}