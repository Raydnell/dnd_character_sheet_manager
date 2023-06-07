using System.Text;

namespace dnd_character_sheet
{
    public class TextBuilder : ITextBuilderSystem
    {
        private StringBuilder _stringBuilder;
        private string[] _logMessages;

        public TextBuilder()
        {
            _stringBuilder = new StringBuilder();
            _logMessages = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        }

        public string BuildAbility()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetAbilities.Abilities)
            {
                if (CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(item.Key))
                {
                    _stringBuilder.Append("[[X]] " + LocalizationsStash.SelectedLocalization[item.Key] + " " + item.Value + "\n");
                }
                else
                {
                    _stringBuilder.Append("[[ ]] " + LocalizationsStash.SelectedLocalization[item.Key] + " " + item.Value + "\n");
                }
            }

            return _stringBuilder.ToString();
        }

        public string BuildHero()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            _stringBuilder.Append(
                CurrentHeroSheet.HeroSheet.Name + "\n" +
                LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetClass.Name] + "\n" +
                LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetRace.Name] + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Level] + " " + CurrentHeroSheet.HeroSheet.SheetProgression.Level + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Expirience] + " " + CurrentHeroSheet.HeroSheet.SheetProgression.Expirience + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.ProficiencyBonus] + " " + CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.PassiveWisdom] + " " + SheetFormulas.CalculatePassiveWisdom() + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Size] + " " + LocalizationsStash.SelectedLocalization[CurrentHeroSheet.HeroSheet.SheetRace.Size] + "\n" +
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HitDice] + " " + CurrentHeroSheet.HeroSheet.SheetClass.HitDice + "\n" +
                (CurrentHeroSheet.HeroSheet.Inspiration ? ("[[X]] " + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Inspiration]) : ("[[ ]] " + LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Inspiration]))
            );

            return _stringBuilder.ToString();
        }

        public string BuildPersonality()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetPersonality.PersonalityList)
            {
                _stringBuilder.Append(LocalizationsStash.SelectedLocalization[item.Key] + ": " + item.Value + "\n");
            }

            return _stringBuilder.ToString();
        }

        public string BuildSkills()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);

            foreach (var item in Enum.GetNames(typeof(EnumSkillsDnd5E)))
            {
                if (Enum.TryParse<EnumSkillsDnd5E>(item, out EnumSkillsDnd5E result))
                {
                    if (CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(result))
                    {
                        _stringBuilder.Append("[[X]] " + LocalizationsStash.SelectedLocalization[result] + "\n");
                    }
                    else
                    {
                        _stringBuilder.Append("[[ ]] " + LocalizationsStash.SelectedLocalization[result] + "\n");
                    }
                }
            }

            return _stringBuilder.ToString();
        }

        public string BuildProficiencies()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            foreach (var item in CurrentHeroSheet.HeroSheet.SheetProficiencies.Proficiencies)
            {
                _stringBuilder.Append(LocalizationsStash.SelectedLocalization[item] + "\n");
            }

            return _stringBuilder.ToString();
        }

        public string BuildCombatStats()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.HP] + ": " + 
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.CurrentHP] + @"\" + 
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.MaximumHP] + "\n"
            );

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.THP] + ": " +
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.TemporaryHP] + "\n"
            );

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.Speed] + ": " +
                CurrentHeroSheet.HeroSheet.SheetRace.Speed + "\n"
            );

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.AC] + ": " +
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.ArmorClass] + "\n"
            );

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumPrintSheetInfoTitles.DeathDices] + ": " +
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathFailure] + @"\" + 
                CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.DeathSucces] + "\n"
            );

            _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumCombatStatsDND5e.Round]}: {CurrentHeroSheet.HeroSheet.SheetCombatAbilities.CombatStats[EnumCombatStatsDND5e.Round]}");

            return _stringBuilder.ToString();
        }

        public string BuildEquipmentStats()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            if (CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots.Count == 0)
            {
                _stringBuilder.Append(LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.EmptyEquipmentSlots]);
            }
            else
            {
                foreach (var item in CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots)
                {
                    _stringBuilder.Append(LocalizationsStash.SelectedLocalization[item.Key] + ": " + item.Value.Name + "\n");
                }
            }

            return _stringBuilder.ToString();
        }

        public string BuildScreensPoints()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);

            _stringBuilder.Append(
                LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.Inventory] + "\n" + 
                LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.Spells] + "\n" + 
                LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.SheetTraits] + "\n" + 
                LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.SheetEdit]
            );

            return _stringBuilder.ToString();
        }

        public void NewMessageToLog(string message)
        {
            for (int i = 1; i <= 9; i++)
            {
                _logMessages[9 - i + 1] = _logMessages[9 - i];
            }

            _logMessages[0] = message;
        }

        public string BuildMessageBox()
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            foreach (var item in _logMessages)
            {
                _stringBuilder.Append(item + "\n");
            }

            return _stringBuilder.ToString();
        }
    }
}