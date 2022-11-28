﻿using Cards.Base;
using Core;
using Field;
using UnityEngine;

namespace Cards.EffectCards
{
    public class AddHealthEffectCard : EffectUnitCard
    {
        [SerializeField] private int _addHealthCount = 3;
        [SerializeField] private GameObject FX;

        public override void MakeEffect(UnitCard card)
        {
            if (card.Owner == Owner && !Owner.InHandCards.Contains(card))
            {
                base.MakeEffect(card);
                card.TakeDamage(-_addHealthCount);
                SpawnFX();
                FindObjectOfType<GameBoardGenerator>().Generate(Game.CurrentPlayer, Game.Enemy);
            }
        }

        private void SpawnFX() =>
            Instantiate(FX, transform.position, Quaternion.identity);
    }
}