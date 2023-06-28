using System.Text;

namespace dnd_character_sheet
{
    public class ThrowChecksSystem : IThrowChecksSystem
    {
        private string _rollDescription;
        
        private int _diceRollResult;
        private int  _rollModificatorOne;

        private ConsoleKeyInfo _pressedKey;
        private StringBuilder _stringBuilder;

        public ThrowChecksSystem()
        {
            _rollDescription = string.Empty;
            _stringBuilder = new StringBuilder();
        }

        public string ChooseAction()
        {
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.A:
                    return MakeAbilityCheck();

                case ConsoleKey.Q:
                    return MakeSaveThrowCheck();

                case ConsoleKey.S:
                    return MakeSkillCheck();

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput]; 
            }
        }
        
        public string MakeAbilityCheck()
        {
            _diceRollResult = RollRandom.LetsRoll.Next(1, (int)EnumDices.d20 + 1);    
            
            _pressedKey = Console.ReadKey();
            switch (_pressedKey.Key)
            {
                case ConsoleKey.D1:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityStrength];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength);
                    break;

                case ConsoleKey.D2:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityDexterity];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity);
                    break;

                case ConsoleKey.D3:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityConstitution];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution);
                    break;

                case ConsoleKey.D4:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityIntelligence];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Intelligence);
                    break;

                case ConsoleKey.D5:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityWisdom];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom);
                    break;

                case ConsoleKey.D6:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckAbilityCharisma];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Charisma);
                    break;

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }

            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append($"{_rollDescription} 1d20 + {_rollModificatorOne} : {_diceRollResult} + {_rollModificatorOne} = {_rollModificatorOne + _diceRollResult}");
            return _stringBuilder.ToString();
        }

        public string MakeSaveThrowCheck()
        {
            _diceRollResult = RollRandom.LetsRoll.Next(1, (int)EnumDices.d20 + 1);
            bool optainSaveThrow = false;
            
            _pressedKey = Console.ReadKey();    
            switch (_pressedKey.Key)
            {
                case ConsoleKey.D1:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowStrength];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength);
                    optainSaveThrow = CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Strength);
                    break;

                case ConsoleKey.D2:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowDexterity];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity);
                    optainSaveThrow = CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Dexterity);
                    break;

                case ConsoleKey.D3:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowConstitution];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Constitution);
                    optainSaveThrow = CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Constitution);
                    break;

                case ConsoleKey.D4:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowIntelligence];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Intelligence);
                    optainSaveThrow = CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Intelligence);
                    break;

                case ConsoleKey.D5:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowWisdom];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Wisdom);
                    optainSaveThrow = CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Wisdom);
                    break;

                case ConsoleKey.D6:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSaveThrowCharisma];
                    _rollModificatorOne = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Charisma);
                    optainSaveThrow = CurrentHeroSheet.HeroSheet.SheetSaveThrows.CheckSaveThrow(EnumAbilitiesDnd5E.Charisma);
                    break;

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }

            _stringBuilder.Remove(0, _stringBuilder.Length);

            if (optainSaveThrow)
            {
                _stringBuilder.Append($"{_rollDescription} 1d20 + {_rollModificatorOne} + {CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()}: {_diceRollResult} + {_rollModificatorOne} + {CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()} = {(_rollModificatorOne + _diceRollResult + CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus())}");
                return _stringBuilder.ToString();
            }
            else
            {
                _stringBuilder.Append($"{_rollDescription} 1d20 + {_rollModificatorOne}: {_diceRollResult} + {_rollModificatorOne} = {(_rollModificatorOne + _diceRollResult)}");
                return _stringBuilder.ToString();
            }
        }

        public string MakeSkillCheck()
        {
            _diceRollResult = RollRandom.LetsRoll.Next(1, (int)EnumDices.d20 + 1);
            bool skillObtained = false;
            
            _pressedKey = Console.ReadKey();    
            switch (_pressedKey.Key)
            {
                case ConsoleKey.Q:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillAthletics];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Athletics);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Athletics);
                    break;

                case ConsoleKey.W:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillAcrobatics];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Acrobatics);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Acrobatics);
                    break;  

                case ConsoleKey.E:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillSleight];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Sleight);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Sleight);
                    break;

                case ConsoleKey.R:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillStealth];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Stealth);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Stealth);
                    break;

                case ConsoleKey.T:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillArcana];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Arcana);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Arcana);
                    break;

                case ConsoleKey.Y:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillHistory];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.History);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.History);
                    break;

                case ConsoleKey.A:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillInvestigation];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Investigation);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Investigation);
                    break;

                case ConsoleKey.S:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillNature];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Nature);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Nature);
                    break;

                case ConsoleKey.D:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillReligion];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Religion);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Religion);
                    break;

                case ConsoleKey.F:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillAnimal];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Animal);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Animal);
                    break;

                case ConsoleKey.G:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillInsight];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Insight);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Insight);
                    break;

                case ConsoleKey.H:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillMedicine];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Medicine);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Medicine);
                    break;

                case ConsoleKey.Z:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillPerception];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Perception);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perception);
                    break;

                case ConsoleKey.X:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillSurival];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Surival);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Surival);
                    break;

                case ConsoleKey.C:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillDeception];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Deception);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Deception);
                    break;

                case ConsoleKey.V:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillIntimidation];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Intimidation);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Intimidation);
                    break;

                case ConsoleKey.B:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillPerfomance];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Perfomance);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Perfomance);
                    break;

                case ConsoleKey.N:
                    _rollDescription = LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CheckSkillPersuasion];
                    _rollModificatorOne = GetSkillModificator(EnumSkillsDnd5E.Persuasion);
                    skillObtained = CurrentHeroSheet.HeroSheet.SheetSkills.CheckSkill(EnumSkillsDnd5E.Persuasion);
                    break;

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }

            _stringBuilder.Remove(0, _stringBuilder.Length);
            if (skillObtained)
            {
                _stringBuilder.Append(_rollDescription + " 1d20 + " + _rollModificatorOne + " + " + CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() + " : " + _diceRollResult + " + " + _rollModificatorOne + " + " + CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus() + " = " + (_rollModificatorOne + _diceRollResult + CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus()));
            }
            else
            {
                _stringBuilder.Append(_rollDescription + " 1d20 + " + _rollModificatorOne + " : " + _diceRollResult + " + " + _rollModificatorOne + " = " + (_rollModificatorOne + _diceRollResult));
            }

            return _stringBuilder.ToString();
        }

        public int GetSkillModificator(EnumSkillsDnd5E skill)
        {
            return CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(CurrentHeroSheet.HeroSheet.SheetSkills.SkillAbilityName(skill));
        }
    }
}