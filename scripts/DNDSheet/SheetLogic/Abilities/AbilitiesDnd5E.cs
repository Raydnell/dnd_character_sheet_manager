namespace dnd_character_sheet
{
    public class AbilitiesDnd5E : SheetAbilities
    {
        public AbilitiesDnd5E()
        {
            Abilities = new Dictionary<EnumAbilitiesDnd5E, int>()
            {
                [EnumAbilitiesDnd5E.Strength] = 1,
                [EnumAbilitiesDnd5E.Dexterity] = 1,
                [EnumAbilitiesDnd5E.Constitution] = 1,
                [EnumAbilitiesDnd5E.Intelligence] = 1,
                [EnumAbilitiesDnd5E.Wisdom] = 1,
                [EnumAbilitiesDnd5E.Charisma] = 1
            };
        }
        
        public override int GetAbilityModificator(EnumAbilitiesDnd5E ability)
        {
            return AbilityBonus(GetAbilityScore(ability));
        }

        public override int GetAbilityScore(EnumAbilitiesDnd5E ability)
        {
            return Abilities[ability];
        }

        public override int AbilityBonus(int score)
        {
            return score / 2 - 5;
        }

        public override void SetAbilities(Dictionary<Enum, int> abilities)
        {
            foreach(var item in abilities)
            {
                if (Enum.TryParse<EnumAbilitiesDnd5E>(item.Key.ToString(), out EnumAbilitiesDnd5E result))
                {
                    Abilities[result] = item.Value;
                }
            }
        }

        public override void RaiseAbilityScore(EnumAbilitiesDnd5E abilityName)
        {
            if (Abilities[abilityName] + 1 <= 30)
            {
                Abilities[abilityName]++;
            }
        }
        public override void LowerAbilityScore(EnumAbilitiesDnd5E abilityName)
        {
            if (Abilities[abilityName] - 1 >= 1)
            {
                Abilities[abilityName]--;
            }
        }
    }
}