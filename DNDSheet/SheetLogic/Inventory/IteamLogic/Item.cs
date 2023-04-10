namespace dnd_character_sheet
{
    public abstract class Item
    {
        private string _name = string.Empty;
        
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

        private string _rarity = string.Empty;
        public string Rarity
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

        private string _description = string.Empty;
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
    }
}