using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class BaseEquipmentSystem
    {
        private Dictionary<EnumEquipmentSlotsDND5e, ItemBaseDND5e> _equipmentSlots;

        [JsonProperty("EquipmentSlots")]
        public Dictionary<EnumEquipmentSlotsDND5e, ItemBaseDND5e> EquipmentSlots
        {
            get
            {
                return _equipmentSlots;
            }
            protected set
            {
                _equipmentSlots = value;
            }
        }

        public void EquipItem(EnumEquipmentSlotsDND5e slot, ItemBaseDND5e item)
        {
            _equipmentSlots[slot] = item;
        }

        public void UnEquipSlot(EnumEquipmentSlotsDND5e slot)
        {
            if (_equipmentSlots.ContainsKey(slot))
            {
                _equipmentSlots.Remove(slot);
            }
        }
    }
}
