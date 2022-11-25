using UnityEngine;

namespace Cards.Base
{
    public class EffectUnitCard : Card
    {
        public virtual void MakeEffect(UnitCard card)
        {
                  //Переместить карту в сброс из руки
            Owner.MoveCardToDumpFromHand(this);
            IsCanDrag = false;
            Owner.SpendForce(Price);
        }
    }
}