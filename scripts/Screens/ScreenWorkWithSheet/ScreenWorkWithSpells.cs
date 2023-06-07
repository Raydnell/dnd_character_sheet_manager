using Spectre.Console;

namespace dnd_character_sheet
{
    public class ScreenWorkWithSpells : IScreen
    {
        private List<string> _spells;

        public ScreenWorkWithSpells()
        {
            _spells = new List<string>();
        }
        public void ShowScreen()
        {
            Console.Clear();
            if (CurrentHeroSheet.HeroSheet.SheetSpells.SheetSpells.Count > 0)
            {
                FillSpellsList();
                AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title(LocalizationsStash.SelectedLocalization[EnumWorkWithSpells.ListOfSpells])
                            .PageSize(10)
                            .AddChoices(_spells));
            }
            else
            {
                AnsiConsole.Write(LocalizationsStash.SelectedLocalization[EnumWorkWithSpells.NoSpellsInSheet]);
                Console.ReadKey();
            }
        }

        private void FillSpellsList()
        {
            _spells.Clear();
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetSpells.SheetSpells)
            {
                _spells.Add($"{SpellsDataBaseDND5e.SpellsDB[item.Key].Name} {item.Value}");
            }
        }
    }
}