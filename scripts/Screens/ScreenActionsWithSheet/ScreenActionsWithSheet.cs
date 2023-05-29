using Spectre.Console;
using System.Text;

namespace dnd_character_sheet
{
    public class ScreenActionsWithSheet : IScreen
    {
        private StringBuilder _stringBuilder;
        private Table _table;
        private string _abilitiesRows;
        private string _skillsRows;
        private string _proficienciesRows;

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
            _stringBuilder.Remove(_stringBuilder.Length - 2, 2);

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

            _stringBuilder.Remove(_stringBuilder.Length - 2, 2);
            
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

            _stringBuilder.Remove(_stringBuilder.Length - 2, 2);
            
            Panel tempPanel = new Panel(_stringBuilder.ToString());
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Proficiencies]);
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }

        private Panel CreateCombatPanel()
        {
            Panel tempPanel = new Panel("HP 12|12\nAC 13\nTHP 2\nHit dice 5");
            tempPanel.Border = BoxBorder.Square;
            tempPanel.Header = new PanelHeader("Combat:");
            tempPanel.HeaderAlignment(Justify.Center);
            
            return tempPanel;
        }

        private void FillTable(Table table)
        {
            table.AddColumns(new string[]{
                CurrentHeroSheet.HeroSheet.Name, 
                LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetClass.Name],
                LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetRace.Name],
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Level] + " " + CurrentHeroSheet.HeroSheet.SheetProgression.Level,
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Expirience] + " " + CurrentHeroSheet.HeroSheet.SheetProgression.Expirience
            });
            table.AddRow(CreateAbilityPanel(), CreateSkillPanel(), CreateProficienciesPanel(), CreateCombatPanel());
        }
    }
}