namespace dnd_character_sheet
{
    public abstract class Armor : BaseItem
    {
        private int _armorClass;
        public int ArmorClass
        {
            get
            {
                return _armorClass;
            }
            protected set
            {
                _armorClass = value;
            }
        }

        private string _requirement = string.Empty;
        public string Requirement
        {
            get
            {
                return _requirement;
            }
            protected set
            {
                _requirement = value;
            }
        }

        private int _maxAgilityBonus;
        public int MaxAgilityBonus
        {
            get
            {
                return _maxAgilityBonus;
            }
            protected set
            {
                _maxAgilityBonus = value;
            }
        }
    }
}