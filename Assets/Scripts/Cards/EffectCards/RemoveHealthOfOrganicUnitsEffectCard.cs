using System.Collections.Generic;
using System.Linq;
using Cards.Base;
using Core;
using UnityEngine;

namespace Cards.EffectCards
{
    public class RemoveHealthOfOrganicUnitsEffectCard : EffectUnitCard
    {
        [SerializeField] private CardClass _organicClass;
        [SerializeField] private int _reduceHealthTo = 1;
        [SerializeField] private GameObject FX;

        private List<UnitCard> _classCards;
        
        public override void MakeEffect(UnitCard effectCard)
        {
            base.MakeEffect(effectCard);
           
            _classCards = Game.Enemy.InBoardCards.Where(card => card.Class == _organicClass).ToList();
            
            if (_classCards.Count > 0)
            {
                _classCards.ForEach(card => card.SetHealth(_reduceHealthTo));
                SpawnFX();
            }
        }

        private void SpawnFX() => 
            Instantiate(FX, transform.position, Quaternion.identity);
    }
}