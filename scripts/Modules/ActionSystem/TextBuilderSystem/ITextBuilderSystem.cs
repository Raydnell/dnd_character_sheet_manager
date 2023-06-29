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
        public string BuildAbilities();
        public string BuildSkillsEditor(int pointer);
        public string BuildProficienciesEditor(int pointer);
        public string BuildSpellsRows(List<KeyValuePair<int, string>> spells, int currentPage, int totalPages);
        public string BuildSpellDescription(int spellId);
        public string BuildTraitsRows(List<KeyValuePair<int, string>> traits, int currentPage, int totalPages);
        public string BuildTraitDescription(int traitId);
    }
}