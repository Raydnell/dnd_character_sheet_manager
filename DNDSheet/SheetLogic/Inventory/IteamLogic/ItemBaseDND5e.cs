using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class ItemBaseDND5e
    {
        private Random _random = new Random();
        
        private string _name;
        
        [JsonProperty("Name")]
        public string Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                _name = value;
            }
        }

        private int _baseCost;

        [JsonProperty("BaseCost")]
        public int BaseCost
        {
            get
            {
                return _baseCost;
            }
            protected set
            {
                _baseCost = value;
            }
        }

        private int _weight;

        [JsonProperty("Weight")]
        public int Weight
        {
            get
            {
                return _weight;
            }
            protected set
            {
                _weight = value;
            }
        }

        private EnumItemRarityTypes _rarity;

        [JsonProperty("Rarity")]
        public EnumItemRarityTypes Rarity
        {
            get
            {
                return _rarity;
            }
            protected set
            {
                _rarity = value;
            }
        }

        private string _description;

        [JsonProperty("Description")]
        public string Description
        {
            get
            {
                return _description;
            }
            protected set
            {
                _description = value;
            }
        }

        private bool _isMagic;

        [JsonProperty("IsMagic")]
        public bool IsMagic
        {
            get
            {
                return _isMagic;
            }
            protected set
            {
                _isMagic = value;
            }
        }

        private int _itemId;

        [JsonProperty("ItemId")]
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            protected set
            {
                _itemId = value;
            }
        }

        private EnumItemTypesDND5e _itemType;

        [JsonProperty("ItemType")]
        public EnumItemTypesDND5e ItemType
        {
            get
            {
                return _itemType;
            }
            protected set
            {
                _itemType = value;
            }
        }

        private int _damageDiceCount;

        [JsonProperty("DamageDiceCount")]
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

        [JsonProperty("DamageDiceValue")]
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

        [JsonProperty("DamageModificator")]
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

        private EnumItemDamageTypesDND5e _damageType;

        [JsonProperty("DamageType")]
        public EnumItemDamageTypesDND5e DamageType
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

        private int _strengthRequirement;

        [JsonProperty("StrengthRequirement")]
        public int StrengthRequirement
        {
            get
            {
                return _strengthRequirement;
            }
            protected set
            {
                _strengthRequirement = value;
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

        private int _maxAgilityBonus;

        [JsonProperty("MaxAgilityBonus")]
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

        private EnumWeaponPropertiesDND5e _weaponProperty;

        [JsonProperty("WeaponProperty")]
        public EnumWeaponPropertiesDND5e WeaponProperty
        {
            get
            {
                return _weaponProperty;
            }
            protected set
            {
                _weaponProperty = value;
            }
        }

        private EnumArmorProficienciesDND5E _armorType;

        [JsonProperty("ArmorType")]
        public EnumArmorProficienciesDND5E ArmorType
        {
            get
            {
                return _armorType;
            }
            protected set
            {
                _armorType = value;
            }
        }

        private EnumWeaponsProficienciesDND5E _weaponProficiencyConcrete;

        [JsonProperty("WeaponProficiencyConcrete")]
        public EnumWeaponsProficienciesDND5E WeaponProficiencyConcrete
        {
            get
            {
                return _weaponProficiencyConcrete;
            }
            protected set
            {
                _weaponProficiencyConcrete = value;
            }
        }

        private EnumWeaponsGroupsDND5E _weaponProficiencyGroup;

        [JsonProperty("WeaponProficiencyGroup")]
        public EnumWeaponsGroupsDND5E WeaponProficiencyGroup
        {
            get
            {
                return _weaponProficiencyGroup;
            }
            protected set
            {
                _weaponProficiencyGroup = value;
            }
        }

        public void SetItemId()
        {
            ItemId = _random.Next(1000, 10000);
        }

        public void SetName(string value)
        {
            Name = value;
        }

        public void SetBaseCost(int value)
        {
            BaseCost = value;
        }

        public void SetWeight(int value)
        {
            Weight = value;
        }

        public void SetRarity(EnumItemRarityTypes value)
        {
            Rarity = value;
        }

        public void SetDescription(string value)
        {
            Description = value;
        }

        public void SetIsMagic(bool value)
        {
            IsMagic = value;
        }

        public void SetItemType(EnumItemTypesDND5e value)
        {
            ItemType = value;
        }

        public void SetDamageDiceCount(int value)
        {
            DamageDiceCount = value;
        }

        public void SetDamageDiceValue(int value)
        {
            DamageDiceValue = value;
        }

        public void SetDamageModificator(int value)
        {
            DamageModificator = value;
        }

        public void SetDamageType(EnumItemDamageTypesDND5e value)
        {
            DamageType = value;
        }

        public void SetStrengthRequirement(int value)
        {
            StrengthRequirement = value;
        }

        public void SetArmorClass(int value)
        {
            ArmorClass = value;
        }

        public void SetMaxAgilityBonus(int value)
        {
            MaxAgilityBonus = value;
        }

        public void SetWeaponProperty(EnumWeaponPropertiesDND5e value)
        {
            WeaponProperty = value;
        }

        public void SetArmorType(EnumArmorProficienciesDND5E value)
        {
            ArmorType = value;
        }

        public void SetWeaponGroup(EnumWeaponsGroupsDND5E value)
        {
            _weaponProficiencyGroup = value;
        }

        public void SetWeaponConcreteProf(EnumWeaponsProficienciesDND5E value)
        {
            _weaponProficiencyConcrete = value;
        }
    }
}