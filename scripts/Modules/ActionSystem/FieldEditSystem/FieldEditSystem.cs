using Spectre.Console;

namespace dnd_character_sheet
{
    public class FieldEditSystem : IFieldEditSystem
    {
        private ConsoleKeyInfo _pressedKey;

        private ShowMenusCursor _showMenusCursor;
        private SheetRaceFactory _sheetRaceFactory;
        private SheetClassFactory _sheetClassFactory;
        private TextBuilder _textBuilder;
        private PanelCreate _panelCreate;
        private CursorSystem _cursor;
        private int _pointPosition;
        private bool _isExit;
        private ProficiencyAdderSystem _proficiencyAdderSystem;
        private Enum _choosenPoint;
        
        public FieldEditSystem()
        {
            _showMenusCursor = new ShowMenusCursor();
            _sheetRaceFactory = new SheetRaceFactory();
            _sheetClassFactory = new SheetClassFactory();
            _textBuilder = new TextBuilder();
            _panelCreate = new PanelCreate();
            _cursor = new CursorSystem();
            _proficiencyAdderSystem = new ProficiencyAdderSystem();
        }
        
        public string ChooseAction()
        {
            _pressedKey = Console.ReadKey();    
            switch (_pressedKey.Key)
            {
                case ConsoleKey.N:
                    return ChangeName();

                case ConsoleKey.C:
                    return ChangeClass();

                case ConsoleKey.R:
                    return ChangeRace();

                case ConsoleKey.A:
                    return ChangeAbilities();

                case ConsoleKey.S:
                    return ChangeSkills();

                case ConsoleKey.P:
                    return AddOrRemoveProficiency();

                case ConsoleKey.H:
                    return ChangeMaximumHP();

                case ConsoleKey.M:
                    return EditPersonality();

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }
        }

        private string ChangeName()
        {
            var name = Console.ReadLine();
            CurrentHeroSheet.HeroSheet.Name = name;
            return $"{LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.DoneNewName]}: {name}";
        }

        private string ChangeClass()
        {
            CurrentHeroSheet.HeroSheet.SetUpClass(
                _sheetClassFactory.CreateSheetClass(
                    _showMenusCursor.ShowMenuPoints(
                        EnumSheetCreateTitles.SelectAClassFromTheList, 
                        typeof(EnumClassesDnd5E)
                    )
                )
            );
            
            return $"{LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.DoneNewClass]}: {LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetClass.Name]}";
        }

        private string ChangeRace()
        {
            CurrentHeroSheet.HeroSheet.SetUpRace(
                _sheetRaceFactory.CreateSheetRace(
                    _showMenusCursor.ShowMenuPoints(
                        EnumSheetCreateTitles.SelectARaceFromTheList, 
                        typeof(EnumRacesDnd5E)
                    )
                )
            );

            return $"{LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.DoneNewRace]}: {LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetRace.Name]}";
        }

        private string ChangeAbilities()
        {
            _pointPosition = 0;
            _isExit = false;
            
            Console.Clear();
            AnsiConsole.Write(_panelCreate.MakePanelFromString(_textBuilder.BuildAbilities(), LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Abilities]));

            while (_isExit == false)
            {
                switch(_cursor.CursorSelector(1, 1, 6, ref _pointPosition))
                {
                    case ConsoleKey.RightArrow:
                        CurrentHeroSheet.HeroSheet.SheetAbilities.RaiseAbilityScore((EnumAbilitiesDnd5E)_pointPosition);
                        break;

                    case ConsoleKey.LeftArrow:
                        CurrentHeroSheet.HeroSheet.SheetAbilities.LowerAbilityScore((EnumAbilitiesDnd5E)_pointPosition);
                        break;

                    case ConsoleKey.Enter:
                    case ConsoleKey.Escape:
                        _isExit = true;
                        break;
                }

                Console.Clear();
                AnsiConsole.Write(_panelCreate.MakePanelFromString(_textBuilder.BuildAbilities(), LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Abilities]));
            }

