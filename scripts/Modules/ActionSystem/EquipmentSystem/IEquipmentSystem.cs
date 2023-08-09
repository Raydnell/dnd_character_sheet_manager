namespace dnd_character_sheet
{
    public interface IEquipmentSystem : IActionSystem
    {
        public string EquipArmor();
        public string EquipHand(EnumEquipmentSlotsDND5e slot);
        public void MakeArmorSlotList();
        public void MakeHandSlotList();
    }
}