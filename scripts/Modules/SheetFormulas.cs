namespace dnd_character_sheet
{
    public class SheetFormulas
    {
        public static int CalculatePassiveWisdom()
        {
            return 8 + CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom) + (CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perception) ? CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() : 0);
        }

        public static void CalculateArmorClass()
        {
            var dexModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity);
            var sheildArmorClass = 0;
            var armorClass = 0;
            ItemArmorDND5e equippedArmor;

            foreach (var item in Enum.GetNames(typeof(EnumEquipmentSlotsDND5e)))
            {
                if (Enum.TryParse<EnumEquipmentSlotsDND5e>(item, out EnumEquipmentSlotsDND5e result))
                {
                    if (CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots.ContainsKey(result))
                    {
                        if (CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots[result].ItemType == EnumItemTypesDND5e.Armor)
                        {
                            equippedArmor = (ItemArmorDND5e)CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots[result];

                            switch(equippedArmor.ArmorType)
                            {
                                case EnumArmorProficienciesDND5E.LightArmor:
                                    armorClass = equippedArmor.ArmorClass;
                                    break;
                                
                                case EnumArmorProficienciesDND5E.MediumArmor:
                                    if (dexModificator > 2)
                                    {
                                        dexModificator = 2;
                                    }
                                    armorClass = equippedArmor.ArmorClass;
                                    break;

                                case EnumArmorProficienciesDND5E.HeavyArmor:
                                    dexModificator = 0;
                                    armorClass = equippedArmor.ArmorClass;
                                    break;

                                case EnumArmorProficienciesDND5E.Shield:
                                    sheildArmorClass = equippedArmor.ArmorClass;
                                    break;
                            }
                        }
                    }
                }
            }

            if (armorClass < 10)
            {
                armorClass = 10;
            }

            CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.ArmorClass] = 
                    armorClass + dexModificator + sheildArmorClass;
        }
    }
}