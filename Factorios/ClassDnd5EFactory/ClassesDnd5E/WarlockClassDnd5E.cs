﻿namespace dnd_character_sheet
{
    public class WarlockClassDnd5E : ClassDnd5EBase
    {
        private string _className;

        public WarlockClassDnd5E()
        {
            _className = "warlock";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
