namespace dnd_character_sheet
{
    public abstract class CharacterSheetBase
    {
        public string _name { get; private set;}
        
        public CharacterSheetBase()
        {
            _name = "new_sheet";
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public virtual void SetRace(string raceName)
        {

        }

        public virtual void SetClass(string className)
        {
            
        }
    }
}