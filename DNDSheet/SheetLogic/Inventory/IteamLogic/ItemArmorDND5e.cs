using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public class ItemArmorDND5e : ItemBaseDND5e
    {
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
    }
}