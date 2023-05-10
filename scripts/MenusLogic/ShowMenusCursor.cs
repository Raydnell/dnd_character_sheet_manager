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

        private ConsoleKeyInfo _keyPressed;
        private PrintItemInfo _printItemInfo;
        
        public ShowMenusCursor()
        {
            _cursor = ">";
            _printItemInfo = new PrintItemInfo();
        }

        public Enum ShowMenuPoints(Enum title, Type points)
        {
            Console.CursorVisible = false;
            
            Dictionary<int, List<Enum>> tempDict = new Dictionary<int, List<Enum>>()
            {
                { 0, new List<Enum>() }
            };

            int pages = 0;

            foreach (var item in Enum.GetNames(points))
            {
                if (tempDict[pages].Count == 10)
                {
                    pages++;
                    tempDict[pages] = new List<Enum>();
                }

                tempDict[pages].Add((Enum)Enum.Parse(points, item));
            }

            _currentPage = 0;
            _totalPages = tempDict.Count;

            _navigatePositionLeft = 0;
            _navigatePositionTop = 2;
            
            _isPointChoose = false;
            while (_isPointChoose == false)
            {
                _cursorPositionLeft = 2;
                _cursorPositionTop = 2;

                Console.Clear();
                Console.WriteLine(LocalizationsStash.SelectedLocalization[title]);

                foreach (var item in tempDict[_currentPage])
                {
                    Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);

                    Console.Write(LocalizationsStash.SelectedLocalization[item]);
                    _cursorPositionTop++;
                }

                Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                Console.WriteLine(_cursor);

                Console.SetCursorPosition(0, 14);
                Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + "/" + _totalPages);

                _keyPressed = Console.ReadKey();

                switch(_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_navigatePositionTop < tempDict[_currentPage].Count + 1)
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
                        Console.CursorVisible = true;
                        return tempDict[_currentPage][_navigatePositionTop - 2];

                    case ConsoleKey.Escape:
                        Console.CursorVisible = true;
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

        public string ShowMenuPoints(Enum title, List<string> points)
        {
            Dictionary<int, List<string>> tempDict = new Dictionary<int, List<string>>()
            {
                { 0, new List<string>() }
            };

            int pages = 0;

            foreach (var item in points)
            {
                if (tempDict[pages].Count == 10)
                {
                    pages++;
                    tempDict[pages] = new List<string>();
                }

                tempDict[pages].Add(item);
            }

            _currentPage = 0;
            _totalPages = tempDict.Count;

            _navigatePositionLeft = 0;
            _navigatePositionTop = 2;
            
            _isPointChoose = false;
            while (_isPointChoose == false)
            {
                _cursorPositionLeft = 2;
                _cursorPositionTop = 2;

                Console.Clear();
                Console.WriteLine(LocalizationsStash.SelectedLocalization[title]);

                foreach (var item in tempDict[_currentPage])
                {
                    Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);

                    Console.Write(item);
                    _cursorPositionTop++;
                }

                Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                Console.WriteLine(_cursor);

                Console.SetCursorPosition(0, 14);
                Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + "/" + _totalPages);

                _keyPressed = Console.ReadKey();

                switch(_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_navigatePositionTop < tempDict[_currentPage].Count + 1)
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
                        return tempDict[_currentPage][_navigatePositionTop - 2];

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

        public void ShowMenuPoints(Enum title, Dictionary<int, ItemBaseDND5e> itemDB)
        {
            Dictionary<int, List<int>> tempDict = new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() }
            };

            int pages = 0;

            ItemArmorDND5e tempArmorItem;
            ItemWeaponDND5e tempWeaponItem;
            ItemRegularDND5e tempRegularItem;

            foreach (var item in itemDB)
            {
                if (tempDict[pages].Count == 10)
                {
                    pages++;
                    tempDict[pages] = new List<int>();
                }

                tempDict[pages].Add(item.Key);
            }

            _currentPage = 0;
            _totalPages = tempDict.Count;

            _navigatePositionLeft = 0;
            _navigatePositionTop = 2;
            
            _isPointChoose = false;
            while (_isPointChoose == false)
            {
                _cursorPositionLeft = 2;
                _cursorPositionTop = 2;

                Console.Clear();
                Console.WriteLine(LocalizationsStash.SelectedLocalization[title]);

                foreach (var item in tempDict[_currentPage])
                {
                    Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);

                    Console.Write(item + ": " + itemDB[item].Name);
                    _cursorPositionTop++;
                }

                Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                Console.WriteLine(_cursor);

                Console.SetCursorPosition(0, 14);
                Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + "/" + _totalPages + "\n\n");
                
                switch(itemDB[tempDict[_currentPage][_navigatePositionTop - 2]].ItemType)
                {
                    case EnumItemTypesDND5e.Armor:
                        tempArmorItem = (ItemArmorDND5e)itemDB[tempDict[_currentPage][_navigatePositionTop - 2]];
                        _printItemInfo.ShowItemInfo(tempArmorItem);
                        break;

                    case EnumItemTypesDND5e.Weapon:
                        tempWeaponItem = (ItemWeaponDND5e)itemDB[tempDict[_currentPage][_navigatePositionTop - 2]];
                        _printItemInfo.ShowItemInfo(tempWeaponItem);
                        break;
                    
                    case EnumItemTypesDND5e.Item:
                        tempRegularItem = (ItemRegularDND5e)itemDB[tempDict[_currentPage][_navigatePositionTop - 2]];
                        _printItemInfo.ShowItemInfo(tempRegularItem);
                        break;
                }

                _keyPressed = Console.ReadKey();

                switch(_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_navigatePositionTop < tempDict[_currentPage].Count + 1)
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

                    case ConsoleKey.Escape:
                        _isPointChoose = true;
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
        }
    }
}