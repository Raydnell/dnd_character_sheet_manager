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
            Name =  sheetClass;
        }
    }
}
