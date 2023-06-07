namespace dnd_character_sheet
{
    public interface ICombatActions : IActionSystem
    {
        public string ChangeRound();
        public string ChangeHP();
        public string MakeDeathThrow();
        public string ChangeTHP();
    }
}