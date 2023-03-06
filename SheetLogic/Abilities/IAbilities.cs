namespace dnd_character_sheet
{
    public interface IAbilities
    {
        public int GetAbilityModificator(string ability);
        public int GetAbilityScore(string ability);
        public int AbilityBonus(int score);
        public void SetAbilities(Dictionary<string, int> abilities);
        public Dictionary<string, int> GetAbilities();
    }
}
