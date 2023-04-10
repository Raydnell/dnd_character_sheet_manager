namespace dnd_character_sheet
{
    public class CombatAbilitiesDND5E : SheetCombatAbilities
    {
        public CombatAbilitiesDND5E()
        {
            MaximumHP = 1;
            CurrentHP = 1;
            TemporaryHP = 0;
            Speed = 1;
            ArmorClass = 10;
            Initiative = 0;
            HitDice = 1;
            TotalHitDices = 2;
            CurrentHitDices = 1;
            DeathSucces = 0;
            DeathFailure = 0;
            PassiveWisdom = 1;
        }

        public override void SetMaximumHP(int amount)
        {
            MaximumHP = amount;
        }

        public override void SetCurrentHP(int amount)
        {
            CurrentHP = amount;
        }

        public override void SetTemporaryHP(int amount)
        {
            TemporaryHP = amount;
        }

        public override void SetSpeed(int amount)
        {
            Speed = amount;
        }

        public override void SetArmorClass(int amount)
        {
            ArmorClass = amount;
        }

        public override void SetInitiative(int amount)
        {
            Initiative = amount;
        }

        public override void SetHitDice(int amount)
        {
            HitDice = amount;
        }

        public override void SetTotalHitDices(int amount)
        {
            TotalHitDices = amount;
        }

        public override void SetCurrentHitDices(int amount)
        {
            CurrentHitDices = amount;
        }

        public override void RaiseDeathSuccess()
        {
            DeathSucces++;
        }

        public override void RaiseDeathFailure()
        {
            DeathFailure++;
        }

        public override void ResetDeathSaves()
        {
            DeathFailure = 0;
            DeathSucces = 0;
        }

        public override void SetPassiveWisdom(int amount)
        {
            PassiveWisdom = amount;
        }
    }
}