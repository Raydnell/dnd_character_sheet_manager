namespace dnd_character_sheet
{
    public class ProficienciesDND5E : SheetProficiencies
    {
        public ProficienciesDND5E()
        {
            Proficiencies = new Dictionary<string, bool>()
            {
                ["AlchemistsSupplies"] = false,
                ["BrewersSupplies"] = false,
                ["CalligraphersSupplies"] = false,
                ["CarpentersTools"] = false,
                ["CartographersTools"] = false,
                ["CobblersTools"] = false,
                ["CooksUtensils"] = false,
                ["GlassblowersTools"] = false,
                ["JewelersTools"] = false,
                ["LeatherworkersTools"] = false,
                ["MasonsTools"] = false,
                ["PaintersSupplies"] = false,
                ["PottersTools"] = false,
                ["SmithsTools"] = false,
                ["TinkersTools"] = false,
                ["WeaversTools"] = false,
                ["WoodcarversTools"] = false,
                ["DiceSet"] = false,
                ["DragonchessSet"] = false,
                ["PlayingCardSet"] = false,
                ["ThreeDragonAnteSet"] = false,
                ["Bagpipes"] = false,
                ["Drum"] = false,
                ["Dulcimer"] = false,
                ["Flute"] = false,
                ["Lute"] = false,
                ["Lyre"] = false,
                ["Horn"] = false,
                ["PanFlute"] = false,
                ["Shawm"] = false,
                ["Viol"] = false,
                ["NavigatorsTools"] = false,
                ["PoisonersKit"] = false,
                ["ThievesTools"] = false,
                ["DisguiseKit"] = false,
                ["ForgeryKit"] = false,
                ["Herbalism"] = false,
                ["Club"] = false,
                ["Dagger"] = false,
                ["Greatclub"] = false,
                ["Handaxe"] = false,
                ["Javelin"] = false,
                ["LightHammer"] = false,
                ["Mace"] = false,
                ["Quarterstaff"] = false,
                ["Sickle"] = false,
                ["Spear"] = false,
                ["Crossbow"] = false,
                ["Dart"] = false,
                ["Shortbow"] = false,
                ["Sling"] = false,
                ["Battleaxe"] = false,
                ["Flail"] = false,
                ["Glaive"] = false,
                ["Greataxe"] = false,
                ["Greatsword"] = false,
                ["Halberd"] = false,
                ["Lance"] = false,
                ["Longsword"] = false,
                ["Maul"] = false,
                ["Morningstar"] = false,
                ["Pike"] = false,
                ["Rapier"] = false,
                ["Scimitar"] = false,
                ["Shortsword"] = false,
                ["Trident"] = false,
                ["WarPick"] = false,
                ["Warhammer"] = false,
                ["Whip"] = false,
                ["Blowgun"] = false,
                ["CrossbowHand"] = false,
                ["CrossbowHeavy"] = false,
                ["Longbow"] = false,
                ["Net"] = false
            };
        }

        public override void AddProficiency(string prof)
        {
            if(Proficiencies.ContainsKey(prof))
            {
                Proficiencies[prof] = true;
            }
        }
        
        public override bool CheckProficiency(string prof)
        {
            if(Proficiencies.ContainsKey(prof))
            {
                return Proficiencies[prof];
            }

            return false;
        }
    }
}