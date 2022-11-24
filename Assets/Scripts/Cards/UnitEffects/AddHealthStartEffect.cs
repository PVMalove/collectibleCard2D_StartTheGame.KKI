using System.Collections;
using Cards.Base;
using Core;
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
            //
            SpawnFX(card);
            StartCoroutine(StopFX());
            //
            card.TakeDamage(-_healthValue);
            Game.CurrentPlayer.GoToPlayCardPhase();
            Game.CurrentPlayer.InBoardCards.ForEach(unitCard => unitCard.cardClicked.RemoveListener(AddHealth));
        }

        //
        private IEnumerator StopFX()
        {
            Debug.LogWarning("StopFX1");
            yield return new WaitForSeconds(2);
            Debug.LogWarning("StopFX2");
            ParticleSystem componentFX = FX.GetComponent<ParticleSystem>();
            componentFX.Stop(true);
        }

        private void SpawnFX(UnitCard card) =>
            Instantiate(FX, card.transform.position, Quaternion.identity);
        //
    }
}