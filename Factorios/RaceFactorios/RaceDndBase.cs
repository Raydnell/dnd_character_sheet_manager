namespace dnd_character_sheet
{
    public abstract class RaceDndBase
    {
        private string _name = string.Empty;

        public string Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                _name = value;
            }
        }
    }
}