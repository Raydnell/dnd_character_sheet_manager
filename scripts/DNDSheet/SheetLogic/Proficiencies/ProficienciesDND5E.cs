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
                if (Proficiencies.Contains(result) == false)
                {
                    Proficiencies.Add(result);
                }
            }
            
        }
        
        public override bool CheckProficiency(Enum prof)
        {
            if (Enum.TryParse<EnumAllDND5eProficiencies>(prof.ToString(), out EnumAllDND5eProficiencies result))
            {
                if (Proficiencies.Contains(result))
                {
                    return true;
                }
            }

            return false;
        }

        public override void RemoveProficiency(Enum prof)
        {
            if (Enum.TryParse<EnumAllDND5eProficiencies>(prof.ToString(), out EnumAllDND5eProficiencies result))
            {
                if (Proficiencies.Contains(result))
                {
                    Proficiencies.Remove(result);
                }
            }
        }
    }
}