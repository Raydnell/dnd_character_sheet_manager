namespace dnd_character_sheet
{
    interface IAbilities
    {
        int GetAbilityModificator(string abilityName);
        int GetAbilityScore(string ability);
        int AbilityBonus(int score);
        void SetAbilities(Dictionary<string, int> abilities);
        Dictionary<string, int> GetAbilities();
    }
}
