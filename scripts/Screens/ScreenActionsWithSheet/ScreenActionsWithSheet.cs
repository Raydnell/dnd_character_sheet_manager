using Spectre.Console;
using System.Text;

namespace dnd_character_sheet
{
    public class ScreenActionsWithSheet : IScreen
    {
        private StringBuilder _stringBuilder;
        private Table _table;
        private bool _isExit;
        private ConsoleKeyInfo _pressedKey;
        private Random _random;
        private string[] _logMessages;
        private Panel _logPanel;
        private string _amountOfDices;
        private int _rollModificator;
        private int _fullRollResult;
        private int _diceRollResult; //Ability roll! 1d20 + 2 : 13 + 2 = 15!

        public ScreenActionsWithSheet()
        {
            _stringBuilder = new StringBuilder();
            _table = new Table();
            _random = new Random();
            _logMessages = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        }

        public void ShowScreen()
        {
            Console.Clear();
            FillTable(_table);
            AnsiConsole.Write(_table);

            _isExit = false;
            while (_isExit == false)
            {
                _pressedKey = Console.ReadKey();

                switch (_pressedKey.Key)
                {
                    case ConsoleKey.A:
                        _fullRollResult = MakeAbilityCheck();
                        _logPanel = NewMessageToLog("Ability roll! 1d20 + " + _rollModificator.ToString() + " : " + _diceRollResult.ToString() + " + " + _rollModificator.ToString() + " = " + _fullRollResult.ToString());
                        break;

                    case ConsoleKey.Q:
                        _logPanel = NewMessageToLog("\nSavethow roll! " + MakeSaveThrowCheck());
                        break;

                    case ConsoleKey.S:
                        _logPanel = NewMessageToLog("\nSkill roll! " + MakeSkillCheck());
                        break;
                }

                Console.Clear();
                _table.UpdateCell(0, 3, _logPanel);
                AnsiConsole.Write(_table);
            }
        }

