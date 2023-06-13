using Spectre.Console;
using System.Text;

namespace dnd_character_sheet
{
    public class ScreenWorkWithSpells : IScreen
    {
        private int _cursorPosition;
        
        private string _spellsRow;
        private string _spellDescription;
        
        private bool _isNeedExit;
        
        private Dictionary<int, string> _spells;
        private Dictionary<int, Dictionary<int, string>> _spellsOnPages;
        private List<string> _spellsNames;
        private List<int> _spellsIds;
        
        private Table _table;
        private StringBuilder _stringBuilder;
        private ConsoleKey _pressedKey;
        private CursorSystem _cursorSystem;

        public ScreenWorkWithSpells()
        {
            _spells = new Dictionary<int, string>();
            _spellsOnPages = new Dictionary<int, Dictionary<int, string>>();
            _table = new Table();
            _stringBuilder = new StringBuilder();
            _spellsNames = new List<string>();
            _spellsIds = new List<int>();
            _cursorSystem = new CursorSystem();
        }
        public void ShowScreen()
        {
            Console.Clear();
            
            Console.Clear();
            if (CurrentHeroSheet.HeroSheet.SheetSpells.SheetSpells.Count > 0)
            {
                FillSpellsList();
                _cursorPosition = 0;
                _spellsOnPages = MakePages(_spells);
                _spellsRow = BuildSpellsList(0, _spellsOnPages);
                _spellDescription = BuildSpellDescription(_spellsIds[_cursorPosition]);
                CreateTable(_table, _spellsRow, _spellDescription);

                _isNeedExit = false;
                while (_isNeedExit == false)
                {
                    _pressedKey = _cursorSystem.CursorSelector(1, 1, _spellsNames.Count, ref _cursorPosition);
                    switch (_pressedKey)
                    {
                        case ConsoleKey.Enter:
                            _table.UpdateCell(3, 0, BuildSpellDescription(_spellsIds[_cursorPosition]));
                            break;

                        case ConsoleKey.Escape:
                            _isNeedExit = true;
                            break;

                        case ConsoleKey.R:
                            RemoveSpell();
                            break;

                        case ConsoleKey.A:
                            AddSpell();
                            break;

                        case ConsoleKey.LeftArrow:
                            break;

                        case ConsoleKey.RightArrow:
                            break;
                    }

                    UpdateTable();
                }
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
                _spells.Add(item.Key, $"{SpellsDataBaseDND5e.SpellsDB[item.Key].Name} {item.Value}");
            }
        }

        private Dictionary<int, Dictionary<int, string>> MakePages(Dictionary<int, string> values)
        {
            var tempDict = new Dictionary<int, Dictionary<int, string>>()
            {
                { 0, new Dictionary<int, string>() }
            };
            var pages = 0;

            foreach (var item in values)
            {
                if (tempDict[pages].Count == 10)
                {
                    pages++;
                    tempDict[pages] = new Dictionary<int, string>();
                }

                tempDict[pages].Add(item.Key, item.Value);
            }

            return tempDict;
        }

        private void CreateTable(Table table, string spellsRow, string spellDescription)
        {
            table.AddColumns(new string[]{ "1", "2" });
            table.HideHeaders();
            table.AddRow(spellsRow, "Управление");
            table.AddRow("\nВыбранное заклинание\n");
            table.AddRow(spellDescription);
        }

        private void UpdateTable()
        {
            Console.Clear();
            AnsiConsole.Write(_table);
        }

        private string BuildSpellsList(int page, Dictionary<int, Dictionary<int, string>> spellsList)
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _spellsNames.Clear();
            _spellsIds.Clear();

            foreach (var item in spellsList[page])
            {
                _spellsIds.Add(item.Key);
                _spellsNames.Add(item.Value);
            }

            foreach (var item in _spellsNames)
            {
                _stringBuilder.Append(item + "\n");
            }

            return _stringBuilder.ToString();
        }

        private string BuildSpellDescription(int spellId)
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);

            _stringBuilder.Append(
                $"Название: {SpellsDataBaseDND5e.SpellsDB[spellId].Name}" + "\n" +
                $"Уровень: {SpellsDataBaseDND5e.SpellsDB[spellId].Level}");

            return _stringBuilder.ToString();
        }

        private void RemoveSpell()
        {
            CurrentHeroSheet.HeroSheet.SheetSpells.RemoveSpell(_spellsIds[_cursorPosition]);
        }

        private void AddSpell()
        {

        }
    }
}