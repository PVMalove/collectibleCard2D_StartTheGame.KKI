using System.Collections.Generic;
using System.Linq;
using Cards.Base;
using Core;
using UnityEngine;

namespace Cards.UnitEffects
{
    //Кража карты по классу Начальный эффект
    public class StealCardByClassStartEffect : UnitStartEffect
    {
        [SerializeField] private CardClass _class;
        
        //
        private List<UnitCard> _classCards;
        //
        
        //Создать эффект старта
        public override void MakeStartEffect()
        {
            _classCards = Game.Enemy.InBoardCards.Where(card => card.Class == _class).ToList();

            
            if (_classCards.Count > 0)
            {
                _classCards.ForEach(card => card.cardClicked.AddListener(StealCard));
               
                Debug.Log("Кликните по юниту над которым нужно установить контроль");

                //Game.CurrentPlayer.BlockControl();
            }
        }
        
        //Украсть карту
        private void StealCard(UnitCard unitCard) 
        {
            Game.Enemy.RemoveCardFromBoard(unitCard);
            Game.CurrentPlayer.AddCardToBoard(unitCard);
            
            Debug.LogWarning("Забрал юнита == StealCard");
            
            Game.CurrentPlayer.GoToPlayCardPhase();
            _classCards.ForEach(card => card.cardClicked.RemoveListener(StealCard));
        }
    }
}