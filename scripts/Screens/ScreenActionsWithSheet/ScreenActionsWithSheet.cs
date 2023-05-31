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
        private int _rollModificatorOne;
        private int _diceRollResult;
        private string _rollDescription;
        private int _proficiencyBonus;
        private IScreen _screen;

        public ScreenActionsWithSheet()
        {
            _stringBuilder = new StringBuilder();
            _table = new Table();
            _random = new Random();
            _logMessages = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        }

        public void ShowScreen()
        {
            Console.Clear();
            FillTable(_table);
            AnsiConsole.Write(_table);
            _proficiencyBonus = CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus();

            _isExit = false;
            while (_isExit == false)
            {
                _pressedKey = Console.ReadKey();

                switch (_pressedKey.Key)
                {
                    case ConsoleKey.A:
                        MakeAbilityCheck();
                        _logPanel = NewMessageToLog(_rollDescription + " 1d20 + " + _rollModificatorOne + " : " + _diceRollResult + " + " + _rollModificatorOne + " = " + (_rollModificatorOne + _diceRollResult));
                        
                        Console.Clear();
                        _table.UpdateCell(0, 3, _logPanel);
                        AnsiConsole.Write(_table);
                        break;

                    case ConsoleKey.Q:
                        if (MakeSaveThrowCheck())
                        {
                            _logPanel = NewMessageToLog(_rollDescription + " 1d20 + " + _rollModificatorOne + " + " + _proficiencyBonus + " : " + _diceRollResult + " + " + _rollModificatorOne + " + " + _proficiencyBonus + " = " + (_rollModificatorOne + _diceRollResult + _proficiencyBonus));
                        }
                        else
                        {
                            _logPanel = NewMessageToLog(_rollDescription + " 1d20 + " + _rollModificatorOne + " : " + _diceRollResult + " + " + _rollModificatorOne + " = " + (_rollModificatorOne + _diceRollResult));
                        }
                        
                        Console.Clear();
                        _table.UpdateCell(0, 3, _logPanel);
                        AnsiConsole.Write(_table);
                        break;

                    case ConsoleKey.S:
                        if (MakeSkillCheck())
                        {
                            _logPanel = NewMessageToLog(_rollDescription + " 1d20 + " + _rollModificatorOne + " + " + _proficiencyBonus + " : " + _diceRollResult + " + " + _rollModificatorOne + " + " + _proficiencyBonus + " = " + (_rollModificatorOne + _diceRollResult + _proficiencyBonus));
                        }
                        else
                        {
                            _logPanel = NewMessageToLog(_rollDescription + " 1d20 + " + _rollModificatorOne + " : " + _diceRollResult + " + " + _rollModificatorOne + " = " + (_rollModificatorOne + _diceRollResult));
                        }
                        
                        Console.Clear();
                        _table.UpdateCell(0, 3, _logPanel);
                        AnsiConsole.Write(_table);
                        break;

                    case ConsoleKey.I:
                        _screen = new ScreenWorkWithInventory();
                        _screen.ShowScreen();
                        break;
                    
                    case ConsoleKey.Escape:
                        _isExit = true;
                        break;
                }
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

            table.AddRow(CreateMainPanel(), CreateAbilityPanel(), CreatePersonalityPanel(), NewMessageToLog(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.RollResultsWillBeHere]));
            table.AddRow(CreateSkillPanel(), CreateProficienciesPanel(), CreateCombatPanel(), CreateEquipmentPanel());
            table.AddRow(CreateScreensPanel());
        }

        private int CalculatePassiveWisdom()
        {
            return 8 + CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom) + (CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perception) ? CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() : 0);
        }

        private void MakeAbilityCheck()
        {
            _diceRollResult = _random.Next(1, (DiceEdges.Dices[5] + 1));    
            
            var pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityStrength];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength);
                    break;

                case ConsoleKey.D2:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityDexterity];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity);
                    break;

                case ConsoleKey.D3:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityConstitution];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution);
                    break;

                case ConsoleKey.D4:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityIntelligence];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Intelligence);
                    break;

                case ConsoleKey.D5:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityWisdom];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom);
                    break;

                case ConsoleKey.D6:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityCharisma];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Charisma);
                    break;
            }
        }

        private bool MakeSaveThrowCheck()
        {
            _diceRollResult = _random.Next(1, (DiceEdges.Dices[5] + 1));
            
            var pressedKey = Console.ReadKey();    
            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowStrength];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength);
                    return CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Strength);

                case ConsoleKey.D2:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowDexterity];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity);
                    return CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Dexterity);

                case ConsoleKey.D3:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowConstitution];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution);
                    return CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Constitution);

                case ConsoleKey.D4:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowIntelligence];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Intelligence);
                    return CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Intelligence);

                case ConsoleKey.D5:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowWisdom];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom);
                    return CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Wisdom);

                case ConsoleKey.D6:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowCharisma];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Charisma);
                    return CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Charisma);
            
                default:
                    return false;
            }
        }

        private bool MakeSkillCheck()
        {
            _diceRollResult = _random.Next(1, (DiceEdges.Dices[5] + 1));
            
            var pressedKey = Console.ReadKey();    
            switch (pressedKey.Key)
            {
                case ConsoleKey.Q:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillAthletics];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Athletics);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Athletics);

                case ConsoleKey.W:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillAcrobatics];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Athletics);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Athletics);

                case ConsoleKey.E:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillSleight];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Sleight);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Sleight);

                case ConsoleKey.R:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillStealth];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Stealth);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Stealth);

                case ConsoleKey.T:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillArcana];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Arcana);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Arcana);

                case ConsoleKey.Y:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillHistory];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.History);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.History);

                case ConsoleKey.A:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillInvestigation];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Investigation);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Investigation);

                case ConsoleKey.S:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillNature];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Nature);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Nature);

                case ConsoleKey.D:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillReligion];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Religion);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Religion);

                case ConsoleKey.F:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillAnimal];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Animal);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Animal);

                case ConsoleKey.G:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillInsight];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Insight);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Insight);

                case ConsoleKey.H:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillMedicine];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Medicine);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Medicine);

                case ConsoleKey.Z:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillPerception];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Perception);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perception);

                case ConsoleKey.X:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillSurival];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Surival);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Surival);

                case ConsoleKey.C:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillDeception];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Deception);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Deception);

                case ConsoleKey.V:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillIntimidation];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Intimidation);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Intimidation);

                case ConsoleKey.B:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillPerfomance];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Perfomance);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perfomance);

                case ConsoleKey.N:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillPersuasion];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Persuasion);
                    return CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Persuasion);

                default:
                    return false;
            }
        }

        private int GetSkillModificator(EnumSkillsDnd5E skill)
        {
            return CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(CurrentHeroSheet.HeroSheet.SheetSkills.SkillAbilityName(skill));
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
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.MessageBox]);
            tempPanel.HeaderAlignment(Justify.Center);

            return tempPanel;
        }

        private Panel CreateEquipmentPanel()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            if (CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots.Count == 0)
            {
                _stringBuilder.Append(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.EmptyEquipmentSlots]);
            }
            else
            {
                foreach (var item in CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots)
                {
                    _stringBuilder.Append(LocalizationsStash.SelectedLocalization[item.Key] + ": " + item.Value.Name + "\n");
                }
            }
            
            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.EquipmentSlots]);
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }

        private Panel CreateScreensPanel()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);

            _stringBuilder.Append(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.Inventory] + "\n" + LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.Spells] + "\n" + LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.SheetEdit]);
            
            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.OpenScreens]);
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }        
    }
}