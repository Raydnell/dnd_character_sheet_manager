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

        Dictionary<int, List<Enum>> _pagesMenu;

        private ConsoleKeyInfo _keyPressed;
        
        public ShowMenusCursor()
        {
            _cursor = ">";
            _pagesMenu = new Dictionary<int, List<Enum>>();
        }

        public Enum ShowMenuPoints(Dictionary<Enum, Dictionary<Enum, string>> menuTitle, Dictionary<Enum, Dictionary<Enum, string>> menuList, Enum language, Enum title)
        {
            if (menuList.Keys.ToArray().Count() > 10)
            {
                _pagesMenu = MakeStringPages(menuList.Keys.ToArray());
                _currentPage = 0;
                _totalPages = _pagesMenu.Keys.Count;

                _navigatePositionLeft = 0;
                _navigatePositionTop = 2;
                
                _isPointChoose = false;
                while (_isPointChoose == false)
                {
                    _cursorPositionLeft = 2;
                    _cursorPositionTop = 2;

                    Console.Clear();
                    Console.WriteLine(menuTitle[title][language]);

                    foreach (var item in _pagesMenu[_currentPage])
                    {
                        Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
                        Console.Write(menuList[item][language]);
                        _cursorPositionTop++;
                    }

                    Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                    Console.WriteLine(_cursor);

                    Console.SetCursorPosition(0, _pagesMenu[_currentPage].ToArray().Count() + 3);
                    Console.WriteLine("Страница " + (_currentPage + 1) + "/" + _totalPages);

                    _keyPressed = Console.ReadKey();
                    switch(_keyPressed.Key.ToString())
                    {
                        case "DownArrow":
                            if (_navigatePositionTop < _pagesMenu[_currentPage].ToArray().Count() + 1)
                            {
                                _navigatePositionTop++;
                            }
                            break;

                        case "UpArrow":
                            if (_navigatePositionTop > 2)
                            {
                                _navigatePositionTop--;
                            }
                            break;

                        case "Enter":
                            return _pagesMenu[_currentPage][_navigatePositionTop - 2];

                        case "Esc":
                            return EnumMainMenuPoints.Exit;

                        case "LeftArrow":
                            if (_currentPage > 0)
                            {
                                _currentPage--;
                                _navigatePositionLeft = 0;
                                _navigatePositionTop = 2;
                            }
                            break;

                        case "RightArrow":
                            if (_currentPage < _totalPages - 1)
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
            }
            else
            {
                _navigatePositionLeft = 0;
                _navigatePositionTop = 2;
                
                _isPointChoose = false;
                while (_isPointChoose == false)
                {
                    _cursorPositionLeft = 2;
                    _cursorPositionTop = 2;

                    Console.Clear();
                    Console.WriteLine(menuTitle[title][language]);
                    foreach (var item in menuList.Keys.ToArray())
                    {
                        Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
                        Console.Write(menuList[item][language]);
                        _cursorPositionTop++;
                    }

                    Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                    Console.WriteLine(_cursor);

                    Console.SetCursorPosition(0, menuList.Keys.ToArray().Count() + 3);

                    _keyPressed = Console.ReadKey();
                    switch(_keyPressed.Key.ToString())
                    {
                        case "DownArrow":
                            if (_navigatePositionTop < menuList.Count() + 1)
                            {
                                _navigatePositionTop++;
                            }
                            break;

                        case "UpArrow":
                            if (_navigatePositionTop > 2)
                            {
                                _navigatePositionTop--;
                            }
                            break;

                        case "Enter":
                            return menuList.Keys.ToArray()[_navigatePositionTop - 2];

                        case "Esc":
                            return EnumMainMenuPoints.Exit;
                        
                        default:
                            break;
                    }
                }
            }

            return EnumIncorrectInput.IncorrectInput;
        }

        private Dictionary<int, List<Enum>> MakeStringPages(Enum[] originalMassive)
        {
            Dictionary<int, List<Enum>> tempDict = new Dictionary<int, List<Enum>>()
            {
                { 0, new List<Enum>() }
            };
            int pages = 0;

            foreach (var item in originalMassive)
            {
                if (tempDict[pages].Count <= 10)
                {
                    tempDict[pages].Add(item);
                }
                else
                {
                    pages++;
                    tempDict[pages] = new List<Enum>();
                    tempDict[pages].Add(item);
                }
            }

            return tempDict;
        }
    }
}