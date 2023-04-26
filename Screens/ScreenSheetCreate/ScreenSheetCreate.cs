namespace dnd_character_sheet
{
    public class ScreenSheetCreate : IScreen
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

        public ScreenSheetCreate()
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _sheetFactory = new CharacterSheetFactory();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _inputString = string.Empty;
            _printSheetInfo = new PrintSheetInfo();
            _showMenusCursor = new ShowMenusCursor();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet, Enum language)
        {
            _userOutput.Clear();
            //Указание имени
            _userOutput.Print(LocalizationsStash.Localizations[EnumSheetCreateTitles.EnterTheNameOfTheHero][language], false);
            heroSheet.Name = _userInput.InputString();

            //Указание расы
            heroSheet.SheetRace.SetRace(
                    _showMenusCursor.ShowMenuPoints(
                        EnumSheetCreateTitles.SelectARaceFromTheList,
                        typeof(EnumRacesDnd5E),
                        language
                    )
            );

            //Указание класса
            heroSheet.SheetClass.SetClass(
                    _showMenusCursor.ShowMenuPoints(
                        EnumSheetCreateTitles.SelectAClassFromTheList,
                        typeof(EnumClassesDnd5E),
                        language
                    )
            );

            //Указание скилов
            _isFieldEditing = true;
            while (_isFieldEditing == true)
            {
                heroSheet.SheetSkills.AddSkill(
                        _showMenusCursor.ShowMenuPoints(
                            EnumSheetCreateTitles.SelectASkillFromTheList,
                            typeof(EnumSkillsDnd5E),
                            language
                        )
                );

                _isFieldEditing = IsNeedOneMore(language);
            }

            //Указание характеристик
            _userOutput.Clear();
            _userOutput.Print(LocalizationsStash.Localizations[EnumSheetCreateTitles.EnterTheCharacteristicsOfTheHero][language]);
            heroSheet.SheetAbilities.SetAbilities(ChooseAbilities(language));

            //Указание владений
            SetUpProficiencies(
                heroSheet, 
                EnumSheetCreateTitles.AddOwnershipOfTheArmorType,
                typeof(EnumArmorProficienciesDND5E),
                language
            );

            SetUpProficiencies(
                heroSheet, 
                EnumSheetCreateTitles.AddOwnershipOfAGroupOfWeapons,
                typeof(EnumWeaponsGroupsDND5E), 
                language
            );

            SetUpProficiencies(
                heroSheet, 
                EnumSheetCreateTitles.AddOwnershipFfASpecificWeapon,
                typeof(EnumWeaponsProficienciesDND5E), 
                language
            );

            SetUpProficiencies(
                heroSheet, 
                EnumSheetCreateTitles.AddOwnershipFfTools,
                typeof(EnumInstrumentsProficienciesDND5E), 
                language
            );

            SetUpProficiencies(
                heroSheet, 
                EnumSheetCreateTitles.AddOwnershipOfMusicalInstruments,
                typeof(EnumMusicalInstrumentProficienciesDND5E), 
                language
            );

            SetUpProficiencies(
                heroSheet, 
                EnumSheetCreateTitles.AddOwnershipOfGameSets,
                typeof(EnumGamingSetProficienciesDND5E), 
                language
            );

            //Указание скорости
            heroSheet.SheetCombatAbilities.SetSpeed(GetSpeedByRace(heroSheet.SheetRace.Name));

            //Распределение спасбросков
            heroSheet.SheetSaveThrows.SetSaveTrows(heroSheet.SheetClass.Name);

            //Указание HP
            heroSheet.SheetCombatAbilities.SetMaximumHP(GetClassHitDice(heroSheet.SheetClass.Name) + heroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution));
            heroSheet.SheetCombatAbilities.SetCurrentHP(heroSheet.SheetCombatAbilities.MaximumHP);

            //Указание базового КД (без брони)
            heroSheet.SheetCombatAbilities.SetArmorClass(10 + heroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity));

            //Указание инициативы
            heroSheet.SheetCombatAbilities.SetInitiative(heroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity));

            //Указание кости хитов
            heroSheet.SheetCombatAbilities.SetTotalHitDices(heroSheet.SheetProgression.Level);
            heroSheet.SheetCombatAbilities.SetCurrentHitDices(heroSheet.SheetProgression.Level);
            heroSheet.SheetCombatAbilities.SetHitDice(GetClassHitDice(heroSheet.SheetClass.Name));

            //Указание пассивной внимательности
            heroSheet.SheetCombatAbilities.SetPassiveWisdom(
                SetUpPassiveWisdom(
                    heroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom),
                    heroSheet.SheetProgression.GetProficiencyBonus(),
                    heroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perception)
                )
            );

            _userOutput.Clear();
            _userOutput.Print(LocalizationsStash.Localizations[EnumSheetCreateTitles.SpecifyTheCharactersOfTheHero][language]);
            foreach (var item in Enum.GetNames(typeof(EnumPersonalitiesDND5E)))
            {
                if (Enum.TryParse<EnumPersonalitiesDND5E>(item, out EnumPersonalitiesDND5E result))
                {
                    _userOutput.Print(LocalizationsStash.Localizations[result][language] + ": ", false);
                    heroSheet.SheetPersonality.AddPersonality(result, _userInput.InputString());
                }
            }

            _userOutput.Clear();
            _userOutput.Print("Вот ваш новый герой!\n");
            _printSheetInfo.ShowSheetFields(heroSheet, language);
            _userInput.InputKey();
        }

        private Dictionary<Enum, int> ChooseAbilities(Enum language)
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
                        _userOutput.Print(LocalizationsStash.Localizations[result][language] + ": ", false);
                        inputAbility = _userInput.InputInt();
                        if (inputAbility > 0 && inputAbility <= 20)
                        {
                            tempAbilities[result] = inputAbility;
                            _isSet = true;
                        }
                        else
                        {
                            _userOutput.Print(LocalizationsStash.Localizations[EnumSheetCreateTitles.YouNeedToSpecifyAValueFrom1To20][language]);
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

        private void SetUpProficiencies(CharacterSheetBase heroSheet, Enum selectetTitle, Type menuPoints, Enum choosenLanguage)
        {
            _choosenMenuPoint = _showMenusCursor.ShowMenuPoints(
                selectetTitle,
                typeof(EnumYesNo),
                choosenLanguage
            );

            switch(_choosenMenuPoint)
            {
                case EnumYesNo.Yes:
                    _isFieldEditing = true;
                    while (_isFieldEditing == true)
                    {
                        heroSheet.SheetProficiencies.AddProficiency(
                                _showMenusCursor.ShowMenuPoints(
                                    EnumSheetCreateTitles.WhatOwnershipToAdd,
                                    menuPoints,
                                    choosenLanguage
                                )
                        );

                        _isFieldEditing = IsNeedOneMore(choosenLanguage);
                    }
                    break;
            }
        }

        private bool IsNeedOneMore(Enum language)
        {
            _choosenMenuPoint = _showMenusCursor.ShowMenuPoints(
                EnumSheetCreateTitles.AddMore,
                typeof(EnumYesNo),
                language
            );

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
    }
}
