namespace dnd_character_sheet
{
    public class CharacterSheetDnd5E : CharacterSheetBase
    {
        public CharacterSheetDnd5E()
        {
            SheetAbilities = new AbilitiesDnd5E();
            SheetSaveThrows = new SaveThrowsDnd5E();
            SheetSkills = new SkillsDnd5E();
            SheetProgression = new ProgressionDnd5E();
            ClassFactory = new ClassDnd5EFactory();
            RaceFactory = new RaceDnd5EFactory();
        }

        public override void SetRace(string race)
        {
            SheetRace = RaceFactory.CreateRace(race);
        }

        public override void SetClass(string sheetClass)
        {
            SheetClass = ClassFactory.CreateClassDnd(sheetClass);
        }
    }
}