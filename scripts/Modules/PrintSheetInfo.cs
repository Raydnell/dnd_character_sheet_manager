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
            _userOutput.Print("Имя: " + sheet.Name);
            _userOutput.Print("\nРаса: " + sheet.SheetRace.Name);
            _userOutput.Print("\nКласс: " + sheet.SheetClass.Name);
            _userOutput.Print("\nУровень: " + sheet.SheetProgression.Level);
            _userOutput.Print("\nОпыт: " + sheet.SheetProgression.Expirience);
            _userOutput.Print("\nХарактеристики: ");
            _userOutput.Print(sheet.SheetAbilities.Abilities);
            _userOutput.Print("\nНавыки: ");
            _userOutput.Print(sheet.SheetSkills.Skills);
            _userOutput.Print("\nВладения: ");
            _userOutput.Print(sheet.SheetProficiencies.Proficiencies);
            _userOutput.Print("\nЛичные качества: ");
            _userOutput.Print(sheet.SheetPersonality.PersonalityList);
            _userOutput.Print("\nБоевые качества: ");
            _userOutput.Print("HP - " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP] + @"\" + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP]);
            _userOutput.Print("Класс доспеха - " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.ArmorClass]);
            _userOutput.Print("Скорость - " + sheet.SheetRace.Speed);
            _userOutput.Print("Кость хитов - " + sheet.SheetClass.HitDice);
            _userOutput.Print("Количество костей хитов - " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHitDices] + @"\" + sheet.SheetProgression.Level);
            _userOutput.Print("Спасброски от смерти - " + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathSucces] + @"\" + sheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathFailure]);
            _userOutput.Print("\nИнвентарь: ");
            //_userOutput.Print(sheet.SheetInventory.Inventory);
            _userOutput.Print("\nУмения:\n");
            _userOutput.Print(sheet.TraitsList.TraitsList);
        }
    }
}