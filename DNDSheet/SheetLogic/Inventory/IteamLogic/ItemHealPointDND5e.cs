namespace dnd_character_sheet
{
    public class ItemHealPointDND5e : ItemBaseDND5e
    {
        private int _healingValue;
        public int HealingValue
        {
            get
            {
                return _healingValue;
            }
            set
            {
                _healingValue = value;
            }
        }
        
        public ItemHealPointDND5e()
        {
            HealingValue = 7;
        }
    }
}