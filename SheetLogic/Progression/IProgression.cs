namespace dnd_character_sheet
{
    public interface IProgression
    {
        public void GainExpirience(int exp);
        public void LevelUp();
        public int GetProficiencyBonus();
        public int GetExpirience();
    }
}
