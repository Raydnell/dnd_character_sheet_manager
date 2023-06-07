namespace dnd_character_sheet
{
    public interface IEquipmentSystem : IActionSystem
    {
        public void EquipArmor();
        public void EquipHand(EnumEquipmentSlotsDND5e slot);
        public void MakeArmorSlotList();
        public void MakeHandSlotList();
    }
}