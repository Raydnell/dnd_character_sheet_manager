namespace dnd_character_sheet
{
    public class SaveThrowsDnd5E : SheetSaveThrows
    {
        public SaveThrowsDnd5E()
        {
            SaveThrows = new List<string>();
        }
        
        public override void SetSaveTrows(string className)
        {
            switch (className)
            {
                case "bard":
                    SaveThrows.Add("dexterity");
                    SaveThrows.Add("charisma");
                    break;

                case "barbarian":
                case "fighter":
                    SaveThrows.Add("strength");
                    SaveThrows.Add("constitution");
                    break;

                case "wizard":
                case "druid":
                    SaveThrows.Add("intelligence");
                    SaveThrows.Add("wisdom");
                    break;

                case "cleric":
                case "warlock":
                case "paladin":
                    SaveThrows.Add("wisdom");
                    SaveThrows.Add("charisma");
                    break;

                case "monk":
                case "ranger":
                    SaveThrows.Add("strength");
                    SaveThrows.Add("dexterity");
                    break;

                case "rogue":
                    SaveThrows.Add("dexterity");
                    SaveThrows.Add("intelligence");
                    break;

                case "sorcerer":
                    SaveThrows.Add("constitution");
                    SaveThrows.Add("charisma");
                    break;
            }
        }

        public override bool CheckSaveThrow(string saveTrow)
        {
            return SaveThrows.Contains(saveTrow);
        }
    }
}