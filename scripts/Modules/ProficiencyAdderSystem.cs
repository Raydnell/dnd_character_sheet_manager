namespace dnd_character_sheet
{
    public class ProficiencyAdderSystem
    {
        private bool _isFieldEditing;
        
        private Enum _choosenMenuPoint;
        private ShowMenusCursor _showMenusCursor;
        
        public ProficiencyAdderSystem()
        {
            _showMenusCursor = new ShowMenusCursor();
        }

        public void StartAddProficiencies()
        {
            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipOfTheArmorType, typeof(EnumArmorProficienciesDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipOfAGroupOfWeapons, typeof(EnumWeaponsGroupsDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipFfASpecificWeapon, typeof(EnumWeaponsProficienciesDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipFfTools, typeof(EnumInstrumentsProficienciesDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipOfMusicalInstruments, typeof(EnumMusicalInstrumentProficienciesDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipOfGameSets, typeof(EnumGamingSetProficienciesDND5E));
        }

        private void SetUpProficiencies(CharacterSheetBase heroSheet, Enum selectetTitle, Type menuPoints)
        {
            _choosenMenuPoint = _showMenusCursor.ShowMenuPoints(selectetTitle, typeof(EnumYesNo));

            switch(_choosenMenuPoint)
            {
                case EnumYesNo.Yes:
                    _isFieldEditing = true;
                    while (_isFieldEditing == true)
                    {
                        heroSheet.SheetProficiencies.AddProficiency(_showMenusCursor.ShowMenuPoints(EnumSheetCreateTitles.WhatOwnershipToAdd, menuPoints));
                        _isFieldEditing = IsNeedOneMore();
                    }
                    break;
            }
        }

        private bool IsNeedOneMore()
        {
            _choosenMenuPoint = _showMenusCursor.ShowMenuPoints(EnumSheetCreateTitles.AddMore, typeof(EnumYesNo));

            switch(_choosenMenuPoint)
            {
                case EnumYesNo.Yes:
                    return true;

                case EnumYesNo.No:
                    return false;
            }

            return false;
        }
    }
}