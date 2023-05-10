using Newtonsoft.Json;

namespace dnd_character_sheet
{
    public abstract class SheetProficiencies
    {
        private List<EnumAllDND5eProficiencies> _proficiencies = new List<EnumAllDND5eProficiencies>();

        [JsonProperty("Proficiencies")]
        public List<EnumAllDND5eProficiencies> Proficiencies
        {
            get
            {
                return _proficiencies;
            }
            protected set
            {
                _proficiencies = value;
            }
        }

        public abstract void AddProficiency(Enum prof);
        public abstract bool CheckProficiency(EnumAllDND5eProficiencies prof);
    }
}
