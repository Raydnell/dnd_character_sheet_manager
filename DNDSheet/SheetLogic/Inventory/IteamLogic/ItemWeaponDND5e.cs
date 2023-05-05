namespace dnd_character_sheet
{
    public class ItemWeaponDND5e : ItemBaseDND5e
    {
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
            WeaponProperty = EnumWeaponPropertiesDND5e.Light;
            WeaponProficiencyConcrete = EnumWeaponsProficienciesDND5E.Club;
            WeaponProficiencyGroup = EnumWeaponsGroupsDND5E.SimpleMelee;
        }
    }
}
