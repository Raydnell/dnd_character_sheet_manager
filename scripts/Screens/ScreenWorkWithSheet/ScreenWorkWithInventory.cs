namespace dnd_character_sheet
{
    public class ScreenWorkWithInventory : IScreen
    {
        private int _cursorPositionLeft;
        private int _cursorPositionTop;
        private int _currentPage;
        private int _totalPages;

        private string _cursor;

        private bool _isEscPressed;

        private Dictionary<int, Dictionary<int, int>> _pagesItems;
        private List<int> _currentItemsList;
        
        private PrintItemInfo _printItemInfo;
        private ConsoleKeyInfo _keyPressed;
        private ModuleCreateNewItem _createNewItem;
        private ItemBaseDND5e _newItem;
        private LookingForItemInDB _lookingForItemDB;

        public ScreenWorkWithInventory()
        {
            _printItemInfo = new PrintItemInfo();
            _pagesItems = new Dictionary<int, Dictionary<int, int>>();
            _cursor = ">";
            _currentItemsList = new List<int>();
            _createNewItem = new ModuleCreateNewItem();
            _lookingForItemDB = new LookingForItemInDB();
        }
        
        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            Console.CursorVisible = false;
            ConstructScreen(heroSheet);

            _isEscPressed = false;
            while (_isEscPressed == false)
            {
                Console.CursorVisible = false;
                
                _keyPressed = Console.ReadKey();

                Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
                Console.Write("  ");

                switch (_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_cursorPositionTop < _pagesItems[_currentPage].Count + 1)
                        {
                            _cursorPositionTop++;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (_cursorPositionTop > 2)
                        {
                            _cursorPositionTop--;
                        }
                        break;

                    case ConsoleKey.Escape:
                        _isEscPressed = true;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (_currentPage > 0 && _totalPages > 1)
                        {
                            _currentPage--;
                            WritePoints();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (_currentPage < _totalPages - 1 && _totalPages > 1)
                        {
                            _currentPage++;
                            WritePoints();
                        }
                        break;

                    case ConsoleKey.N:
                        _newItem = _createNewItem.CreateItem();
                        ItemsDataBaseDND5e.AddItem(_newItem);
                        ItemsDataBaseDND5e.SaveDB();
                        ConstructScreen(heroSheet);
                        break;

                    case ConsoleKey.A:
                        heroSheet.SheetInventory.AddItem(_lookingForItemDB.GetItemIdFromDB());
                        Console.Clear();
                        ConstructScreen(heroSheet);
                        break;
                        
                    default:
                        break;
                }

                PrintItem(ItemsDataBaseDND5e.ItemsDB[_currentItemsList[_cursorPositionTop - 2]]);
                Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
                Console.Write(_cursor);
            }

            Console.CursorVisible = true;
        }

        private void WriteText(EnumWorkWithInventoryTitles title)
        {
            Console.Write(LocalizationsStash.SelectedLocalization[title]);
        }

        private Dictionary<int, Dictionary<int, int>> MakeListWithPages(CharacterSheetBase heroSheet)
        {
            Dictionary<int, Dictionary<int, int>> tempDict = new Dictionary<int, Dictionary<int, int>>()
            {
                { 0, new Dictionary<int, int>() }
            };
            int pages = 0;

            foreach (var item in heroSheet.SheetInventory.Inventory)
            {
                if (tempDict[pages].Count == 10)
                {
                    pages++;
                    tempDict[pages] = new Dictionary<int, int>();
                }

                tempDict[pages][item.Key] = item.Value;
            }

            return tempDict;
        }

        private void WritePoints()
        {
            _currentItemsList = new List<int>();
            _cursorPositionLeft = 2;
            _cursorPositionTop = 2;

            Console.SetCursorPosition(0, 2);
            for (int y = 0; y < 10; y++)
            {
                Console.WriteLine("                   ");
            }
            
            foreach (var item in _pagesItems[_currentPage])
            {
                _cursorPositionLeft = 2;
                Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
                Console.Write(ItemsDataBaseDND5e.ItemsDB[item.Key].Name);

                _cursorPositionLeft = 22;
                Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
                Console.Write(item.Value);
                Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);

                _cursorPositionTop++;

                _currentItemsList.Add(item.Key);
            }

            Console.SetCursorPosition(2, 13);
            Console.Write(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + "/" + _totalPages);

            _cursorPositionLeft = 0;
            _cursorPositionTop = 2;
        }

        private void ErasePoints()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2, i + 2);
                Console.Write("                 ");
            }
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
            WriteText(EnumWorkWithInventoryTitles.ItemInfo);
            Console.Write("\n\n");
            _printItemInfo.ShowItemInfo(item);
        }

        private double CalculateWeight(CharacterSheetBase heroSheet)
        {
            double itemsWeight = 0f;
            
            foreach (var item in heroSheet.SheetInventory.Inventory)
            {
                itemsWeight += Math.Round(ItemsDataBaseDND5e.ItemsDB[item.Key].Weight * item.Value, 2);
            }

            return itemsWeight;
        }

        private float CalculateHeroMaxPortableWeight(CharacterSheetBase heroSheet)
        {
            return heroSheet.SheetAbilities.Abilities[EnumAbilitiesDnd5E.Strength] * 15;
        }

        private void PrintInventoryWeight(CharacterSheetBase heroSheet)
        {
            double itemsWeight = 0;
            float maxHeroWeight = 0;

            itemsWeight = CalculateWeight(heroSheet);
            maxHeroWeight = CalculateHeroMaxPortableWeight(heroSheet);
            
            _cursorPositionLeft = 22;
            _cursorPositionTop = 13;
            Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
            Console.Write(LocalizationsStash.SelectedLocalization[EnumWorkWithInventoryTitles.Weight] + " " + itemsWeight + @"\" + (int)maxHeroWeight);
        }

        private void PrintTable()
        {
            string strokeTypeOne = "                   |                   |";
            string strokeTypeTwo = "-------------------+-------------------+------------------";

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(strokeTypeOne);
            Console.WriteLine(strokeTypeTwo);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(strokeTypeOne);
            }
            Console.WriteLine(strokeTypeTwo);
            Console.WriteLine(strokeTypeOne);
            Console.WriteLine(strokeTypeTwo);
        }

        private void PrintControls()
        {
            Console.SetCursorPosition(2, 0);
            WriteText(EnumWorkWithInventoryTitles.Inventory);
            Console.SetCursorPosition(22, 0);
            WriteText(EnumWorkWithInventoryTitles.ItemsCoint);
            Console.SetCursorPosition(42, 0);
            WriteText(EnumWorkWithInventoryTitles.ControlButtons);
            Console.SetCursorPosition(42, 2);
            WriteText(EnumWorkWithInventoryTitles.AButtonAddItemFromDB);
            Console.SetCursorPosition(42, 3);
            WriteText(EnumWorkWithInventoryTitles.NButtonCreateNewItem);
            Console.SetCursorPosition(42, 4);
            WriteText(EnumWorkWithInventoryTitles.DButtonRemoveItem);
            Console.SetCursorPosition(42, 5);
            WriteText(EnumWorkWithInventoryTitles.PlusButtonIncreaseItemAmount);
            Console.SetCursorPosition(42, 6);
            WriteText(EnumWorkWithInventoryTitles.MinusButtonDecreaseItemAmount);
        }

        private void ConstructScreen(CharacterSheetBase heroSheet)
        {
            _pagesItems = MakeListWithPages(heroSheet);
            _totalPages = _pagesItems.Count;
            _currentPage = 0;

            Console.Clear();
            PrintTable();
            PrintControls();
            WritePoints();
            PrintInventoryWeight(heroSheet);

            _cursorPositionLeft = 0;
            _cursorPositionTop = 2;

            Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
            Console.Write(_cursor);
            PrintItem(ItemsDataBaseDND5e.ItemsDB[_currentItemsList[_cursorPositionTop - 2]]);
        }
    }
}