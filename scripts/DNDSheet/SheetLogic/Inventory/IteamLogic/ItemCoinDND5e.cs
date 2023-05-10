using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public class ItemCoinDND5e : ItemBaseDND5e
    {
        private EnumCoinsTypeDND5e _coinType;

        [JsonProperty("CoinType")]
        public EnumCoinsTypeDND5e CoinType
        {
            get
            {
                return _coinType;
            }
            protected set
            {
                _coinType = value;
            }
        }
        
        public ItemCoinDND5e()
        {
            ItemType = EnumItemTypesDND5e.Coin;
            Name = string.Empty;
            BaseCost = 0;
            Weight = 0.02f;
            Rarity = EnumItemRarityTypes.Usual;
            Description = string.Empty;
            IsMagic = false;
            ItemId = 0;
            CoinType = EnumCoinsTypeDND5e.Copper;
        }

        public void SetCoinType(EnumCoinsTypeDND5e type)
        {
            CoinType = type;
        }
    }
}