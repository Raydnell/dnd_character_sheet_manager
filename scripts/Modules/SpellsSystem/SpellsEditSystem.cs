using Spectre.Console;
using System.Text;

namespace dnd_character_sheet
{
    public class SpellsEditSystem
    {
        private int _cursorPosition;
        private int _totalPages;
        private int _currentPage;

        private string _cursor;

        private bool _isExit;

        private Dictionary<int, List<KeyValuePair<int, string>>> _bookWithPages;
        private Table _spellsTable;
        private StringBuilder _stringBuilder;
        private PanelCreate _panelCreate;
        private TextBuilder _textBuilder;
        private ConsoleKeyInfo _pressedKey;
        private SpellsDBEdit _spellsDBEdit;
        
        public SpellsEditSystem()
        {
            _bookWithPages = new Dictionary<int, List<KeyValuePair<int, string>>>();
            _stringBuilder = new StringBuilder();
            _panelCreate = new PanelCreate();
            _textBuilder = new TextBuilder();
            _cursor = "[blue]>[/]";
            _spellsDBEdit = new SpellsDBEdit();
        }

        public void StartWorkWithSpells()
        {
            CheckSpellsForNull();
            
            Console.CursorVisible = false;
            
            _currentPage = 0;
            _cursorPosition = 0;
            _isExit = false;
            FillBookWithPages();
            FillTable();
            
            Console.Clear();
            AnsiConsole.Write(_spellsTable);
            Console.SetCursorPosition(4, 2 + _cursorPosition);
            AnsiConsole.Markup(_cursor);
            
            while (_isExit == false)
            {
                _pressedKey = Console.ReadKey();
                switch (_pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        MoveCursor(EnumMenusCursor.Down);
                        break;

                    case ConsoleKey.UpArrow:
                        MoveCursor(EnumMenusCursor.Up);
                        break;

                    case ConsoleKey.LeftArrow:
                        SwitchPages(EnumMenusCursor.Left);
                        _cursorPosition = 0;
                        break;

                    case ConsoleKey.RightArrow:
                        SwitchPages(EnumMenusCursor.Right);
                        _cursorPosition = 0;
                        break;

                    case ConsoleKey.A:
                        AddSpellToSheet();
                        FillBookWithPages();
                        break;

                    case ConsoleKey.R:
                        RemoveSpellFromSheet();
                        FillBookWithPages();
                        if (_cursorPosition - 1 >= 0)
                        {
                            _cursorPosition--;
                        }
                        CheckSpellsForNull();
                        break;

                    case ConsoleKey.Escape:
                        _isExit = true;
                        break;

                    default:
                        break;
                }

                Console.Clear();
                UpdateTable();
                AnsiConsole.Write(_spellsTable);
                Console.SetCursorPosition(4, 2 + _cursorPosition);
                AnsiConsole.Markup(_cursor);
            }
        }

        private void FillTable()
        {
            _spellsTable = new Table();
            _spellsTable.AddColumns(new string[]{ "1" });
            _spellsTable.HideHeaders();
            _spellsTable.Border = TableBorder.DoubleEdge;

            _spellsTable.AddRow(
                _panelCreate.MakePanelFromString(_textBuilder.BuildSpellsRows(_bookWithPages[_currentPage], _currentPage + 1, _totalPages), $"[underline blue]{LocalizationsStash.SelectedLocalization[EnumWorkWithSpells.SpellsListSheet]}[/]")
            );
            _spellsTable.AddRow(
                _panelCreate.MakePanelFromString(_textBuilder.BuildSpellDescription(_bookWithPages[_currentPage][_cursorPosition].Key), $"[underline blue]{LocalizationsStash.SelectedLocalization[EnumWorkWithSpells.SpellDescription]}[/]")
            );
        }

        private void UpdateTable()
        {
            _spellsTable.UpdateCell(0, 0, _panelCreate.MakePanelFromString(_textBuilder.BuildSpellsRows(_bookWithPages[_currentPage], _currentPage + 1, _totalPages), $"[underline blue]{LocalizationsStash.SelectedLocalization[EnumWorkWithSpells.SpellsListSheet]}[/]"));
            _spellsTable.UpdateCell(1, 0, _panelCreate.MakePanelFromString(_textBuilder.BuildSpellDescription(_bookWithPages[_currentPage][_cursorPosition].Key), $"[underline blue]{LocalizationsStash.SelectedLocalization[EnumWorkWithSpells.SpellDescription]}[/]"));
        }

        private void FillBookWithPages()
        {
            _totalPages = 0;
            _bookWithPages.Clear();
            _bookWithPages[_totalPages] = new List<KeyValuePair<int, string>>();

            foreach (var item in CurrentHeroSheet.HeroSheet.SheetSpells.SheetSpells)
            {
                if (_bookWithPages[_totalPages].Count == 10)
                {
                    _totalPages++;
                    _bookWithPages[_totalPages] = new List<KeyValuePair<int, string>>();
                }

                _bookWithPages[_totalPages].Add(
                    new KeyValuePair<int, string>(
                        item.Key, $"{SpellsDataBaseDND5e.SpellsDB[item.Key].Name} - {item.Value}"
                    )
                );
            }

            _totalPages++;
        }

        private void MoveCursor(EnumMenusCursor direction)
        {
            if (direction == EnumMenusCursor.Down)
            {
                if (_cursorPosition < _bookWithPages[_currentPage].Count - 1)
                {
                    _cursorPosition++;
                }
            }
            else if (direction == EnumMenusCursor.Up)
            {
                if (_cursorPosition > 0)
                {
                    _cursorPosition--;
                }
            }
        }

        private void SwitchPages(EnumMenusCursor direction)
        {
            if (direction == EnumMenusCursor.Left)
            {
                if (_currentPage > 0 && _totalPages > 1)
                {
                    _currentPage--;
                }
            }
            else if (direction == EnumMenusCursor.Right)
            {
                if (_currentPage < _totalPages - 1 && _totalPages > 1)
                {
                    _currentPage++;
                }
            }
        }

        private void AddSpellToSheet()
        {
            CurrentHeroSheet.HeroSheet.SheetSpells.AddSpell(_spellsDBEdit.StartWorkWithSpellsDB());
        }

        private void RemoveSpellFromSheet()
        {
            CurrentHeroSheet.HeroSheet.SheetSpells.RemoveSpell(_bookWithPages[_currentPage][_cursorPosition].Key);
        }

        private void CheckSpellsForNull()
        {
            if (CurrentHeroSheet.HeroSheet.SheetSpells.SheetSpells.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumWorkWithSpells.NoSpellsInSheet]);
                Console.ReadKey();
                AddSpellToSheet();
            }
        }
    }
}