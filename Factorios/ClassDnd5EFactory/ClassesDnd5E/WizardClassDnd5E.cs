﻿namespace dnd_character_sheet
{
    public class WizardClassDnd5E : IClassDnd5E
    {
        private string _className;

        public WizardClassDnd5E()
        {
            _className = "wizard";
        }

        public string GetName()
        {
            return _className;
        }
    }
}
