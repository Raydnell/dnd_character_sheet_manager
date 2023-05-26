namespace dnd_character_sheet
{
    public class CurrentHeroSheet
    {
        public static CharacterSheetBase HeroSheet = new CharacterSheetDnd5E();

        public static CharacterSheetBase SetSheetEdition(EnumEditions edition)
        {
            switch(edition)
            {
                case EnumEditions.DND5E:
                    return new CharacterSheetDnd5E();
            }

            return new CharacterSheetDnd5E();
        }
    }
}