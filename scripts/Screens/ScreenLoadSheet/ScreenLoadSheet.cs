using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public class ScreenLoadSheet : IScreen
    {
        private string _sheetName;
        private string _stringInput;
        private string _choosenEdition;

        private List<string> _sheetsInFolder;

        private IUserOutput _userOutput;
        private IUserInput _userInput;
        private DirectoryInfo _folderInfo;
        private ShowMenusCursor _showMenusCursor;

        public ScreenLoadSheet()
        {
            _choosenEdition = string.Empty;
            _stringInput = string.Empty;
            _sheetsInFolder = new List<string>();
            _userOutput = new ConsoleOutput();
            _userInput = new ConsoleInput();
            _folderInfo = new DirectoryInfo(@"Character_Sheets\");
            _showMenusCursor = new ShowMenusCursor();
        }

        public void ShowScreen(ref CharacterSheetBase heroSheet)
        {
            switch(heroSheet.Edition)
            {
                case EnumEditions.DND5E:
                    _folderInfo = new DirectoryInfo(@"Character_Sheets\" + heroSheet.Edition.ToString());
                    CharacterSheetDnd5E tempSheet = new CharacterSheetDnd5E();
                    
                    foreach(var item in _folderInfo.GetFiles())
                    {
                        _sheetsInFolder.Add(item.Name);
                    }

                    _sheetName = _showMenusCursor.ShowMenuPoints(EnumLoadSheetTitles.ChooseSheet, _sheetsInFolder);
                    JsonSaveLoad.JsonLoad(@"Character_Sheets\" + heroSheet.Edition.ToString() + @"\" + _sheetName, ref tempSheet);
                    heroSheet = tempSheet;
                    _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.HeroLoaded]);
                    _userInput.InputKey();
                    break;

                default:
                    break;
            }
        }
    }
}