            return LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.AbilityChange];
        }

        private string ChangeSkills()
        {
            _pointPosition = 0;
            _isExit = false;
            
            Console.Clear();
            AnsiConsole.Write(_panelCreate.MakePanelFromString(_textBuilder.BuildSkillsEditor(_pointPosition), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Skills]}[/]"));

            while (_isExit == false)
            {
                _pressedKey = Console.ReadKey();
                switch (_pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_pointPosition + 1 < Enum.GetNames(typeof(EnumSkillsDnd5E)).ToArray().Length)
                        {
                            _pointPosition++;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (_pointPosition - 1 >= 0)
                        {
                            _pointPosition--;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill((EnumSkillsDnd5E)_pointPosition))
                        {
                            CurrentHeroSheet.HeroSheet.SheetSkills.RemoveSkill((EnumSkillsDnd5E)_pointPosition);
                        }
                        else
                        {
                            CurrentHeroSheet.HeroSheet.SheetSkills.AddSkill((EnumSkillsDnd5E)_pointPosition);
                        }
                        break;

                    default:
                        _isExit = true;
                        break;
                }

                Console.Clear();
                AnsiConsole.Write(_panelCreate.MakePanelFromString(_textBuilder.BuildSkillsEditor(_pointPosition), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Skills]}[/]"));
            }
            
            return LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.SkillsChanged];
        }

        private string ChangeMaximumHP()
        {
            var maximumHP = ConsoleInput.InputInt();
            if (maximumHP < 1)
            {
                maximumHP = 1;
            }

            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP] = maximumHP;
            return $"{LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.NewValueMaximumHP]}: {maximumHP}";
        }

        private string AddOrRemoveProficiency()
        {
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.A:
                    return AddProficiency();

                case ConsoleKey.R:
                    return RemoveProficiency();
            }

            return string.Empty;
        }

        private string AddProficiency()
        {
            _proficiencyAdderSystem.StartAddProficiencies();

            return LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.ListOfProficienciesEdited];
        }

        private string RemoveProficiency()
        {
            _pointPosition = 0;
            _isExit = false;

            while (_isExit == false)
            {
                if (CurrentHeroSheet.HeroSheet.SheetProficiencies.Proficiencies.Count == 0)
                {
                    return LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.ListOfProficienciesEmpty];
                }
                else
                {
                    Console.Clear();
                    AnsiConsole.Write(_panelCreate.MakePanelFromString(_textBuilder.BuildProficienciesEditor(_pointPosition), $"[underline yellow]{LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Proficiencies]}[/]"));

                    _pressedKey = Console.ReadKey();
                    switch (_pressedKey.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (_pointPosition + 1 < CurrentHeroSheet.HeroSheet.SheetProficiencies.Proficiencies.Count)
                            {
                                _pointPosition++;
                            }
                            break;

                        case ConsoleKey.UpArrow:
                            if (_pointPosition - 1 >= 0)
                            {
                                _pointPosition--;
                            }
                            break;

                        case ConsoleKey.Enter:
                            CurrentHeroSheet.HeroSheet.SheetProficiencies.RemoveProficiency(CurrentHeroSheet.HeroSheet.SheetProficiencies.Proficiencies[_pointPosition]);
                            if (_pointPosition - 1 >= 0)
                            {
                                _pointPosition--;
                            }
                            break;

                        default:
                            _isExit = true;
                            break;
                    }
                }
            }

            return LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.ListOfProficienciesEdited];
        }

        private string EditPersonality()
        {
            _choosenPoint = _showMenusCursor.ShowMenuPoints(EnumWorkWithFieldsText.WhatPersonalityNeedToChange, typeof(EnumPersonalitiesDND5E));
            if (Enum.TryParse<EnumPersonalitiesDND5E>(_choosenPoint.ToString(), out EnumPersonalitiesDND5E result))
            {
                Console.Clear();
                Console.WriteLine($"{LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.WriteNewValue]}:\n");
                
                CurrentHeroSheet.HeroSheet.SheetPersonality.PersonalityList[result] = Console.ReadLine();
            }

            return LocalizationsStash.SelectedLocalization[EnumWorkWithFieldsText.PersonalityWasChanged];
        }
    }
}