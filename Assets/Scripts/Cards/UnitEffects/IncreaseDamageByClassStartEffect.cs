using System.Collections.Generic;
using System.Linq;
using Cards.Base;
using Core;
using UnityEngine;

namespace Cards.UnitEffects
{
    public class IncreaseDamageByClassStartEffect : UnitStartEffect
    {
        [SerializeField] private int _intcreaseAttackValue = 1;

        private List<UnitCard> _classCards;

        public override void MakeStartEffect()
        {
            _classCards = Game.CurrentPlayer.InBoardCards
                .Where(card => card.Class == CardClass.Robot || card.Class == CardClass.Trei).ToList();

            if (_classCards.Count > 0)
                _classCards.ForEach(card => card.IncreaseAttack(_intcreaseAttackValue));
        }
    }
}