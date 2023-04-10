namespace dnd_character_sheet
{
    public class ScreenLoadSheet : IScreen
    {
        private string _name;
        private string _stringInput;
        private string _choosenEdition;

        private bool _isSheetLoaded;
        private bool _isEditionChoose;

        private JsonSaveLoad _jsonSaveLoad;
        private IUserOutput _userOutput;
        private IUserInput _userInput;
        private DirectoryInfo _folderInfo;

        public ScreenLoadSheet()
        {
            _name = string.Empty;
            _choosenEdition = string.Empty;
            _stringInput = string.Empty;

            _jsonSaveLoad = new JsonSaveLoad();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _folderInfo = new DirectoryInfo(@"Character_Sheets\");
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            _isEditionChoose = false;
            while(_isEditionChoose == false)
            {
                _userOutput.Clear();
                _userOutput.Print("Экран загрузки листа персонажа.\n");
                _userOutput.Print("Персонажа какой редакции нужно загрузить?\n");
                _userOutput.Print(typeof(EnumEditions));

                _stringInput = _userInput.InputString();
                if (Enum.TryParse<EnumEditions>(_stringInput, out EnumEditions result))
                {
                    switch(result)
                    {
                        case EnumEditions.DND5E:
                            _choosenEdition = result.ToString();
                            _isEditionChoose = true;
                            break;
                    }
                }
                else
                {
                    _userOutput.Print("Некорректный ввод. Повторить попытку или вернуться в меню?");
                    _userOutput.Print("1 - повторить попытку");
                    _userOutput.Print("2 - выход в меню");
                    _stringInput = _userInput.InputString();
                    if(_stringInput != "1")
                    {
                        break;
                    }
                }
            }

            if(_isEditionChoose == true)
            {
                while(_isSheetLoaded == false)
                {
                    _userOutput.Print("Выберите лист, который нужно загрузить:");
                    _folderInfo = new DirectoryInfo(@"Character_Sheets\" + _choosenEdition + @"\");
                    
                    foreach(var item in _folderInfo.GetFiles())
                    {
                        _userOutput.Print(item.Name);
                    }
                    
                    _name = _userInput.InputString();
                    if(File.Exists(@"Character_Sheets\" + _choosenEdition + @"\" + _name + ".json"))
                    {
                        switch(_choosenEdition)
                        {
                            case("DND5E"):
                                CharacterSheetDnd5E tempSheet = new CharacterSheetDnd5E();
                                _jsonSaveLoad.JsonLoad(@"Character_Sheets\" + _choosenEdition + @"\" + _name + ".json", ref tempSheet);
                                heroSheet = tempSheet;
                                Console.WriteLine("Герой загружен.");
                                Console.ReadKey();
                                _isSheetLoaded = true;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого героя не существует, попробуй снова");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
