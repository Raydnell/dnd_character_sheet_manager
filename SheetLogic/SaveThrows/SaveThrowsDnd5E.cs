namespace dnd_character_sheet
{
    public class SaveThrowsDnd5E : SheetSaveThrows
    {
        public SaveThrowsDnd5E()
        {
            SaveThrows = new Dictionary<string, bool>()
            {
                ["strength"] = false,
                ["dexterity"] = false,
                ["constitution"] = false,
                ["intelligence"] = false,
                ["wisdom"] = false,
                ["charisma"] = false
            };
        }
        
        public override void SetSaveTrows(string className)
        {
            switch (className)
            {
                case "bard":
                    SaveThrows["dexterity"] = true;
                    SaveThrows["charisma"] = true;
                    break;

                case "barbarian":
                case "fighter":
                    SaveThrows["strength"] = true;
                    SaveThrows["constitution"] = true;
                    break;

                case "wizard":
                case "druid":
                    SaveThrows["intelligence"] = true;
                    SaveThrows["wisdom"] = true;
                    break;

                case "cleric":
                case "warlock":
                case "paladin":
                    SaveThrows["wisdom"] = true;
                    SaveThrows["charisma"] = true;
                    break;

                case "monk":
                case "ranger":
                    SaveThrows["strength"] = true;
                    SaveThrows["dexterity"] = true;
                    break;

                case "rogue":
                    SaveThrows["dexterity"] = true;
                    SaveThrows["intelligence"] = true;
                    break;

                case "sorcerer":
                    SaveThrows["constitution"] = true;
                    SaveThrows["charisma"] = true;
                    break;
            }
        }

        public override bool CheckSaveThrow(string saveTrow)
        {
            if(SaveThrows.ContainsKey(saveTrow))
            {
                return SaveThrows[saveTrow];
            }
            else
            {
                return false;
            }
        }
    }
}