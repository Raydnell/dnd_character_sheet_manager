namespace dnd_character_sheet
{
    public class ProficienciesDND5E : SheetProficiencies
    {
        public ProficienciesDND5E()
        {
            Proficiencies = new List<EnumAllDND5eProficiencies>();
        }

        public override void AddProficiency(Enum prof)
        {
            if (Enum.TryParse<EnumAllDND5eProficiencies>(prof.ToString(), out EnumAllDND5eProficiencies result))
            {
                if(Proficiencies.Contains(result) == false)
                {
                    Proficiencies.Add(result);
                }
            }
            
        }
        
        public override bool CheckProficiency(EnumAllDND5eProficiencies prof)
        {
            if(Proficiencies.Contains(prof))
            {
                return true;
            }

            return false;
        }
    }
}