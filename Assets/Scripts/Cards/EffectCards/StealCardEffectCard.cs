using Cards.Base;
using UnityEngine;

namespace Cards.EffectCards
{
    public class StealCardEffectCard : EffectUnitCard
    {
        public override void MakeEffect(UnitCard card)
        {
            Debug.LogWarning("Контроль получен");
        }
    }
}