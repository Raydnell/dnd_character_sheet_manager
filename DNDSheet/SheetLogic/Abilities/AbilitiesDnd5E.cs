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
            if (score == 1)
                return -5;
            else if (score <= 3)
                return -4;
            else if (score <= 5)
                return -3;
            else if (score <= 7)
                return -2;
            else if (score <= 9)
                return -1;
            else if (score <= 11)
                return 0;
            else if (score <= 13)
                return 1;
            else if (score <= 15)
                return 2;
            else if (score <= 17)
                return 3;
            else if (score <= 19)
                return 4;
            else if (score <= 21)
                return 5;
            else if (score <= 23)
                return 6;
            else if (score <= 25)
                return 7;
            else if (score <= 27)
                return 8;
            else if (score <= 29)
                return 9;
            else
                return 10;
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

        public override void SetAbilityScore(EnumAbilitiesDnd5E abilityName, int abilityScore)
        {
            if(abilityScore > 0 && Abilities.ContainsKey(abilityName))
            {
                Abilities[abilityName] = abilityScore;
            }
        }
    }
}