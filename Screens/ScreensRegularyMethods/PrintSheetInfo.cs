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
            _userOutput.Print("Мировоззрение - " + sheet.SheetPersonality.Alignment);
            _userOutput.Print("Предыстория - " + sheet.SheetPersonality.Background);
            _userOutput.Print("Личные качества - " + sheet.SheetPersonality.PersonalityTraits);
            _userOutput.Print("Идеалы - " + sheet.SheetPersonality.Ideals);
            _userOutput.Print("Привязанности - " + sheet.SheetPersonality.Bonds);
            _userOutput.Print("Слабости - " + sheet.SheetPersonality.Flaws);
            _userOutput.Print("Глаза - " + sheet.SheetPersonality.Eyes);
            _userOutput.Print("Волосы - " + sheet.SheetPersonality.Hair);
            _userOutput.Print("Рост - " + sheet.SheetPersonality.Height);
            _userOutput.Print("Вес - " + sheet.SheetPersonality.Weight);
            _userOutput.Print("Возраст - " + sheet.SheetPersonality.Age);
            _userOutput.Print("Кожа - " + sheet.SheetPersonality.Skin);
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