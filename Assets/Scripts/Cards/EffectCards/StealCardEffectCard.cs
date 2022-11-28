﻿using System.Collections.Generic;
using System.Linq;
using Cards.Base;
using Core;
using Field;
using UnityEngine;

namespace Cards.EffectCards
{
    public class StealCardEffectCard : EffectUnitCard
    {
        [SerializeField] private CardClass _stealCardClass;

        public override void MakeEffect(UnitCard card)
        {
            if (ThisCardCanBeSteal(card))
            {
                base.MakeEffect(card);
                StealCard(card);
            }
        }

        private void StealCard(UnitCard unitCard) 
        {
            Game.Enemy.RemoveCardFromBoard(unitCard);
            Game.CurrentPlayer.AddCardToBoard(unitCard);
            
            FindObjectOfType<GameBoardGenerator>().Generate(Game.CurrentPlayer, Game.Enemy);
        }

        private bool ThisCardCanBeSteal(UnitCard card) => 
            card.Class == _stealCardClass && !Owner.InHandCards.Contains(card) && !Owner.InBoardCards.Contains(card);
    }
}
