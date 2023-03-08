namespace dnd_character_sheet
{
    public interface IClassDndFactory
    {
        public ClassDndBase CreateClassDnd(string sheetClass);
    }
}