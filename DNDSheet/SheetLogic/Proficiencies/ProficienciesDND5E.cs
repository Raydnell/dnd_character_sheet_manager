namespace dnd_character_sheet
{
    public class ProficienciesDND5E : SheetProficiencies
    {
        public ProficienciesDND5E()
        {
            Proficiencies = new List<string>();
        }

        public override void AddProficiency(string prof)
        {
            if(Proficiencies.Contains(prof) == false)
            {
                Proficiencies.Add(prof);
            }
        }
        
        public override bool CheckProficiency(string prof)
        {
            if(Proficiencies.Contains(prof))
            {
                return true;
            }

            return false;
        }
    }
}