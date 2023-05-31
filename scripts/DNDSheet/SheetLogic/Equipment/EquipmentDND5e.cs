namespace dnd_character_sheet
{
    public class EquipmentDND5e : BaseEquipmentSystem
    {
        public EquipmentDND5e()
        {
            EquipmentSlots = new Dictionary<EnumEquipmentSlotsDND5e, ItemBaseDND5e>();
        }
    }
}