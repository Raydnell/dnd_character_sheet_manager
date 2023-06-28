using Spectre.Console;
using System.Text;

namespace dnd_character_sheet
{
    public class TraitsDBEdit
    {
        private int _cursorPosition;
        private int _totalPages;
        private int _currentPage;

        private string _cursor;

        private bool _isExit;

        private Dictionary<int, List<KeyValuePair<int, string>>> _bookWithPages;
        private Table _traitsTable;
        private StringBuilder _stringBuilder;
        private PanelCreate _panelCreate;
        private TextBuilder _textBuilder;
        private ConsoleKeyInfo _pressedKey;
        private TraitCreateModule _traitCreateModule;
        
        public TraitsDBEdit()
        {
            _bookWithPages = new Dictionary<int, List<KeyValuePair<int, string>>>();
            _stringBuilder = new StringBuilder();
            _panelCreate = new PanelCreate();
            _textBuilder = new TextBuilder();
            _cursor = "[green]>[/]";
            _traitCreateModule = new TraitCreateModule();
        }

        public int StartWorkWithTraitsDB()
        {
            CheckDBForNull();
            
            Console.CursorVisible = false;
            
            _currentPage = 0;
            _cursorPosition = 0;
            _isExit = false;
            FillBookWithPages();
            FillTable();
            
            Console.Clear();
            AnsiConsole.Write(_traitsTable);
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
                        AddNewTraitToDB();
                        FillBookWithPages();
                        break;

                    case ConsoleKey.E:
                        break;

                    case ConsoleKey.Escape:
                        _isExit = true;
                        break;

                    case ConsoleKey.Enter:
                        return _bookWithPages[_currentPage][_cursorPosition].Key;

                    default:
                        break;
                }

                Console.Clear();
                UpdateTable();
                AnsiConsole.Write(_traitsTable);
                Console.SetCursorPosition(4, 2 + _cursorPosition);
                AnsiConsole.Markup(_cursor);
            }

            return 0;
        }

        private void FillTable()
        {
            _traitsTable = new Table();
            _traitsTable.AddColumns(new string[]{ "1" });
            _traitsTable.HideHeaders();
            _traitsTable.Border = TableBorder.DoubleEdge;

            _traitsTable.AddRow(
                _panelCreate.MakePanelFromString(_textBuilder.BuildTraitsRows(_bookWithPages[_currentPage], _currentPage + 1, _totalPages), $"[underline green]{LocalizationsStash.SelectedLocalization[EnumTraitsText.TraitsListInDB]}[/]")
            );
            _traitsTable.AddRow(
                _panelCreate.MakePanelFromString(_textBuilder.BuildTraitDescription(_bookWithPages[_currentPage][_cursorPosition].Key), $"[underline green]{LocalizationsStash.SelectedLocalization[EnumTraitsText.TraitDescription]}[/]")
            );
        }

        private void UpdateTable()
        {
            _traitsTable.UpdateCell(0, 0, _panelCreate.MakePanelFromString(_textBuilder.BuildTraitsRows(_bookWithPages[_currentPage], _currentPage + 1, _totalPages), $"[underline green]{LocalizationsStash.SelectedLocalization[EnumTraitsText.TraitsListInDB]}[/]"));
            _traitsTable.UpdateCell(1, 0, _panelCreate.MakePanelFromString(_textBuilder.BuildTraitDescription(_bookWithPages[_currentPage][_cursorPosition].Key), $"[underline green]{LocalizationsStash.SelectedLocalization[EnumTraitsText.TraitDescription]}[/]"));
        }

        private void FillBookWithPages()
        {
            _totalPages = 0;
            _bookWithPages.Clear();
            _bookWithPages[_totalPages] = new List<KeyValuePair<int, string>>();

            foreach (var item in TraitsDataBaseDND5e.TraitsDB)
            {
                if (_bookWithPages[_totalPages].Count == 10)
                {
                    _totalPages++;
                    _bookWithPages[_totalPages] = new List<KeyValuePair<int, string>>();
                }

                _bookWithPages[_totalPages].Add(
                    new KeyValuePair<int, string>(
                        item.Key, $"{item.Value.Name} - {item.Value.LevelGained}"
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

        private void CheckDBForNull()
        {
            if (TraitsDataBaseDND5e.TraitsDB.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumTraitsText.NoTraitsInDB]);
                Console.ReadKey();
                AddNewTraitToDB();
            }
        }

        private void AddNewTraitToDB()
        {
            TraitsDataBaseDND5e.AddTrait(_traitCreateModule.CreateNew());
            TraitsDataBaseDND5e.SaveDB();
        }
    }
}