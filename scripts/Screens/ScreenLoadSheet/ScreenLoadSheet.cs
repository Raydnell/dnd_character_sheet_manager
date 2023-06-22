using Newtonsoft.Json;
using Spectre.Console;

namespace dnd_character_sheet
{
    public class ScreenLoadSheet : IScreen
    {
        private string _sheetName;

        private List<string> _sheetsInFolder;

        private DirectoryInfo _folderInfo;

        public ScreenLoadSheet()
        {
            _sheetsInFolder = new List<string>();
            _folderInfo = new DirectoryInfo(@"Character_Sheets\");
            _sheetName = string.Empty;
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

                    Console.Clear();
                    _sheetName = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title(LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.ChooseSheet])
                            .PageSize(10)
                            .MoreChoicesText($"[grey]({LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.ArrowsControl]})[/]")
                            .AddChoices(_sheetsInFolder));
                    JsonSaveLoad.JsonLoad(@"Character_Sheets\" + CurrentHeroSheet.HeroSheet.Edition.ToString() + @"\" + _sheetName, ref tempSheet);
                    CurrentHeroSheet.HeroSheet = tempSheet;
                    Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.HeroLoaded]);
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }
    }
}
