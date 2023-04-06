namespace dnd_character_sheet
{
    public static class ProficiencyGroups
    {
        public static List<Type> ProficienciesGroups = new List<Type>()
        {
            typeof(EnumArmorProficienciesDND5E),
            typeof(EnumArtisansToolsProficienciesDND5E),
            typeof(EnumGamingSetProficienciesDND5E),
            typeof(EnumMartialMeleeProficienciesDND5E),
            typeof(EnumMartialRangedProficienciesDND5E),
            typeof(EnumMusicalInstrumentProficienciesDND5E),
            typeof(EnumOrdinaryToolProficienciesDND5E),
            typeof(EnumSimpleMeleeProficienciesDND5E),
            typeof(EnumSimpleRangedProficienciesDND5E)
        };

        public static Type getEnumByString(string enumName)
        {
            return typeof(EnumSimpleRangedProficienciesDND5E);
        }
    }
}