namespace dnd_character_sheet
{
    public class TraitsListDND5e : TraitsListBase
    {
        public TraitsListDND5e()
        {
            TraitsList = new Dictionary<string, TraitBase>();
        }

        public override void AddTrait(string name, string source, string description)
        {
            if (TraitsList.ContainsKey(name) == false)
            {
                TraitsList[name] = new TraitDND5e(name, source, description);
            }
        }
    }
}