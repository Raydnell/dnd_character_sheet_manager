namespace dnd_character_sheet
{
    public class LookingForItemInDB
    {
        private int _currentPage;
        private int _totalPages;
        private int _navigatePositionLeft;
        private int _navigatePositionTop;
        private int _cursorPositionLeft;
        private int _cursorPositionTop;

        private string _cursor;

        private bool _isPointChoose;

        private Dictionary<int, List<int>> _tempDict;

        private ConsoleKeyInfo _keyPressed;

        public LookingForItemInDB()
        {
            _tempDict = new Dictionary<int, List<int>>();
            _cursor = ">";
        }

        public int GetItemIdFromDB()
        {
            Console.Clear();
            
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumShowItemsInDBTitles.ListOfItems]);

            MakeListWithPages();
            _totalPages = _tempDict.Count;
            _currentPage = 0;
            WritePoints();

            _navigatePositionLeft = 0;
            _navigatePositionTop = 2;
            
            _isPointChoose = false;
            while (_isPointChoose == false)
            {
                Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                Console.WriteLine(_cursor);
                
                Console.SetCursorPosition(0, 16);
                Console.Write(LocalizationsStash.SelectedLocalization[EnumWorkWithInventoryTitles.ItemInfo]);
                Console.Write("\n\n");
                PrintItem(ItemsDataBaseDND5e.ItemsDB[_tempDict[_currentPage][_navigatePositionTop - 2]]);

                _keyPressed = Console.ReadKey();
                Console.SetCursorPosition(_navigatePositionLeft, _navigatePositionTop);
                Console.Write("  ");
                switch(_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_navigatePositionTop < _tempDict[_currentPage].Count + 1)
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

                    case ConsoleKey.LeftArrow:
                        if (_currentPage > 0 && _totalPages > 1)
                        {
                            _currentPage--;
                            _navigatePositionLeft = 0;
                            _navigatePositionTop = 2;
                            WritePoints();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (_currentPage < _totalPages - 1 && _totalPages > 1)
                        {
                            _currentPage++;
                            _navigatePositionLeft = 0;
                            _navigatePositionTop = 2;
                            WritePoints();
                        }
                        break;

                    case ConsoleKey.Enter:
                        return ItemsDataBaseDND5e.ItemsDB[_tempDict[_currentPage][_navigatePositionTop - 2]].ItemId;

                    case ConsoleKey.Escape:
                        _isPointChoose = true;
                        break;
                }

                PrintItem(ItemsDataBaseDND5e.ItemsDB[_tempDict[_currentPage][_navigatePositionTop - 2]]);
            }

            return 0;
        }

        private void MakeListWithPages()
        {
            _tempDict.Clear();
            _tempDict[0] = new List<int>();
            int pages = 0;

            foreach (var item in ItemsDataBaseDND5e.ItemsDB)
            {
                if (_tempDict[pages].Count == 10)
                {
                    pages++;
                    _tempDict[pages] = new List<int>();
                }

                _tempDict[pages].Add(item.Key);
            }
        }

        private void WritePoints()
        {
            _cursorPositionLeft = 2;
            _cursorPositionTop = 2;

            Console.SetCursorPosition(0, 2);
            for (int y = 0; y < 10; y++)
            {
                Console.WriteLine("                   ");
            }
            
            foreach (var item in _tempDict[_currentPage])
            {
                _cursorPositionLeft = 2;
                Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
                Console.Write(ItemsDataBaseDND5e.ItemsDB[item].Name);

                _cursorPositionTop++;
            }

            Console.SetCursorPosition(2, 13);
            Console.Write(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + "/" + _totalPages);

            _cursorPositionLeft = 0;
            _cursorPositionTop = 2;
        }

        private void PrintItem(ItemBaseDND5e item)
        {
            Console.SetCursorPosition(0, 18);
            for (int i = 0; i < 17; i++)
            {
                for (int y = 0; y < 61; y++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }

            Console.SetCursorPosition(0, 16);
            Console.Write(LocalizationsStash.SelectedLocalization[EnumWorkWithInventoryTitles.ItemInfo]);
            Console.Write("\n\n");
            PrintItemInfo.ShowItemInfo(item);
        }
    }
}