namespace dnd_character_sheet
{
    public class PrintSheetInfo
    {
        private IUserOutput _userOutput;

        public PrintSheetInfo()
        {
            _userOutput = new ConsoleOutput();
        }
        
        public void ShowSheetFields(CharacterSheetBase sheet, Enum language)
        {
            _userOutput.Print("Имя: " + sheet.Name);
            _userOutput.Print("\nРаса: " + sheet.SheetRace.Name);
            _userOutput.Print("\nКласс: " + sheet.SheetClass.Name);
            _userOutput.Print("\nУровень: " + sheet.SheetProgression.Level);
            _userOutput.Print("\nОпыт: " + sheet.SheetProgression.Expirience);
            _userOutput.Print("\nХарактеристики: ");
            _userOutput.Print(sheet.SheetAbilities.Abilities, language);
            _userOutput.Print("\nНавыки: ");
            //_userOutput.Print(sheet.SheetSkills.Skills);
            _userOutput.Print("\nВладения: ");
            //_userOutput.Print(sheet.SheetProficiencies.Proficiencies);
            _userOutput.Print("\nЛичные качества: ");
            //_userOutput.Print(sheet.SheetPersonality.PersonalityList);
            _userOutput.Print("\nБоевые качества: ");
            _userOutput.Print("HP - " + sheet.SheetCombatAbilities.CurrentHP + @"\" + sheet.SheetCombatAbilities.MaximumHP);
            _userOutput.Print("Класс доспеха - " + sheet.SheetCombatAbilities.ArmorClass);
            _userOutput.Print("Скорость - " + sheet.SheetCombatAbilities.Speed);
            _userOutput.Print("Кость хитов - " + sheet.SheetCombatAbilities.HitDice);
            _userOutput.Print("Количество костей хитов - " + sheet.SheetCombatAbilities.CurrentHitDices + @"\" + sheet.SheetCombatAbilities.TotalHitDices);
            _userOutput.Print("Спасброски от смерти - " + sheet.SheetCombatAbilities.DeathSucces + @"\" + sheet.SheetCombatAbilities.DeathFailure);
            _userOutput.Print("\nИнвентарь: ");
            _userOutput.Print(sheet.SheetInventory.Inventory);
        }
    }
}