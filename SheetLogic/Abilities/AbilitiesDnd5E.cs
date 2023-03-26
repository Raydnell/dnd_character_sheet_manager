namespace dnd_character_sheet
{
    public class AbilitiesDnd5E : SheetAbilities
    {
        public AbilitiesDnd5E()
        {
            Abilities = new Dictionary<string, int>()
            {
                ["strength"] = 1,
                ["dexterity"] = 1,
                ["constitution"] = 1,
                ["intelligence"] = 1,
                ["wisdom"] = 1,
                ["charisma"] = 1
            };
        }
        
        public override int GetAbilityModificator(string ability)
        {
            return AbilityBonus(GetAbilityScore(ability));
        }

        public override int GetAbilityScore(string ability)
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

        public override void SetAbilities(Dictionary<string, int> abilities)
        {
            if(abilities.Count() == 6)
            {
                foreach(var item in abilities)
                {
                    Abilities[item.Key] = item.Value;
                }
            }
            else
            {
                throw new InvalidOperationException("Abilities count must be six");
            }
        }
    }
}