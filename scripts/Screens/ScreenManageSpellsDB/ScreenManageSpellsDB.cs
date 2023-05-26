using Spectre.Console;

namespace dnd_character_sheet
{
    public class ScreenManageSpellsDB : IScreen
    {
        private List<string> _spells;

        public ScreenManageSpellsDB()
        {
            _spells = new List<string>();
        }   
        
        public void ShowScreen()
        {
            string[] tempList = MakeSpellsList();

            var fruit = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Spells DB")
                    .PageSize(100)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(tempList));

            AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");
            Console.ReadKey();
        }

        private string[] MakeSpellsList()
        {
            //_spells.Clear();
            
            foreach (var item in SpellsDataBaseDND5e.SpellsDB)
            {
                _spells.Add("[" + item.Value.Level + "] " + item.Value.Name);
            }

            return _spells.ToArray<string>();
        }
    }
}