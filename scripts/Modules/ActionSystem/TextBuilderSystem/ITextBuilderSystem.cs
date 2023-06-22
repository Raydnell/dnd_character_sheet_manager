namespace dnd_character_sheet
{
    public interface ITextBuilderSystem
    {
        public string BuildAbilitiesWithSaveThrows();
        public string BuildHero();
        public string BuildPersonality();
        public string BuildSkills();
        public string BuildProficiencies();
        public string BuildCombatStats();
        public string BuildEquipmentStats();
        public string BuildScreensPoints();
        public void NewMessageToLog(string message);
        public string BuildMessageBox();
    }
}