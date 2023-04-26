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

        public Enum ShowMenuPoints3(Dictionary<Enum, Dictionary<Enum, string>> menuTitle, Dictionary<Enum, Dictionary<Enum, string>> menuList, Enum language, Enum title)
        {
            if (menuList.Keys.ToArray().Count() > 10)
            {
                //_pagesMenu = MakeStringPages(menuList.Keys.ToArray());
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
                    Console.WriteLine(LocalizationsStash.Localizations[EnumMenuNavigate.Page][language] + (_currentPage + 1) + "/" + _totalPages);

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

        private Dictionary<int, List<Enum>> MakeStringPages3(Enum[] originalMassive)
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

        private Dictionary<int, List<string>> _newPagesMenu;
        
        public Enum ShowMenuPoints(Enum title, Type points, Enum language)
        {
            if (Enum.GetNames(points).Count() > 10)
            {
                _pagesMenu = MakeStringPages(points);
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
                    Console.WriteLine(LocalizationsStash.Localizations[title][language]);

                    foreach (var item in _pagesMenu[_currentPage])
                    {
                        Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);

                        Console.Write(LocalizationsStash.Localizations[item][language]);
                        _cursorPositionTop++;
                    }

                    Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                    Console.WriteLine(_cursor);

                    Console.SetCursorPosition(0, _pagesMenu[_currentPage].ToArray().Count() + 3);
                    Console.WriteLine(LocalizationsStash.Localizations[EnumMenuNavigate.Page][language] + (_currentPage + 1) + "/" + _totalPages);

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
                    Console.WriteLine(LocalizationsStash.Localizations[title][language]);

                    foreach (var item in Enum.GetNames(points))
                    {
                        Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
                        Console.Write(LocalizationsStash.Localizations[(Enum)Enum.Parse(points, item)][language]);
                        _cursorPositionTop++;
                    }

                    Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                    Console.WriteLine(_cursor);

                    Console.SetCursorPosition(0, Enum.GetNames(points).Count() + 3);

                    _keyPressed = Console.ReadKey();
                    switch(_keyPressed.Key.ToString())
                    {
                        case "DownArrow":
                            if (_navigatePositionTop < Enum.GetNames(points).Count() + 1)
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
                            string tempPoint = Enum.GetNames(points)[_navigatePositionTop - 2];
                            return (Enum)Enum.Parse(points, tempPoint);

                        case "Esc":
                            return EnumMainMenuPoints.Exit;

                        default:
                            break;
                    }
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
    }
}