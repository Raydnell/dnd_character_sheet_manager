namespace dnd_character_sheet
{
    public class ScreenCreateSheet : IScreen
    {
        private string _inputString;
        private Enum _choosenMenuPoint;

        private bool _isSet;
        private bool _isFieldEditing;

        private JsonSaveLoad _jsonSaveLoad;
        private CharacterSheetFactory _sheetFactory;
        private IUserOutput _userOutput;
        private IUserInput _userInput;
        private PrintSheetInfo _printSheetInfo;
        private ShowMenusCursor _showMenusCursor;
        private SheetRaceFactory _sheetRaceFactory;
        private SheetClassFactory _sheetClassFactory;

        public ScreenCreateSheet()
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _sheetFactory = new CharacterSheetFactory();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _inputString = string.Empty;
            _printSheetInfo = new PrintSheetInfo();
            _showMenusCursor = new ShowMenusCursor();
            _sheetRaceFactory = new SheetRaceFactory();
            _sheetClassFactory = new SheetClassFactory();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            _userOutput.Clear();
            //Указание имени
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.EnterTheNameOfTheHero], false);
            heroSheet.Name = _userInput.InputString();

            //Указание расы
            heroSheet.SetUpRace(
                _sheetRaceFactory.CreateSheetRace(
                    _showMenusCursor.ShowMenuPoints(
                        EnumSheetCreateTitles.SelectARaceFromTheList, 
                        typeof(EnumRacesDnd5E)
                    )
                )
            );

            //Указание класса
            heroSheet.SetUpClass(
                _sheetClassFactory.CreateSheetClass(
                    _showMenusCursor.ShowMenuPoints(
                        EnumSheetCreateTitles.SelectAClassFromTheList, 
                        typeof(EnumClassesDnd5E)
                    )
                )
            );
                    
            //Указание скилов
            _isFieldEditing = true;
            while (_isFieldEditing == true)
            {
                heroSheet.SheetSkills.AddSkill(_showMenusCursor.ShowMenuPoints(EnumSheetCreateTitles.SelectASkillFromTheList, typeof(EnumSkillsDnd5E)));

                _isFieldEditing = IsNeedOneMore();
            }

            //Указание характеристик
            _userOutput.Clear();
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.EnterTheCharacteristicsOfTheHero]);
            heroSheet.SheetAbilities.SetAbilities(ChooseAbilities());

            //Указание владений
            SetUpProficiencies(heroSheet, EnumSheetCreateTitles.AddOwnershipOfTheArmorType, typeof(EnumArmorProficienciesDND5E));

            SetUpProficiencies(heroSheet, EnumSheetCreateTitles.AddOwnershipOfAGroupOfWeapons, typeof(EnumWeaponsGroupsDND5E));

            SetUpProficiencies(heroSheet, EnumSheetCreateTitles.AddOwnershipFfASpecificWeapon, typeof(EnumWeaponsProficienciesDND5E));

            SetUpProficiencies(heroSheet, EnumSheetCreateTitles.AddOwnershipFfTools, typeof(EnumInstrumentsProficienciesDND5E));

            SetUpProficiencies(heroSheet, EnumSheetCreateTitles.AddOwnershipOfMusicalInstruments, typeof(EnumMusicalInstrumentProficienciesDND5E));

            SetUpProficiencies(heroSheet, EnumSheetCreateTitles.AddOwnershipOfGameSets, typeof(EnumGamingSetProficienciesDND5E));

            //Указание HP
            heroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.MaximumHP, (heroSheet.SheetClass.HitDice + heroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution)));
            heroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.CurrentHP, heroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP]);

            //Указание базового КД (без брони)
            heroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.ArmorClass, 10 + heroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity));

            //Указание кости хитов
            heroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.CurrentHitDices, heroSheet.SheetProgression.Level);

            _userOutput.Clear();
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.SpecifyTheCharactersOfTheHero]);
            foreach (var item in Enum.GetNames(typeof(EnumPersonalitiesDND5E)))
            {
                if (Enum.TryParse<EnumPersonalitiesDND5E>(item, out EnumPersonalitiesDND5E result))
                {
                    _userOutput.Print(LocalizationsStash.SelectedLocalization[result] + ": ", false);
                    heroSheet.SheetPersonality.AddPersonality(result, _userInput.InputString());
                }
            }

            //Указание умений
            SetUpTraits(heroSheet);

            _userOutput.Clear();
            _userOutput.Print("Вот ваш новый герой!\n");
            _printSheetInfo.ShowSheetFields(heroSheet);
            _userInput.InputKey();
        }

        private Dictionary<Enum, int> ChooseAbilities()
        {
            Dictionary<Enum, int> tempAbilities = new Dictionary<Enum, int>();
            int inputAbility;

            foreach (var item in Enum.GetNames(typeof(EnumAbilitiesDnd5E)))
            {
                _isSet = false;
                while (_isSet == false)
                {
                    if (Enum.TryParse<EnumAbilitiesDnd5E>(item, out EnumAbilitiesDnd5E result))
                    {
                        _userOutput.Print(LocalizationsStash.SelectedLocalization[result] + ": ", false);
                        inputAbility = _userInput.InputInt();
                        if (inputAbility > 0 && inputAbility <= 20)
                        {
                            tempAbilities[result] = inputAbility;
                            _isSet = true;
                        }
                        else
                        {
                            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.YouNeedToSpecifyAValueFrom1To20]);
                            _userInput.InputKey();
                        }
                    }
                }
            }

            return tempAbilities;
        }

        private int SetUpPassiveWisdom(int wisdomModificator, int perceptionModificator, bool havePerception)
        {
            if (havePerception)
            {
                return 10 + wisdomModificator + perceptionModificator;
            }
            else
            {
                return 10 + wisdomModificator;
            }
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

        private int GetSpeedByRace(Enum race)
        {
            switch (race)
            {
                case EnumRacesDnd5E.Gnome:
                case EnumRacesDnd5E.Dwarf:
                case EnumRacesDnd5E.Halfling:
                    return 25;

                case EnumRacesDnd5E.Dragonborn:
                case EnumRacesDnd5E.Halforc:
                case EnumRacesDnd5E.Halfelf:
                case EnumRacesDnd5E.Tiefling:
                case EnumRacesDnd5E.Human:
                case EnumRacesDnd5E.Elf:
                    return 30;

                default:
                    return 30;
            }
        }

        private int GetClassHitDice(Enum sheetClass)
        {
            switch (sheetClass)
            {
                default:
                case EnumClassesDnd5E.Warlock:
                case EnumClassesDnd5E.Wizard:
                    return 6;

                case EnumClassesDnd5E.Bard:
                case EnumClassesDnd5E.Cleric:
                case EnumClassesDnd5E.Druid:
                case EnumClassesDnd5E.Monk:
                case EnumClassesDnd5E.Rogue:
                case EnumClassesDnd5E.Sorcerer:
                    return 8;

                case EnumClassesDnd5E.Fighter:
                case EnumClassesDnd5E.Paladin:
                case EnumClassesDnd5E.Ranger:
                    return 10;

                case EnumClassesDnd5E.Barbarian:
                    return 12;
            }
        }

        private void SetUpTraits(CharacterSheetBase heroSheet)
        {
            _choosenMenuPoint = _showMenusCursor.ShowMenuPoints(EnumSheetCreateTitles.IsNeedToAddTraits, typeof(EnumYesNo));

            switch(_choosenMenuPoint)
            {
                case EnumYesNo.Yes:
                    string tempName;
                    string tempSource;
                    string tempDescription;

                    _isFieldEditing = true;
                    while (_isFieldEditing == true)
                    {
                        _userOutput.Clear();
                        _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.WriteTraitName] + "\n");
                        tempName = _userInput.InputString();

                        _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.WriteTraitSource] + "\n");
                        tempSource = _userInput.InputString();

                        _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.WriteTraitDescription] + "\n");
                        tempDescription = _userInput.InputString();

                        heroSheet.TraitsList.AddTrait(tempName, tempSource, tempDescription);
                        
                        _isFieldEditing = IsNeedOneMore();
                    }

                    break;
            }
        }
    }
}
