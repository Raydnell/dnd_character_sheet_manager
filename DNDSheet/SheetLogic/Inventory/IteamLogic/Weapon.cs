namespace dnd_character_sheet
{
    public abstract class Weapon : BaseItem
    {
        private int _damageDiceCount;
        public int DamageDiceCount
        {
            get
            {
                return _damageDiceCount;
            }
            protected set
            {
                _damageDiceCount = value;
            }
        }

        private int _damageDiceValue;
        public int DamageDiceValue
        {
            get
            {
                return _damageDiceValue;
            }
            protected set
            {
                _damageDiceValue = value;
            }
        }

        private int _damageModificator;
        public int DamageModificator
        {
            get
            {
                return _damageModificator;
            }
            protected set
            {
                _damageModificator = value;
            }
        }

        private string _damageType = string.Empty;
        public string DamageType
        {
            get
            {
                return _damageType;
            }
            protected set
            {
                _damageType = value;
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
    }
}
