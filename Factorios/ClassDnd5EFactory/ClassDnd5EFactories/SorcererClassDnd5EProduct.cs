﻿namespace dnd_character_sheet
{
    public class SorcererClassDnd5EProduct : ClassDnd5EFactory
    {
        public override IClassDnd5E CreateClassDnd5E()
        {
            return new SorcererClassDnd5E();
        }
    }
}
