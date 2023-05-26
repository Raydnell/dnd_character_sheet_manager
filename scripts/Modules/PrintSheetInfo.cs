namespace dnd_character_sheet
{
    public class PrintSheetInfo
    {
        public static void ShowSheetFields(CharacterSheetBase sheet)
        {
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Name] + ": " + sheet.Name);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Race] + ": " + LocalizationsStash.SelectedLocalization[sheet.SheetRace.Name]);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Class] + ": " + LocalizationsStash.SelectedLocalization[sheet.SheetClass.Name]);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Level] + ": " + sheet.SheetProgression.Level);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Expirience] + ": " + sheet.SheetProgression.Expirience);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Abilities] + ": ");
            ConsoleOutput.Print(sheet.SheetAbilities.Abilities);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Skills] + ": ");
            ConsoleOutput.Print(sheet.SheetSkills.Skills);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Proficiencies] + ": ");
            ConsoleOutput.Print(sheet.SheetProficiencies.Proficiencies);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.PersonalityList] + ": ");
            ConsoleOutput.Print(sheet.SheetPersonality.PersonalityList);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.CombatStats] + ": ");
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HP] + ": " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP] + @"\" + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP]);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.AC] + ": " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.ArmorClass]);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Speed] + ": " + sheet.SheetRace.Speed);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HitDice] + ": " + sheet.SheetClass.HitDice);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HitDiceCount] + ": " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHitDices] + @"\" + sheet.SheetProgression.Level);
            Console.WriteLine(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.DeathDices] + ": " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathSucces] + @"\" + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathFailure]);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Inventory] + ": ");
            ConsoleOutput.PrintInventory(sheet.SheetInventory.Inventory);
            Console.WriteLine("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Traits] + ": ");
            ConsoleOutput.Print(sheet.TraitsList.TraitsList);
        }
    }
}