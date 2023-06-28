namespace dnd_character_sheet
{
    public class CurrentHeroSheet
    {
        public static CharacterSheetBase HeroSheet = new CharacterSheetDnd5E();

        public static void SetSheetEdition(EnumEditions edition)
        {
            switch(edition)
            {
                case EnumEditions.DND5E:
                    HeroSheet = new CharacterSheetDnd5E();
                    break;
            }
        }

        public static void SaveSheet()
        {
            JsonSaveLoad.JsonSave(HeroSheet.Name, HeroSheet, $@"Data\DND5E\CharacterSheets\");
        }
    }
}