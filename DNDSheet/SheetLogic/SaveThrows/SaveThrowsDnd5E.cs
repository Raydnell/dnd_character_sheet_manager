namespace dnd_character_sheet
{
    public class SaveThrowsDnd5E : SheetSaveThrows
    {
        public SaveThrowsDnd5E()
        {
            SaveThrows = new List<EnumAbilitiesDnd5E>();
        }
        
        public override void SetSaveTrows(EnumClassesDnd5E className)
        {
            switch (className)
            {
                case EnumClassesDnd5E.Bard:
                    SaveThrows.Add(EnumAbilitiesDnd5E.Dexterity);
                    SaveThrows.Add(EnumAbilitiesDnd5E.Charisma);
                    break;

                case EnumClassesDnd5E.Barbarian:
                case EnumClassesDnd5E.Fighter:
                    SaveThrows.Add(EnumAbilitiesDnd5E.Strength);
                    SaveThrows.Add(EnumAbilitiesDnd5E.Strength);
                    break;

                case EnumClassesDnd5E.Wizard:
                case EnumClassesDnd5E.Druid:
                    SaveThrows.Add(EnumAbilitiesDnd5E.Intelligence);
                    SaveThrows.Add(EnumAbilitiesDnd5E.Wisdom);
                    break;

                case EnumClassesDnd5E.Cleric:
                case EnumClassesDnd5E.Warlock:
                case EnumClassesDnd5E.Paladin:
                    SaveThrows.Add(EnumAbilitiesDnd5E.Wisdom);
                    SaveThrows.Add(EnumAbilitiesDnd5E.Charisma);
                    break;

                case EnumClassesDnd5E.Monk:
                case EnumClassesDnd5E.Ranger:
                    SaveThrows.Add(EnumAbilitiesDnd5E.Strength);
                    SaveThrows.Add(EnumAbilitiesDnd5E.Dexterity);
                    break;

                case EnumClassesDnd5E.Rogue:
                    SaveThrows.Add(EnumAbilitiesDnd5E.Dexterity);
                    SaveThrows.Add(EnumAbilitiesDnd5E.Intelligence);
                    break;

                case EnumClassesDnd5E.Sorcerer:
                    SaveThrows.Add(EnumAbilitiesDnd5E.Constitution);
                    SaveThrows.Add(EnumAbilitiesDnd5E.Charisma);
                    break;
            }
        }

        public override bool CheckSaveThrow(EnumAbilitiesDnd5E saveTrow)
        {
            return SaveThrows.Contains(saveTrow);
        }
    }
}