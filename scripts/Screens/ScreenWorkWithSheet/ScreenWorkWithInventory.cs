namespace dnd_character_sheet
{
    public class ScreenWorkWithInventory : IScreen
    {
        private int _cursorPositionLeft;
        private int _cursorPositionTop;
        private int _currentPage;
        private int _totalPages;
        private int _itemPointer;

        private string _cursor;

        private bool _isEscPressed;

        private Dictionary<int, List<int>> _pagesItems;
        
        private PrintItemInfo _printItemInfo;
        private ConsoleKeyInfo _keyPressed;
        private ModuleCreateNewItem _createNewItem;
        private ItemBaseDND5e _newItem;
        private LookingForItemInDB _lookingForItemDB;

        public ScreenWorkWithInventory()
        {
            _printItemInfo = new PrintItemInfo();
            _pagesItems = new Dictionary<int, List<int>>();
            _cursor = ">";
            _createNewItem = new ModuleCreateNewItem();
            _lookingForItemDB = new LookingForItemInDB();
        }
        
        public void ShowScreen()
        {
            if (CurrentHeroSheet.HeroSheet.SheetInventory.Inventory.Count == 0)
            {
                NoItemsInInventory(CurrentHeroSheet.HeroSheet);
            }
            
            ConstructScreen(CurrentHeroSheet.HeroSheet);

            _isEscPressed = false;
            while (_isEscPressed == false)
            {
                Console.CursorVisible = false;
                
                _keyPressed = Console.ReadKey();

                Console.SetCursorPosition(0, _itemPointer + 2);
                Console.Write("  ");

                switch (_keyPressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (_itemPointer < _pagesItems[_currentPage].Count - 1)
                        {
                            _itemPointer++;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (_itemPointer > 0)
                        {
                            _itemPointer--;
                        }
                        break;

                    case ConsoleKey.Escape:
                        _isEscPressed = true;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (_currentPage > 0 && _totalPages > 1)
                        {
                            _currentPage--;
                            _itemPointer = 0;
                            WritePoints();
                            WriteCount(CurrentHeroSheet.HeroSheet);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (_currentPage < _totalPages - 1 && _totalPages > 1)
                        {
                            _currentPage++;
                            _itemPointer = 0;
                            WritePoints();
                            WriteCount(CurrentHeroSheet.HeroSheet);
                        }
                        break;

                    case ConsoleKey.N:
                        _newItem = _createNewItem.CreateItem();
                        ItemsDataBaseDND5e.AddItem(_newItem);
                        ItemsDataBaseDND5e.SaveDB();
                        ConstructScreen(CurrentHeroSheet.HeroSheet);
                        break;

                    case ConsoleKey.A:
                        CurrentHeroSheet.HeroSheet.SheetInventory.AddItem(_lookingForItemDB.GetItemIdFromDB());
                        ConstructScreen(CurrentHeroSheet.HeroSheet);
                        break;

                    case ConsoleKey.OemMinus:
                        CurrentHeroSheet.HeroSheet.SheetInventory.DecreaseItem(_pagesItems[_currentPage][_itemPointer]);

                        if (CurrentHeroSheet.HeroSheet.SheetInventory.Inventory.Count == 0)
                        {
                            NoItemsInInventory(CurrentHeroSheet.HeroSheet);
                            ConstructScreen(CurrentHeroSheet.HeroSheet);
                        }
                        else
                        {
                            if (CurrentHeroSheet.HeroSheet.SheetInventory.Inventory.ContainsKey(_pagesItems[_currentPage][_itemPointer]) == false)
                            {
                                ConstructScreen(CurrentHeroSheet.HeroSheet);
                            }
                            else
                            {
                                WriteCount(CurrentHeroSheet.HeroSheet);
                                WriteInventoryWeight(CurrentHeroSheet.HeroSheet);
                            }
                        }
                        
                        break;

                    case ConsoleKey.OemPlus:
                        CurrentHeroSheet.HeroSheet.SheetInventory.AddItem(_pagesItems[_currentPage][_itemPointer]);
                        WriteCount(CurrentHeroSheet.HeroSheet);
                        WriteInventoryWeight(CurrentHeroSheet.HeroSheet);
                        break;

                    case ConsoleKey.D:
                        CurrentHeroSheet.HeroSheet.SheetInventory.RemoveItem(_pagesItems[_currentPage][_itemPointer]);
                        if (CurrentHeroSheet.HeroSheet.SheetInventory.Inventory.Count == 0)
                        {
                            NoItemsInInventory(CurrentHeroSheet.HeroSheet);
                        }

                        ConstructScreen(CurrentHeroSheet.HeroSheet);
                        break;
                        
                    default:
                        break;
                }

                WriteItem(ItemsDataBaseDND5e.ItemsDB[_pagesItems[_currentPage][_itemPointer]]);
                WriteCursor();
            }

            Console.CursorVisible = true;
        }

        private void WriteText(EnumWorkWithInventoryTitles title)
        {
            Console.Write(LocalizationsStash.SelectedLocalization[title]);
        }

        private Dictionary<int, List<int>> MakeListWithPages(CharacterSheetBase heroSheet)
        {
            Dictionary<int, List<int>> tempDict = new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() }
            };
            int pages = 0;

            foreach (var item in heroSheet.SheetInventory.Inventory)
            {
                if (tempDict[pages].Count == 10)
                {
                    pages++;
                    tempDict[pages] = new List<int>();
                }

                tempDict[pages].Add(item.Key);
            }

            return tempDict;
        }

        private void WritePoints()
        {
            _cursorPositionTop = 2;

            Console.SetCursorPosition(0, 2);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("                   ");
            }
            
            foreach (var item in _pagesItems[_currentPage])
            {
                Console.SetCursorPosition(2, _cursorPositionTop);
                Console.Write(ItemsDataBaseDND5e.ItemsDB[item].Name);
                _cursorPositionTop++;
            }
        }

        private void WriteCount(CharacterSheetBase heroSheet)
        {
            _cursorPositionTop = 2;
            
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(22, i + 2);
                Console.Write("    ");
            }

            foreach (var item in _pagesItems[_currentPage])
            {
                Console.SetCursorPosition(22, _cursorPositionTop);
                Console.Write(heroSheet.SheetInventory.Inventory[item]);
                _cursorPositionTop++;
            }
        }

        private void WritePage()
        {
            Console.SetCursorPosition(2, 13);
            Console.Write("               ");
            Console.SetCursorPosition(2, 13);
            Console.Write(LocalizationsStash.SelectedLocalization[EnumMenuNavigate.Page] + " " + (_currentPage + 1) + "/" + _totalPages);
        }

        private void WriteItem(ItemBaseDND5e item)
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
            PrintItemInfo.ShowItemInfo(item);
        }

        private double CalculateWeight(CharacterSheetBase heroSheet)
        {
            double itemsWeight = 0f;
            
            foreach (var item in heroSheet.SheetInventory.Inventory)
            {
                itemsWeight += ItemsDataBaseDND5e.ItemsDB[item.Key].Weight * item.Value;
            }

            return Math.Round(itemsWeight, 2);
        }

        private float CalculateHeroMaxPortableWeight(CharacterSheetBase heroSheet)
        {
            return heroSheet.SheetAbilities.Abilities[EnumAbilitiesDnd5E.Strength] * 15;
        }

        private void WriteInventoryWeight(CharacterSheetBase heroSheet)
        {
            double itemsWeight = 0;
            float maxHeroWeight = 0;

            itemsWeight = CalculateWeight(heroSheet);
            maxHeroWeight = CalculateHeroMaxPortableWeight(heroSheet);
            
            _cursorPositionLeft = 22;
            _cursorPositionTop = 13;
            Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
            Console.Write("               ");
            Console.SetCursorPosition(_cursorPositionLeft, _cursorPositionTop);
            Console.Write(LocalizationsStash.SelectedLocalization[EnumWorkWithInventoryTitles.Weight] + " " + itemsWeight + @"\" + (int)maxHeroWeight);
        }

        private void WriteTable()
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

        private void WriteCursor()
        {
            Console.SetCursorPosition(0, _itemPointer + 2);
            Console.Write(_cursor);
        }

        private void WriteControls()
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
            _itemPointer = 0;            

            Console.Clear();
            WriteTable();
            WriteControls();
            WritePoints();
            WriteCount(heroSheet);
            WritePage();
            WriteInventoryWeight(heroSheet);
            WriteItem(ItemsDataBaseDND5e.ItemsDB[_pagesItems[_currentPage][_itemPointer]]);
            WriteCursor();
        }

        private void NoItemsInInventory(CharacterSheetBase heroSheet)
        {
            Console.Clear();
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumWorkWithInventoryTitles.NoItemsMessage]);
            Console.ReadKey();
            heroSheet.SheetInventory.AddItem(_lookingForItemDB.GetItemIdFromDB());
        }
    }
}