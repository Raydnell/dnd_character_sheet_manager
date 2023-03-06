namespace dnd_character_sheet
{
    public abstract class CharacterSheetBase
    {
        public abstract void SetRace(string race);
        
        public abstract RaceDnd5EBase? GetRace();

        public abstract void SetClass(string sheetClass);

        public abstract ClassDnd5EBase? GetClass();

        public abstract IAbilities GetAbilities();

        public abstract ISkills GetSkills();

        public abstract ISaveThrows GetSaveThrows();

        public abstract IProgression GetProgression();

        public abstract void SetName(string name);

        public abstract string GetName();
    }
}