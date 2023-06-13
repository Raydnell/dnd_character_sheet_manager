using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public class ScreenLoadSheet : IScreen
    {
        private string _sheetName;

        private List<string> _sheetsInFolder;

        private DirectoryInfo _folderInfo;
        private ShowMenusCursor _showMenusCursor;

        public ScreenLoadSheet()
        {
            _sheetsInFolder = new List<string>();
            _folderInfo = new DirectoryInfo(@"Character_Sheets\");
            _showMenusCursor = new ShowMenusCursor();
        }

        public void ShowScreen()
        {
            switch(CurrentHeroSheet.HeroSheet.Edition)
            {
                case EnumEditions.DND5E:
                    _folderInfo = new DirectoryInfo(@"Character_Sheets\" + CurrentHeroSheet.HeroSheet.Edition.ToString());
                    CharacterSheetDnd5E tempSheet = new CharacterSheetDnd5E();
                    
                    foreach(var item in _folderInfo.GetFiles())
                    {
                        _sheetsInFolder.Add(item.Name);
                    }

                    _sheetName = _showMenusCursor.ShowMenuPoints(EnumLoadSheetTitles.ChooseSheet, _sheetsInFolder);
                    JsonSaveLoad.JsonLoad(@"Character_Sheets\" + CurrentHeroSheet.HeroSheet.Edition.ToString() + @"\" + _sheetName, ref tempSheet);
                    CurrentHeroSheet.HeroSheet = tempSheet;
                    Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.HeroLoaded]);
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }
    }
}
