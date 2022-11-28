using Cards.Base;
using Core;
using Field;
using UnityEngine;

namespace Cards.UnitEffects
{
    public class AddHealthStartEffect : UnitStartEffect
    {
        [SerializeField] private int _healthValue;
        [SerializeField] private GameObject FX;

        public override void MakeStartEffect()
        {
            if (Game.CurrentPlayer.InBoardCards.Count > 0)
            {
                Game.CurrentPlayer.InBoardCards.ForEach(card => card.cardClicked.AddListener(AddHealth));
                Debug.Log("Кликните по юниту которому нужно восстановить здоровье");
            }
        }

        private void AddHealth(UnitCard card)
        {
            SpawnFX(card);

            card.TakeDamage(-_healthValue);
            FindObjectOfType<GameBoardGenerator>().Generate(Game.CurrentPlayer, Game.Enemy);
            Game.CurrentPlayer.InBoardCards.ForEach(unitCard => unitCard.cardClicked.RemoveListener(AddHealth));
        }

        private void SpawnFX(UnitCard card) =>
            Instantiate(FX, card.transform.position, Quaternion.identity);
    }
}