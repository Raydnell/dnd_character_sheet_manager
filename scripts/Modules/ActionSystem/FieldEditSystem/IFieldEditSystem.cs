namespace dnd_character_sheet
{
    public interface IFieldEditSystem : IActionSystem
    {
        public string ChangeName();
        public string ChangeClass();
        public string ChangeRace();
        public string ChangeAbilities();
        public string ChangeSkills();
        public string ChangeMaximumHP();
        public string AddOrRemoveProficiency();
        public string AddProficiency();
        public string RemoveProficiency();
        public string EditPersonality();
    }
}