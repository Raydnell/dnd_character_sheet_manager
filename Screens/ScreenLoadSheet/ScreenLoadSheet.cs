using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public class ScreenLoadSheet : IScreen
    {
        private string _sheetName;
        private string _stringInput;
        private string _choosenEdition;

        private List<string> _sheetsInFolder;

        private JsonSaveLoad _jsonSaveLoad;
        private IUserOutput _userOutput;
        private IUserInput _userInput;
        private DirectoryInfo _folderInfo;
        private ShowMenusCursor _showMenusCursor;

        public ScreenLoadSheet()
        {
            _choosenEdition = string.Empty;
            _stringInput = string.Empty;
            _sheetsInFolder = new List<string>();

            _jsonSaveLoad = new JsonSaveLoad();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _folderInfo = new DirectoryInfo(@"Character_Sheets\");
            _showMenusCursor = new ShowMenusCursor();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet, Enum language)
        {
            _folderInfo = new DirectoryInfo(@"Character_Sheets\DND5E\");
            CharacterSheetDnd5E tempSheet = new CharacterSheetDnd5E();
            
            foreach(var item in _folderInfo.GetFiles())
            {
                _sheetsInFolder.Add(item.Name);
            }

            //_sheetName = _showMenusCursor.ShowMenuPoints("Выберите лист, который нужно загрузить:", _sheetsInFolder.ToArray());
            _jsonSaveLoad.JsonLoad(@"Character_Sheets\DND5E\Enum Hero.json", ref tempSheet);
            heroSheet = tempSheet;
            Console.WriteLine("Герой загружен.");
            Console.ReadKey();
        }
    }
}
