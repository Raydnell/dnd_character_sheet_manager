using Spectre.Console;

namespace dnd_character_sheet
{
    public class ScreenLoadSheet : IScreen
    {
        public void ShowScreen()
        {
            switch(CurrentHeroSheet.HeroSheet.Edition)
            {
                case EnumEditions.DND5E:
                    DirectoryInfo folderInfo = new DirectoryInfo(@"Data\DND5E\CharacterSheets\");
                    
                    if (folderInfo.GetFiles().Length == 0)
                    {
                        Console.Clear();
                        Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.NoSheetInFolder]);
                        Console.ReadKey();
                    }
                    else
                    {
                        var tempSheet = new CharacterSheetDnd5E();
                        var sheetInFolder = new List<string>();

                        foreach (var item in folderInfo.GetFiles())
                        {
                            sheetInFolder.Add(item.Name);
                        }

                        Console.Clear();
                        var sheetName = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title(LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.ChooseSheet])
                                .PageSize(10)
                                .MoreChoicesText($"({LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.ArrowsControl]})")
                                .AddChoices(sheetInFolder));

                        JsonSaveLoad.JsonLoad(@$"Data\DND5E\CharacterSheets\{sheetName}", ref tempSheet);
                        CurrentHeroSheet.HeroSheet = tempSheet;

                        Console.Clear();
                        Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumLoadSheetTitles.HeroLoaded]);
                        Console.ReadKey();
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
