using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public class ItemArmorDND5e : ItemBaseDND5e
    {
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
        
        public ItemArmorDND5e()
        {
            ItemType = EnumItemTypesDND5e.Armor;
            Name = string.Empty;
            BaseCost = 0;
            Weight = 0;
            Rarity = EnumItemRarityTypes.Usual;
            Description = string.Empty;
            IsMagic = false;
            ItemId = 0;
            StrengthRequirement = 0;
            ArmorClass = 0;
            MaxAgilityBonus = 0;
            ArmorType = EnumArmorProficienciesDND5E.LightArmor;
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

        public void SetArmorType(EnumArmorProficienciesDND5E value)
        {
            ArmorType = value;
        }
    }
}