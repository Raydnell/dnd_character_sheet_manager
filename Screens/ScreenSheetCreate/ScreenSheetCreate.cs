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
            _userOutput.Print(LocalizationsStash.ScreenSheetCreateTitles[EnumSheetCreateTitles.EnterTheNameOfTheHero][language], false);
            heroSheet.Name = _userInput.InputString();

            //Указание расы
            heroSheet.SheetRace.SetRace(
                LocalizationsStash.DND5eRaces[
                    _showMenusCursor.ShowMenuPoints(
                        LocalizationsStash.ScreenSheetCreateTitles, 
                        LocalizationsStash.DND5eRaces,
                        language, 
                        EnumSheetCreateTitles.SelectARaceFromTheList
                    )
                ][language]
            );

            //Указание класса
            heroSheet.SheetClass.SetClass(
                LocalizationsStash.DND5eClasses[
                    _showMenusCursor.ShowMenuPoints(
                        LocalizationsStash.ScreenSheetCreateTitles,
                        LocalizationsStash.DND5eClasses,
                        language,
                        EnumSheetCreateTitles.SelectAClassFromTheList
                    )
                ][language]
            );

            //Указание скилов
            _isFieldEditing = true;
            while (_isFieldEditing == true)
            {
                heroSheet.SheetSkills.AddSkill(
                    LocalizationsStash.DND5eSkills[
                        _showMenusCursor.ShowMenuPoints(
                            LocalizationsStash.ScreenSheetCreateTitles,
                            LocalizationsStash.DND5eSkills,
                            language,
                            EnumSheetCreateTitles.SelectASkillFromTheList
                        )
                    ][language]
                );

                _isFieldEditing = IsNeedOneMore(language);
            }

            //Указание характеристик
            _userOutput.Clear();
            _userOutput.Print(LocalizationsStash.ScreenSheetCreateTitles[EnumSheetCreateTitles.EnterTheCharacteristicsOfTheHero][language]);
            heroSheet.SheetAbilities.SetAbilities(ChooseAbilities(language));

            //Указание владений
            SetUpProficiencies(
                heroSheet, 
                LocalizationsStash.DND5eArmor,
                language,
                EnumSheetCreateTitles.AddOwnershipOfTheArmorType
            );

            SetUpProficiencies(
                heroSheet, 
                LocalizationsStash.DND5EGroupsOfWeapons, 
                language,
                EnumSheetCreateTitles.AddOwnershipOfAGroupOfWeapons
            );

            SetUpProficiencies(
                heroSheet, 
                LocalizationsStash.DND5eWeapons, 
                language,
                EnumSheetCreateTitles.AddOwnershipFfASpecificWeapon
            );

            SetUpProficiencies(
                heroSheet, 
                LocalizationsStash.DND5eProfInstruments, 
                language,
                EnumSheetCreateTitles.AddOwnershipFfTools
            );

            SetUpProficiencies(
                heroSheet, 
                LocalizationsStash.DND5eMusicalInstruments, 
                language,
                EnumSheetCreateTitles.AddOwnershipOfMusicalInstruments
            );

            SetUpProficiencies(
                heroSheet, 
                LocalizationsStash.DND5eProfGamingSets, 
                language,
                EnumSheetCreateTitles.AddOwnershipOfGameSets
            );

            //Указание скорости
            heroSheet.SheetCombatAbilities.SetSpeed(GetRaceSpeed(heroSheet.SheetRace.Name));

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
                    heroSheet.SheetSkills.CheckSkill("Внимательсность")
                )
            );

            _userOutput.Clear();
            _userOutput.Print(LocalizationsStash.ScreenSheetCreateTitles[EnumSheetCreateTitles.SpecifyTheCharactersOfTheHero][language]);
            foreach (var item in LocalizationsStash.DND5ePersonalities)
            {
                if (item.Value.ContainsKey(language))
                {
                    _userOutput.Print(item.Value[language] + ": ", false);
                    heroSheet.SheetPersonality.AddPersonality(item.Value[language], _userInput.InputString());
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

            foreach (var item in LocalizationsStash.DND5eAbilities)
            {
                _isSet = false;
                while (_isSet == false)
                {
                    _userOutput.Print(item.Value[language] + ": ", false);
                    inputAbility = _userInput.InputInt();
                    if (inputAbility > 0 && inputAbility <= 20)
                    {
                        tempAbilities[item.Key] = inputAbility;
                        _isSet = true;
                    }
                    else
                    {
                        _userOutput.Print(LocalizationsStash.ScreenSheetCreateTitles[EnumSheetCreateTitles.YouNeedToSpecifyAValueFrom1To20][language]);
                        _userInput.InputKey();
                    }
                }
            }

            return tempAbilities;
        }

        private int GetRaceSpeed(string race)
        {
            switch (race)
            {
                case "Гном":
                case "Дварф":
                case "Полурослик":
                    return 25;

                case "Драконорожденный":
                case "Полуорк":
                case "Полуэльф":
                case "Тифлинг":
                case "Человек":
                case "Эльф":
                    return 30;

                default:
                    return 30;
            }
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

        private int GetClassHitDice(string sheetClass)
        {
            switch (sheetClass)
            {
                default:
                case "Чародей":
                case "Волщебник":
                    return 6;

                case "Бард":
                case "Жрец":
                case "Друид":
                case "Монах":
                case "Плут":
                case "Колдун":
                    return 8;

                case "Воин":
                case "Паладин":
                case "Следопыт":
                    return 10;

                case "Варвар":
                    return 12;
            }
        }

        private void SetUpProficiencies(CharacterSheetBase heroSheet, Dictionary<Enum, Dictionary<Enum, string>> menuPoints, Enum choosenLanguage, Enum selectetTitle)
        {
            _choosenMenuPoint = _showMenusCursor.ShowMenuPoints(
                LocalizationsStash.ScreenSheetCreateTitles,
                LocalizationsStash.YesNo,
                choosenLanguage,
                selectetTitle
            );

            switch(_choosenMenuPoint)
            {
                case EnumYesNo.Yes:
                    _isFieldEditing = true;
                    while (_isFieldEditing == true)
                    {
                        heroSheet.SheetProficiencies.AddProficiency(
                            menuPoints[ 
                                _showMenusCursor.ShowMenuPoints(
                                    LocalizationsStash.ScreenSheetCreateTitles, 
                                    menuPoints, 
                                    choosenLanguage, 
                                    EnumSheetCreateTitles.WhatOwnershipToAdd
                                )
                            ][choosenLanguage]
                        );

                        _isFieldEditing = IsNeedOneMore(choosenLanguage);
                    }
                    break;
            }
        }

        private bool IsNeedOneMore(Enum language)
        {
            _choosenMenuPoint = _showMenusCursor.ShowMenuPoints(
                LocalizationsStash.ScreenSheetCreateTitles,
                LocalizationsStash.YesNo,
                language,
                EnumSheetCreateTitles.AddMore
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
    }
}
