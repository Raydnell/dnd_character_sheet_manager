namespace dnd_character_sheet
{
    public class ScreenCreateSheet : IScreen
    {
        private string _inputString;
        private Enum _choosenMenuPoint;

        private bool _isSet;
        private bool _isFieldEditing;

        private JsonSaveLoad _jsonSaveLoad;
        private PrintSheetInfo _printSheetInfo;
        private ShowMenusCursor _showMenusCursor;
        private SheetRaceFactory _sheetRaceFactory;
        private SheetClassFactory _sheetClassFactory;

        public ScreenCreateSheet()
        {
            _jsonSaveLoad = new JsonSaveLoad();
            _inputString = string.Empty;
            _printSheetInfo = new PrintSheetInfo();
            _showMenusCursor = new ShowMenusCursor();
            _sheetRaceFactory = new SheetRaceFactory();
            _sheetClassFactory = new SheetClassFactory();
        }

        public void ShowScreen()
        {
            Console.Clear();
            //Указание имени
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.EnterTheNameOfTheHero], false);
            CurrentHeroSheet.HeroSheet.Name = Console.ReadLine();

            //Указание расы
            CurrentHeroSheet.HeroSheet.SetUpRace(
                _sheetRaceFactory.CreateSheetRace(
                    _showMenusCursor.ShowMenuPoints(
                        EnumSheetCreateTitles.SelectARaceFromTheList, 
                        typeof(EnumRacesDnd5E)
                    )
                )
            );

            //Указание класса
            CurrentHeroSheet.HeroSheet.SetUpClass(
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
                CurrentHeroSheet.HeroSheet.SheetSkills.AddSkill(_showMenusCursor.ShowMenuPoints(EnumSheetCreateTitles.SelectASkillFromTheList, typeof(EnumSkillsDnd5E)));

                _isFieldEditing = IsNeedOneMore();
            }

            //Указание характеристик
            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.EnterTheCharacteristicsOfTheHero]);
            CurrentHeroSheet.HeroSheet.SheetAbilities.SetAbilities(ChooseAbilities());

            //Указание владений
            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipOfTheArmorType, typeof(EnumArmorProficienciesDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipOfAGroupOfWeapons, typeof(EnumWeaponsGroupsDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipFfASpecificWeapon, typeof(EnumWeaponsProficienciesDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipFfTools, typeof(EnumInstrumentsProficienciesDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipOfMusicalInstruments, typeof(EnumMusicalInstrumentProficienciesDND5E));

            SetUpProficiencies(CurrentHeroSheet.HeroSheet, EnumSheetCreateTitles.AddOwnershipOfGameSets, typeof(EnumGamingSetProficienciesDND5E));

            //Указание HP
            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.MaximumHP, (CurrentHeroSheet.HeroSheet.SheetClass.HitDice + CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution)));
            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.CurrentHP, CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP]);

            //Указание базового КД (без брони)
            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.ArmorClass, 10 + CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity));

            //Указание кости хитов
            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.CurrentHitDices, CurrentHeroSheet.HeroSheet.SheetProgression.Level);

            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.SpecifyTheCharactersOfTheHero]);
            foreach (var item in Enum.GetNames(typeof(EnumPersonalitiesDND5E)))
            {
                if (Enum.TryParse<EnumPersonalitiesDND5E>(item, out EnumPersonalitiesDND5E result))
                {
                    Console.WriteLine(LocalizationsStash.SelectedLocalization[result] + ": ", false);
                    CurrentHeroSheet.HeroSheet.SheetPersonality.AddPersonality(result, Console.ReadLine());
                }
            }

            //Указание умений
            SetUpTraits(CurrentHeroSheet.HeroSheet);

            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.HeresYourNewHero] + "\n");
            PrintSheetInfo.ShowSheetFields(CurrentHeroSheet.HeroSheet);
            Console.ReadKey();
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
                        Console.WriteLine(LocalizationsStash.SelectedLocalization[result] + ": ", false);
                        inputAbility = ConsoleInput.InputInt();
                        if (inputAbility > 0 && inputAbility <= 20)
                        {
                            tempAbilities[result] = inputAbility;
                            _isSet = true;
                        }
                        else
                        {
                            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.YouNeedToSpecifyAValueFrom1To20]);
                            Console.ReadKey();
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
                        Console.Clear();
                        Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.WriteTraitName] + "\n");
                        tempName = Console.ReadLine();

                        Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.WriteTraitSource] + "\n");
                        tempSource = Console.ReadLine();

                        Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.WriteTraitDescription] + "\n");
                        tempDescription = Console.ReadLine();

                        heroSheet.TraitsList.AddTrait(tempName, tempSource, tempDescription);
                        
                        _isFieldEditing = IsNeedOneMore();
                    }

                    break;
            }
        }
    }
}