        private Panel CreateAbilityPanel()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetAbilities.Abilities)
            {
                if (CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(item.Key))
                {
                    _stringBuilder.Append("[[X]] " + LocalizationsStash.SelectedLocalization[item.Key] + " " + item.Value + "\n");
                }
                else
                {
                    _stringBuilder.Append("[[ ]] " + LocalizationsStash.SelectedLocalization[item.Key] + " " + item.Value + "\n");
                }
            }

            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Abilities]);
            tempPanel.HeaderAlignment(Justify.Center);

            return tempPanel;
        }

        private Panel CreateSkillPanel()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);

            foreach (var item in Enum.GetNames(typeof(EnumSkillsDnd5E)))
            {
                if (Enum.TryParse<EnumSkillsDnd5E>(item, out EnumSkillsDnd5E result))
                {
                    if (CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(result))
                    {
                        _stringBuilder.Append("[[X]] " + LocalizationsStash.SelectedLocalization[result] + "\n");
                    }
                    else
                    {
                        _stringBuilder.Append("[[ ]] " + LocalizationsStash.SelectedLocalization[result] + "\n");
                    }
                }
            }

            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Skills]);
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }

        private Panel CreateProficienciesPanel()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetProficiencies.Proficiencies)
            {
                _stringBuilder.Append(LocalizationsStash.SelectedLocalization[item] + "\n");
            }

            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Proficiencies]);
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }

        private Panel CreateCombatPanel()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HP] + ": " + 
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP] + @"\" + 
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP] + "\n"
            );

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.THP] + ": " +
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.TemporaryHP] + "\n"
            );

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Speed] + ": " +
                CurrentHeroSheet.HeroSheet.SheetRace.Speed + "\n"
            );

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.AC] + ": " +
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.ArmorClass] + "\n"
            );

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.DeathDices] + ": " +
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathFailure] + @"\" + 
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathSucces]
            );

            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.CombatStats]);
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }

        private Panel CreateMainPanel()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            _stringBuilder.Append(
                CurrentHeroSheet.HeroSheet.Name + "\n" +
                LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetClass.Name] + "\n" +
                LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetRace.Name] + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Level] + " " + CurrentHeroSheet.HeroSheet.SheetProgression.Level + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Expirience] + " " + CurrentHeroSheet.HeroSheet.SheetProgression.Expirience + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.ProficiencyBonus] + " " + CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.PassiveWisdom] + " " + CalculatePassiveWisdom() + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Size] + " " + LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetRace.Size] + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HitDice] + " " + CurrentHeroSheet.HeroSheet.SheetClass.HitDice + "\n" +
                "[[ ]] " + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Inspiration]
            );

            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Hero]);
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }

        private Panel CreatePersonalityPanel()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetPersonality.PersonalityList)
            {
                _stringBuilder.Append(LocalizationsStash.SelectedLocalization[item.Key] + ": " + item.Value + "\n");
            }

            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.PersonalityList]);
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }

        private void FillTable(Table table)
        {
            table.AddColumns(new string[]{ "1", "2", "3", "4" });
            table.HideHeaders();

            table.AddRow(CreateMainPanel(), CreateAbilityPanel(), CreatePersonalityPanel(), NewMessageToLog("Тут будут новые броски"));
            table.AddRow(CreateSkillPanel(), CreateProficienciesPanel(), CreateCombatPanel());
        }

        private int CalculatePassiveWisdom()
        {
            return 8 + CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom) + (CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perception) ? CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() : 0);
        }

        private int MakeAbilityCheck()
        {
            var pressedKey = Console.ReadKey();
            _diceRollResult = _random.Next(1, DiceEdges.Dices[5]);    
            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:
                    _rollModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength);
                    return _diceRollResult + _rollModificator;

                case ConsoleKey.D2:
                    _rollModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity);
                    return _diceRollResult + _rollModificator;

                case ConsoleKey.D3:
                    _rollModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution);
                    return _diceRollResult + _rollModificator;

                case ConsoleKey.D4:
                    _rollModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Intelligence);
                    return _diceRollResult + _rollModificator;

                case ConsoleKey.D5:
                    _rollModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom);
                    return _diceRollResult + _rollModificator;

                case ConsoleKey.D6:
                    _rollModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Charisma);
                    return _diceRollResult + _rollModificator;
            
                default:
                    return 0;
            }
        }

        private int MakeSaveThrowCheck()
        {
            var pressedKey = Console.ReadKey();    
            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:
                    return 
                        CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Strength) ? 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength) + 
                            CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()
                        ) : 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength)
                        );

                case ConsoleKey.D2:
                    return 
                        CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Dexterity) ? 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity) + 
                            CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()
                        ) : 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity)
                        );

                case ConsoleKey.D3:
                    return 
                        CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Constitution) ? 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution) + 
                            CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()
                        ) : 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution)
                        );

                case ConsoleKey.D4:
                    return 
                        CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Intelligence) ? 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Intelligence) + 
                            CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()
                        ) : 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Intelligence)
                        );

                case ConsoleKey.D5:
                    return 
                        CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Wisdom) ? 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom) + 
                            CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()
                        ) : 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom)
                        );

                case ConsoleKey.D6:
                    return 
                        CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Charisma) ? 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Charisma) + 
                            CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()
                        ) : 
                        (
                            _random.Next(1, DiceEdges.Dices[5]) + 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Charisma)
                        );
            
                default:
                    return 0;
            }
        }

        private int MakeSkillCheck()
        {
            var pressedKey = Console.ReadKey();    
            switch (pressedKey.Key)
            {
                case ConsoleKey.Q:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Athletics);

                case ConsoleKey.W:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Acrobatics);

                case ConsoleKey.E:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Sleight);

                case ConsoleKey.R:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Stealth);

                case ConsoleKey.T:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Arcana);

                case ConsoleKey.Y:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.History);

                case ConsoleKey.A:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Investigation);

                case ConsoleKey.S:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Nature);

                case ConsoleKey.D:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Religion);

                case ConsoleKey.F:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Animal);

                case ConsoleKey.G:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Insight);

                case ConsoleKey.H:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Medicine);

                case ConsoleKey.Z:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Perception);

                case ConsoleKey.X:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Surival);

                case ConsoleKey.C:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Deception);

                case ConsoleKey.V:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Intimidation);

                case ConsoleKey.B:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Perfomance);

                case ConsoleKey.N:
                    return _random.Next(1, DiceEdges.Dices[5]) + GetSkillModificator(EnumSkillsDnd5E.Persuasion);

                default:
                    return 0;
            }
        }

        private int GetSkillModificator(EnumSkillsDnd5E skill)
        {
            int proficiencyBonus = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(skill) ? CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() : 0;
            int abilityModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(CurrentHeroSheet.HeroSheet.SheetSkills.SkillAbilityName(skill));
            return proficiencyBonus + abilityModificator;
        }

        private Panel NewMessageToLog(string message)
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            for (int i = 1; i <= 9; i++)
            {
                _logMessages[9 - i + 1] = _logMessages[9 - i];
            }

            _logMessages[0] = message;

            foreach (var item in _logMessages)
            {
                _stringBuilder.Append(item + "\n");
            }

            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader("Message box");
            tempPanel.HeaderAlignment(Justify.Center);

            return tempPanel;
        }
    }
}