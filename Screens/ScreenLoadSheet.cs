using System;
using System.IO;

namespace dnd_character_sheet
{
    internal class ScreenLoadSheet
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
        private CharacterSheetFactory _sheetFactory;
        private CharacterSheetBase _tempSheet;

        public ScreenLoadSheet()
        {
            _name = string.Empty;
            _choosenEdition = string.Empty;
            _stringInput = string.Empty;

            _jsonSaveLoad = new JsonSaveLoad();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _folderInfo = new DirectoryInfo(@"Character_Sheets\");
            _sheetFactory = new CharacterSheetFactory();
        }

        public CharacterSheetBase LoadSheetFromFile()
        {
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
                            _tempSheet = _sheetFactory.CreateCharacterSheet(result.ToString());
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
                    if (File.Exists(@"Character_Sheets\" + _choosenEdition + @"\" + _name + ".json"))
                    {
                        Console.WriteLine(@"Character_Sheets\" + _choosenEdition + @"\" + _name + ".json");
                        Console.ReadKey();
                        _jsonSaveLoad.JsonLoad(@"Character_Sheets\" + _choosenEdition + @"\" + _name + ".json", _tempSheet);
                        Console.WriteLine("Герой загружен.");
                        Console.ReadKey();
                        _isSheetLoaded = true;

                        return _tempSheet;
                    }
                    else
                    {
                        Console.WriteLine("Такого героя не существует, попробуй снова");
                        Console.ReadKey();
                    }
                }
            }

            return _tempSheet;
        }
    }
}
