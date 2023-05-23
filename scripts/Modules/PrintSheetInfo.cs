namespace dnd_character_sheet
{
    public class PrintSheetInfo
    {
        private IUserOutput _userOutput;

        public PrintSheetInfo()
        {
            _userOutput = new ConsoleOutput();
        }
        
        public void ShowSheetFields(CharacterSheetBase sheet)
        {
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Name] + ": " + sheet.Name);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Race] + ": " + LocalizationsStash.SelectedLocalization[sheet.SheetRace.Name]);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Class] + ": " + LocalizationsStash.SelectedLocalization[sheet.SheetClass.Name]);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Level] + ": " + sheet.SheetProgression.Level);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Expirience] + ": " + sheet.SheetProgression.Expirience);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Abilities] + ": ");
            _userOutput.Print(sheet.SheetAbilities.Abilities);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Skills] + ": ");
            _userOutput.Print(sheet.SheetSkills.Skills);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Proficiencies] + ": ");
            _userOutput.Print(sheet.SheetProficiencies.Proficiencies);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.PersonalityList] + ": ");
            _userOutput.Print(sheet.SheetPersonality.PersonalityList);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.CombatStats] + ": ");
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HP] + ": " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP] + @"\" + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP]);
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.AC] + ": " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.ArmorClass]);
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Speed] + ": " + sheet.SheetRace.Speed);
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HitDice] + ": " + sheet.SheetClass.HitDice);
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HitDiceCount] + ": " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHitDices] + @"\" + sheet.SheetProgression.Level);
            _userOutput.Print(LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.DeathDices] + ": " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathSucces] + @"\" + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathFailure]);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Inventory] + ": ");
            _userOutput.PrintInventory(sheet.SheetInventory.Inventory);
            _userOutput.Print("\n" + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Traits] + ": ");
            _userOutput.Print(sheet.TraitsList.TraitsList);
        }
    }
}