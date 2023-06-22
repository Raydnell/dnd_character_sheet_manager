namespace dnd_character_sheet
{
    public class ScreenCreateSheet : IScreen
    {
        private Enum _choosenMenuPoint;

        private bool _isSet;
        private bool _isFieldEditing;

        private ShowMenusCursor _showMenusCursor;
        private SheetRaceFactory _sheetRaceFactory;
        private SheetClassFactory _sheetClassFactory;
        private ProficiencyAdderSystem _proficiencyAdderSystem;

        public ScreenCreateSheet()
        {
            _showMenusCursor = new ShowMenusCursor();
            _sheetRaceFactory = new SheetRaceFactory();
            _sheetClassFactory = new SheetClassFactory();
            _proficiencyAdderSystem = new ProficiencyAdderSystem();
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
                var skill = _showMenusCursor.ShowMenuPoints(EnumSheetCreateTitles.SelectASkillFromTheList, typeof(EnumSkillsDnd5E));
                CurrentHeroSheet.HeroSheet.SheetSkills.AddSkill((EnumSkillsDnd5E)skill);
                _isFieldEditing = IsNeedOneMore();
            }

            //Указание характеристик
            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumSheetCreateTitles.EnterTheCharacteristicsOfTheHero]);
            CurrentHeroSheet.HeroSheet.SheetAbilities.SetAbilities(ChooseAbilities());

            //Указание владений
            _proficiencyAdderSystem.StartAddProficiencies();

            //Указание HP
            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.MaximumHP, ((int)CurrentHeroSheet.HeroSheet.SheetClass.HitDice + CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution)));
            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.CurrentHP, CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP]);

            //Указание базового КД (без брони)
            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.ArmorClass, 10 + CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity));

            //Указание кости хитов
            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.ChangeStat(EnumCombatStatsDND5e.CurrentHitDices, CurrentHeroSheet.HeroSheet.SheetProgression.Level);

            //Указание спасбросков
            CurrentHeroSheet.HeroSheet.SheetSaveThrows.SetSaveTrows(CurrentHeroSheet.HeroSheet.SheetClass.Name);

            //Указание персоналий
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
