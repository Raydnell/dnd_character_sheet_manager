namespace dnd_character_sheet
{
    public static class ProficiencyGroups
    {
        public static List<Type> ProficienciesGroups = new List<Type>()
        {
            typeof(EnumArmorProficienciesDND5E),
            typeof(EnumGamingSetProficienciesDND5E),
            typeof(EnumWeaponsProficienciesDND5E),
            typeof(EnumMusicalInstrumentProficienciesDND5E),
        };

        public static Type GetEnumByString(string enumName)
        {
            switch(enumName)
            {
                case "Weapons":
                    return typeof(EnumWeaponsProficienciesDND5E);
                    
                case "Musician":
                    return typeof(EnumMusicalInstrumentProficienciesDND5E);
                    
                case "Gaming":
                    return typeof(EnumGamingSetProficienciesDND5E);

                case "Armor":
                    return typeof(EnumArmorProficienciesDND5E);
                    
                default:
                    break;
            }

            return typeof(EnumIncorrectInput);
        }
    }
}