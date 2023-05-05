namespace dnd_character_sheet
{
    public class ShowMenusCursor
    {
        private string _cursor;

        private int _cursorPositionLeft;
        private int _cursorPositionTop;
        private int _navigatePositionLeft;
        private int _navigatePositionTop;
        private int _currentPage;
        private int _totalPages;

        private bool _isPointChoose;

        private Dictionary<int, List<Enum>> _pagesMenuEnum;
        private Dictionary<int, List<string>> _pagesMenuString;
        private ConsoleKeyInfo _keyPressed;
        
        public ShowMenusCursor()
        {
            _cursor = ">";
            _pagesMenuEnum = new Dictionary<int, List<Enum>>();
            _pagesMenuString = new Dictionary<int, List<string>>();
        }

        public Enum ShowMenuPoints(Enum title, Type points)
        {
            _pagesMenuEnum = MakeStringPages(points);
            _currentPage = 0;
            _totalPages = _pagesMenuEnum.Count;

            _navigatePositionLeft = 0;
            _navigatePositionTop = 2;
            
            _isPointChoose = false;
            while (_isPointChoose == false)
            {
                _cursorPositionLeft = 2;
                _cursorPositionTop = 2;

                Console.Clear();
                Console.WriteLine(LocalizationsStash.SelectedLocalization[title]);

                foreach (var item in _pagesMenuEnum[_currentPage])
                {
                    Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);

                    Console.Write(LocalizationsStash.SelectedLocalization[item]);
                    _cursorPositionTop++;
                }

                Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                Console.WriteLine(_cursor);

                Console.SetCursorPosition(0, _pagesMenuEnum[_currentPage].Count + 3);
                Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + "/" + _totalPages);

                _keyPressed = Console.ReadKey();

                switch(_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_navigatePositionTop < _pagesMenuEnum[_currentPage].Count + 1)
                        {
                            _navigatePositionTop++;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (_navigatePositionTop > 2)
                        {
                            _navigatePositionTop--;
                        }
                        break;

                    case ConsoleKey.Enter:
                        return _pagesMenuEnum[_currentPage][_navigatePositionTop - 2];

                    case ConsoleKey.Escape:
                        return EnumMainMenuPoints.Exit;

                    case ConsoleKey.LeftArrow:
                        if (_currentPage > 0 && _totalPages > 1)
                        {
                            _currentPage--;
                            _navigatePositionLeft = 0;
                            _navigatePositionTop = 2;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (_currentPage < _totalPages - 1 && _totalPages > 1)
                        {
                            _currentPage++;
                            _navigatePositionLeft = 0;
                            _navigatePositionTop = 2;
                        }
                        break;

                    default:
                        break;
                }
            }

            return EnumIncorrectInput.IncorrectInput;
        }

        private Dictionary<int, List<Enum>> MakeStringPages(Type originalPoints)
        {
            Dictionary<int, List<Enum>> tempDict = new Dictionary<int, List<Enum>>()
            {
                { 0, new List<Enum>() }
            };

            int pages = 0;

            foreach (var item in Enum.GetNames(originalPoints))
            {
                if (tempDict[pages].Count == 10)
                {
                    pages++;
                    tempDict[pages] = new List<Enum>();
                }

                tempDict[pages].Add((Enum)Enum.Parse(originalPoints, item));
            }

            return tempDict;
        }

        public string ShowMenuPoints(Enum title, List<string> points)
        {
            _pagesMenuString = MakeStringPages(points);
            _currentPage = 0;
            _totalPages = _pagesMenuString.Count;

            _navigatePositionLeft = 0;
            _navigatePositionTop = 2;
            
            _isPointChoose = false;
            while (_isPointChoose == false)
            {
                _cursorPositionLeft = 2;
                _cursorPositionTop = 2;

                Console.Clear();
                Console.WriteLine(LocalizationsStash.SelectedLocalization[title]);

                foreach (var item in _pagesMenuString[_currentPage])
                {
                    Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);

                    Console.Write(item);
                    _cursorPositionTop++;
                }

                Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                Console.WriteLine(_cursor);

                Console.SetCursorPosition(0, _pagesMenuString[_currentPage].Count + 3);
                Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + "/" + _totalPages);

                _keyPressed = Console.ReadKey();

                switch(_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_navigatePositionTop < _pagesMenuString[_currentPage].Count + 1)
                        {
                            _navigatePositionTop++;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (_navigatePositionTop > 2)
                        {
                            _navigatePositionTop--;
                        }
                        break;

                    case ConsoleKey.Enter:
                        return _pagesMenuString[_currentPage][_navigatePositionTop - 2];

                    case ConsoleKey.Escape:
                        break;

                    case ConsoleKey.LeftArrow:
                        if (_currentPage > 0 && _totalPages > 1)
                        {
                            _currentPage--;
                            _navigatePositionLeft = 0;
                            _navigatePositionTop = 2;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (_currentPage < _totalPages - 1 && _totalPages > 1)
                        {
                            _currentPage++;
                            _navigatePositionLeft = 0;
                            _navigatePositionTop = 2;
                        }
                        break;

                    default:
                        break;
                }
            }

            return string.Empty;
        }

        private Dictionary<int, List<string>> MakeStringPages(List<string> originalPoints)
        {
            Dictionary<int, List<string>> tempDict = new Dictionary<int, List<string>>()
            {
                { 0, new List<string>() }
            };

            int pages = 0;

            foreach (var item in originalPoints)
            {
                if (tempDict[pages].Count == 10)
                {
                    pages++;
                    tempDict[pages] = new List<string>();
                }

                tempDict[pages].Add(item);
            }

            return tempDict;
        }
    }
}