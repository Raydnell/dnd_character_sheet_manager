namespace dnd_character_sheet
{
    public class ItemRegularDND5e : ItemBaseDND5e
    {
        public ItemRegularDND5e()
        {
            ItemType = EnumItemTypesDND5e.Item;
            Name = string.Empty;
            BaseCost = 0;
            Weight = 0;
            Rarity = EnumItemRarityTypes.Usual;
            Description = string.Empty;
            IsMagic = false;
            ItemId = 0;
        }
    }
}