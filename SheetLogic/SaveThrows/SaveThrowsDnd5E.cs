namespace dnd_character_sheet
{
    public class SaveThrowsDnd5E : ISaveThrows
    {
        private Dictionary<string, bool> _saveThrows;

        public SaveThrowsDnd5E()
        {
            _saveThrows = new Dictionary<string, bool>()
            {
                ["strength"] = false,
                ["dexterity"] = false,
                ["constitution"] = false,
                ["intelligence"] = false,
                ["wisdom"] = false,
                ["charisma"] = false
            };
        }
        
        public void SetSaveTrows(string className)
        {
            switch (className)
            {
                case "bard":
                    _saveThrows["dex"] = true;
                    _saveThrows["cha"] = true;
                    break;

                case "barbarian":
                case "fighter":
                    _saveThrows["str"] = true;
                    _saveThrows["con"] = true;
                    break;

                case "wizard":
                case "druid":
                    _saveThrows["int"] = true;
                    _saveThrows["wis"] = true;
                    break;

                case "cleric":
                case "warlock":
                case "paladin":
                    _saveThrows["wis"] = true;
                    _saveThrows["cha"] = true;
                    break;

                case "monk":
                case "ranger":
                    _saveThrows["str"] = true;
                    _saveThrows["dex"] = true;
                    break;

                case "rogue":
                    _saveThrows["dex"] = true;
                    _saveThrows["int"] = true;
                    break;

                case "sorcerer":
                    _saveThrows["con"] = true;
                    _saveThrows["cha"] = true;
                    break;
            }
        }

        public bool CheckSaveThrow(string saveTrow)
        {
            if(_saveThrows.ContainsKey(saveTrow))
            {
                return _saveThrows[saveTrow];
            }
            else
            {
                return false;
            }
        }

        public Dictionary<string, bool> GetSaveThrows()
        {
            return _saveThrows;
        }
    }
}