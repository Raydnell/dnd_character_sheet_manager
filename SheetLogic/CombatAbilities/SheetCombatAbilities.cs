using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetCombatAbilities
    {
        private int _maximumHP;

        [JsonProperty("MaximumHP")]
        public int MaximumHP
        {
            get
            {
                return _maximumHP;
            }
            protected set
            {
                _maximumHP = value;
            }
        }

        private int _currentHP;

        [JsonProperty("CurrentHP")]
        public int CurrentHP
        {
            get
            {
                return _currentHP;
            }
            protected set
            {
                _currentHP = value;
            }
        }

        private int _temporaryHP;

        [JsonProperty("TemporaryHP")]
        public int TemporaryHP
        {
            get
            {
                return _temporaryHP;
            }
            protected set
            {
                _temporaryHP = value;
            }
        }

        private int _speed;

        [JsonProperty("Speed")]
        public int Speed
        {
            get
            {
                return _speed;
            }
            protected set
            {
                _speed = value;
            }
        }

        private int _armorClass;

        [JsonProperty("ArmorClass")]
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

        private int _initiative;

        [JsonProperty("Initiative")]
        public int Initiative
        {
            get
            {
                return _initiative;
            }
            protected set
            {
                _initiative = value;
            }
        }

        private int _hitDice;

        [JsonProperty("HitDice")]
        public int HitDice
        {
            get
            {
                return _hitDice;
            }
            protected set
            {
                _hitDice = value;
            }
        }

        private int _totalHitDices;

        [JsonProperty("TotalHitDices")]
        public int TotalHitDices
        {
            get
            {
                return _totalHitDices;
            }
            protected set
            {
                _totalHitDices = value;
            }
        }

        private int _currentHitDices;

        [JsonProperty("CurrentHitDices")]
        public int CurrentHitDices
        {
            get
            {
                return _currentHitDices;
            }
            protected set
            {
                _currentHitDices = value;
            }
        }

        private int _deathSucces;

        [JsonProperty("DeathSucces")]
        public int DeathSucces
        {
            get
            {
                return _deathSucces;
            }
            protected set
            {
                _deathSucces = value;
            }
        }

        private int _deathFailure;

        [JsonProperty("DeathFailure")]
        public int DeathFailure
        {
            get
            {
                return _deathFailure;
            }
            protected set
            {
                _deathFailure = value;
            }
        }

        private int _passiveWisdom;

        [JsonProperty("PassiveWisdom")]
        public int PassiveWisdom
        {
            get
            {
                return _passiveWisdom;
            }
            protected set
            {
                _passiveWisdom = value;
            }
        }

        public abstract void SetMaximumHP(int amount);
        public abstract void SetCurrentHP(int amount);
        public abstract void SetTemporaryHP(int amount);
        public abstract void SetSpeed(int amount);
        public abstract void SetArmorClass(int amount);
        public abstract void SetInitiative(int amount);
        public abstract void SetHitDice(int amount);
        public abstract void SetTotalHitDices(int amount);
        public abstract void SetCurrentHitDices(int amount);
        public abstract void RaiseDeathSuccess();
        public abstract void RaiseDeathFailure();
        public abstract void ResetDeathSaves();
        public abstract void SetPassiveWisdom(int amount);
    }
}