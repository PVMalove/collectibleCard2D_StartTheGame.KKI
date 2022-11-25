using Core;
using UnityEngine;

namespace Cards.UnitEffects
{
    public class ReductionOfForceReserveStartEffect : UnitStartEffect
    {
        [SerializeField] private int _forceValue;
        public override void MakeStartEffect()
        {
            Game.Enemy.DecreaseFarce(_forceValue);
            Game.Enemy.UpdateValues();
        }
    }
}