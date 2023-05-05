namespace dnd_character_sheet
{
    public class ItemsFabricDND5e
    {
        public ItemBaseDND5e CreateItem(Enum itemType)
        {
            if (Enum.TryParse<EnumItemTypesDND5e>(itemType.ToString(), out EnumItemTypesDND5e result))
            {
                switch(result)
                {
                    case EnumItemTypesDND5e.Armor:
                        return new ItemArmorDND5e();

                    case EnumItemTypesDND5e.Weapon:
                        return new ItemWeaponDND5e();

                    case EnumItemTypesDND5e.Item:
                    default:
                        return new ItemRegularDND5e();
                }
            }
            else
            {
                return new ItemRegularDND5e();
            }
        }
    }
}