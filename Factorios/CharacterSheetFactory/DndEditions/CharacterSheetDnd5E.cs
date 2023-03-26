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
            SheetRace = new RaceDND5E();
            SheetClass = new ClassDND5E();
            Edition = "DND5E";
        }
    }
}