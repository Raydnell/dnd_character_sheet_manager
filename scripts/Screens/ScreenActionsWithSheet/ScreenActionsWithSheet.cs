using Spectre.Console;
using System.Text;

namespace dnd_character_sheet
{
    public class ScreenActionsWithSheet : IScreen
    {
        private StringBuilder _stringBuilder;
        private Table _table;

        public ScreenActionsWithSheet()
        {
            _stringBuilder = new StringBuilder();
            _table = new Table();
        }

        public void ShowScreen()
        {
            Console.Clear();
            FillTable(_table);
            AnsiConsole.Write(_table);
            Console.ReadKey();
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
            table.AddColumns(new string[]{ "1", "2", "3" });
            table.AddColumn(new TableColumn("1231").Footer("123"));
            table.HideHeaders();
            table.ShowFooters();

            table.AddRow(CreateMainPanel(), CreateAbilityPanel(), CreatePersonalityPanel());
            table.AddRow(CreateSkillPanel(), CreateProficienciesPanel(), CreateCombatPanel());
        }

        private int CalculatePassiveWisdom()
        {
            return 8 + CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom) + (CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perception) ? CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() : 0);
        }
    }
}