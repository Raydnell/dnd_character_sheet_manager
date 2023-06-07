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
            Edition = EnumEditions.DND5E;
            SheetPersonality = new PersonalityDND5E();
            SheetCombatAbilities = new CombatAbilitiesDND5E();
            SheetProficiencies = new ProficienciesDND5E();
            SheetInventory = new InventoryDND5E();
            TraitsList = new TraitsListDND5e();
            SheetSpells = new SheetSpellsDND5e();
            SheetEquipmentSlots = new EquipmentDND5e();
            Inspiration = false;
        }

        public override void SetUpRace(SheetRaceBase sheetRace)
        {
            SheetRace = sheetRace;
        }
        
        public override void SetUpClass(SheetClassBase sheetClass)
        {
            SheetClass = sheetClass;
        }

        public override void ChangeInspiration()
        {
            Inspiration = !Inspiration;
        }
    }
}