using System.Text;

namespace dnd_character_sheet
{
    public class AttackHandSystem : IHandAttack
    {
        private int _diceRollResult;
        private int _proficiencyBonus;
        private int _damageFullResult;
        private int _abilityModificator;
        private int _rollModificatorTwo;
        private int _weaponModificator;
        private int _damageDiceResult;

        private bool _isCrit;
        
        private ConsoleKeyInfo _pressedKey;
        private ItemWeaponDND5e _itemWeapon;
        private StringBuilder _stringBuilder;

        public AttackHandSystem()
        {
            _stringBuilder = new StringBuilder();
        }
        
        public string ChooseAction()
        {
            _pressedKey = Console.ReadKey();    
            switch (_pressedKey.Key)
            {
                case ConsoleKey.R:
                    return RollAttack(CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots[EnumEquipmentSlotsDND5e.RightHand]);

                case ConsoleKey.L:
                    return RollAttack(CurrentHeroSheet.HeroSheet.SheetEquipmentSlots.EquipmentSlots[EnumEquipmentSlotsDND5e.LeftHand]);

                default:
                    return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.WrongInput];
            }
        }

        public string RollAttack(ItemBaseDND5e weapon)
        {
            _diceRollResult = RollRandom.LetsRoll.Next(1, (int)EnumDices.d20 + 1);
            _proficiencyBonus = CurrentHeroSheet.HeroSheet.SheetProgression.GetProficiencyBonus();
            _isCrit = false;
            _damageFullResult = 0;
            _abilityModificator = 0;
            _rollModificatorTwo = 0;
            _weaponModificator = 0;
            _stringBuilder.Remove(0, _stringBuilder.Length);
            
            if (_diceRollResult == 1)
            {
                return LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CriticalFailure];
            }
            else
            {
                if (_diceRollResult == 20)
                {
                    _isCrit = true;
                    _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.CriticalSuccess]} ! ");
                }

                _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumActionsWithSheet.AttackWith]} {weapon.Name}! ");

                if (weapon.ItemType == EnumItemTypesDND5e.Weapon)
                {
                    _itemWeapon = (ItemWeaponDND5e)weapon;
                    _weaponModificator = _itemWeapon.DamageModificator;
                    //Проверка фехтовальное или нет
                    if (_itemWeapon.WeaponProperty.Contains(EnumWeaponPropertiesDND5e.Finesse))
                    {
                        _abilityModificator = 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength) <= 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity) ? 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Dexterity) : 
                            CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength);
                    }
                    
                    //Проверка владения
                    if (
                        CurrentHeroSheet.HeroSheet.SheetProficiencies.CheckProficiency(_itemWeapon.WeaponProficiencyConcrete) == false && 
                        CurrentHeroSheet.HeroSheet.SheetProficiencies.CheckProficiency(_itemWeapon.WeaponProficiencyGroup) == false
                    )
                    {
                        _proficiencyBonus = 0;
                        _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumAttackHandSystem.Attack]} 1d20 + {_abilityModificator} + {_weaponModificator} : {_diceRollResult} + {_abilityModificator} + {_weaponModificator} = {_diceRollResult + _abilityModificator + _weaponModificator}! ");
                    }
                    else
                    {
                        _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumAttackHandSystem.Attack]} 1d20 + {_abilityModificator} + {_proficiencyBonus} + {_weaponModificator} : {_diceRollResult} + {_abilityModificator} + {_proficiencyBonus} + {_weaponModificator} = {_diceRollResult + _abilityModificator + _proficiencyBonus + _weaponModificator}! ");
                    }

                    //Бросок через крит или нет
                    if (_isCrit == true)
                    {
                        _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumAttackHandSystem.Damage]} {_itemWeapon.DamageDiceCount * 2}d{(int)_itemWeapon.DamageDiceValue} + {_weaponModificator} + {_abilityModificator} : ");
                        
                        for (int i = 0; i < (_itemWeapon.DamageDiceCount * 2); i++)
                        {
                            _damageDiceResult = RollRandom.LetsRoll.Next(1, (int)_itemWeapon.DamageDiceValue);
                            _damageFullResult += _damageDiceResult;
                            _stringBuilder.Append($"{_damageDiceResult} + ");
                        }
                    }
                    else
                    {
                        _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumAttackHandSystem.Damage]} {_itemWeapon.DamageDiceCount}d{(int)_itemWeapon.DamageDiceValue} + {_weaponModificator} + {_abilityModificator} : ");

                        for (int i = 0; i < _itemWeapon.DamageDiceCount; i++)
                        {
                            _damageDiceResult = RollRandom.LetsRoll.Next(1, (int)_itemWeapon.DamageDiceValue);
                            _damageFullResult += _damageDiceResult;
                            _stringBuilder.Append($"{_damageDiceResult} + ");
                        }
                    }
                    
                    _stringBuilder.Append($"{_weaponModificator} + {_abilityModificator} = {_damageFullResult + _weaponModificator + _abilityModificator}!");
                }
                else
                {
                    _abilityModificator = CurrentHeroSheet.HeroSheet.SheetAbilities.GetAbilityModificator(EnumAbilitiesDnd5E.Strength);

                    _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumAttackHandSystem.Attack]} 1d20 + {_abilityModificator} : {_diceRollResult} + {_abilityModificator} = {_diceRollResult + _abilityModificator}! ");

                    if (_isCrit == true)
                    {
                        _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumAttackHandSystem.Damage]} 2d4 + {_abilityModificator} : ");
                        
                        for (int i = 0; i < 2; i++)
                        {
                            _damageDiceResult = RollRandom.LetsRoll.Next(1, (int)EnumDices.d4 + 1);
                            _damageFullResult += _damageDiceResult;
                            _stringBuilder.Append($"{_damageDiceResult} + ");
                        }
                    }
                    else
                    {
                        _stringBuilder.Append($"{LocalizationsStash.SelectedLocalization[EnumAttackHandSystem.Damage]} 1d4 + {_abilityModificator} : ");
                        _damageFullResult += RollRandom.LetsRoll.Next(1, (int)EnumDices.d4 + 1);
                        _stringBuilder.Append($"{_damageFullResult} + ");
                    }

                    _stringBuilder.Append($"{_abilityModificator} = {_damageFullResult + _abilityModificator}!");
                }
            }

            return _stringBuilder.ToString();
        }   
    }
}