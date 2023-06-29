using Spectre.Console;

namespace dnd_character_sheet
{
    public class ShowMenusCursor
    {
        private string _cursor;

        private int _cursorPositionTop;
        private int _navigatePositionLeft;
        private int _navigatePositionTop;
        private int _currentPage;
        private int _totalPages;

        private bool _isPointChoose;

        private Dictionary<int, List<Enum>> _tempDict;

        private ConsoleKeyInfo _keyPressed;
        
        public ShowMenusCursor()
        {
            _cursor = ">";
            _tempDict = new Dictionary<int, List<Enum>>();
        }

        public Enum ShowMenuPoints(Enum title, Type points)
        {
            Console.CursorVisible = false;
            _currentPage = 0;
            _navigatePositionLeft = 0;
            _navigatePositionTop = 2;
            
            MakePages(points);
            StartUpWrite(title);
            
            _isPointChoose = false;
            while (_isPointChoose == false)
            {
                _keyPressed = Console.ReadKey();
                switch(_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        WriteCursor(EnumMenusCursor.Down);
                        break;

                    case ConsoleKey.UpArrow:
                        WriteCursor(EnumMenusCursor.Up);
                        break;

                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return _tempDict[_currentPage][_navigatePositionTop - 2];

                    case ConsoleKey.Escape:
                        Console.CursorVisible = true;
                        return EnumMainMenuPoints.Exit;

                    case ConsoleKey.LeftArrow:
                        SwitchPages(EnumMenusCursor.Left);
                        break;

                    case ConsoleKey.RightArrow:
                        SwitchPages(EnumMenusCursor.Right);
                        break;

                    default:
                        break;
                }
            }

            return EnumIncorrectInput.IncorrectInput;
        }

        private void WritePages()
        {
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("                            ");
            Console.SetCursorPosition(0, 14);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + @"\" + _totalPages);
        }

        private void WriteRows()
        {
            _cursorPositionTop = 2;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2, _cursorPositionTop + i);
                Console.Write("                                              ");
            }
            
            foreach (var item in _tempDict[_currentPage])
            {
                Console.SetCursorPosition(2, _cursorPositionTop);
                Console.Write(LocalizationsStash.SelectedLocalization[item]);
                _cursorPositionTop++;
            }
        }

        private void WriteCursor(EnumMenusCursor direction)
        {
            Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
            Console.Write("  ");
            
            if (direction == EnumMenusCursor.Down)
            {
                if (_navigatePositionTop < _tempDict[_currentPage].Count + 1)
                {
                    _navigatePositionTop++;
                }
            }
            else if (direction == EnumMenusCursor.Up)
            {
                if (_navigatePositionTop > 2)
                {
                    _navigatePositionTop--;
                }
            }

            Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
            AnsiConsole.Markup($"[yellow]{_cursor}[/]");
        }

        private void StartUpWrite(Enum title)
        {
            Console.Clear();
            AnsiConsole.Markup($"[bold]{LocalizationsStash.SelectedLocalization[title]}[/]");
            WriteRows();
            WritePages();
            ResetCursor();
        }
        
        private void MakePages(Type points)
        {
            _totalPages = 0;
            _tempDict.Clear();
            _tempDict[_totalPages] = new List<Enum>();

            foreach (var item in Enum.GetNames(points))
            {
                if (_tempDict[_totalPages].Count == 10)
                {
                    _totalPages++;
                    _tempDict[_totalPages] = new List<Enum>();
                }

                _tempDict[_totalPages].Add((Enum)Enum.Parse(points, item));
            }

            _totalPages++;
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

            WritePages();
            WriteRows();
            ResetCursor();
        }

        private void ResetCursor()
        {
            Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
            Console.Write("  ");
            _navigatePositionLeft = 0;
            _navigatePositionTop = 2;
            Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
            AnsiConsole.Markup($"[yellow]{_cursor}[/]");
        }
    }
}