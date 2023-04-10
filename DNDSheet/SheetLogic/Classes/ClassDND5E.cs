namespace dnd_character_sheet
{
    public class ClassDND5E : SheetClass
    {
        public ClassDND5E()
        {
            Name = string.Empty;
        }

        public override void SetClass(string sheetClass)
        {
            if (Enum.TryParse<EnumClassesDnd5E>(sheetClass, out EnumClassesDnd5E result))
            {
                Name =  result.ToString();
            }
        }
    }
}
