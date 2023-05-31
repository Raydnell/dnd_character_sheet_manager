using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public class ItemWeaponDND5e : ItemBaseDND5e
    {
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
        
        private List<EnumWeaponPropertiesDND5e> _weaponProperty;

        [JsonProperty("WeaponProperty")]
        public List<EnumWeaponPropertiesDND5e> WeaponProperty
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
        
        
        public ItemWeaponDND5e()
        {
            ItemType = EnumItemTypesDND5e.Weapon;
            Name = string.Empty;
            BaseCost = 0;
            Weight = 0;
            Rarity = EnumItemRarityTypes.Usual;
            Description = string.Empty;
            IsMagic = false;
            ItemId = 0;
            DamageDiceCount = 0;
            DamageDiceValue = 0;
            DamageModificator = 0;
            DamageType = EnumItemDamageTypesDND5e.Bludgeoning;
            WeaponProperty = new List<EnumWeaponPropertiesDND5e>();
            WeaponProficiencyConcrete = EnumWeaponsProficienciesDND5E.Club;
            WeaponProficiencyGroup = EnumWeaponsGroupsDND5E.SimpleMelee;
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

        public void AddWeaponProperty(EnumWeaponPropertiesDND5e value)
        {
            if (WeaponProperty.Contains(value) == false)
            {
                WeaponProperty.Add(value);
            }
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
