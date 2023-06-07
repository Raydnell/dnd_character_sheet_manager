namespace dnd_character_sheet
{
    public interface IHandAttack : IActionSystem
    {
        public string RollAttack(ItemBaseDND5e weapon);
    }
}