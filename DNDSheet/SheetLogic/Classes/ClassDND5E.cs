namespace dnd_character_sheet
{
    public class ClassDND5E : SheetClass
    {
        public ClassDND5E()
        {
            Name = EnumClassesDnd5E.Bard;
        }

        public override void SetClass(Enum sheetClass)
        {
            if (Enum.TryParse<EnumClassesDnd5E>(sheetClass.ToString(), out EnumClassesDnd5E result))
            {
                Name =  result;
            } 
        }
    }
}
