namespace dnd_character_sheet
{
    interface IProgression
    {
        void GainExpirience(int exp);
        void LevelUp();
        int GetProficiencyBonus();
    }
}
