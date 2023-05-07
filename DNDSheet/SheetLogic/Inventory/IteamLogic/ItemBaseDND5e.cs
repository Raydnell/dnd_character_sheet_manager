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
    }
}