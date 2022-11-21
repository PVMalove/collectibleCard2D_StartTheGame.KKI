using NewProject.CodeBase.Players;
using UnityEngine;

namespace NewProject.CodeBase.UI
{
    public class PlayerHand : MonoBehaviour
    {
        public GameObject panel;
        public HandCard cardPrefab;
        public Transform handContent;
        public PlayerType playerType;
        private Player player;
        private PlayerInfo enemyInfo;
        private int cardCount = 0; // Amount of cards in hand

        void Update()
        {
            if (playerType == PlayerType.PLAYER && Input.GetKeyDown(KeyCode.C))
            {
                player.deck.DrawCard(7);
            }
        }
        
        public void AddCard(int index)
        {
            GameObject cardObj = Instantiate(cardPrefab.gameObject);
            cardObj.transform.SetParent(handContent, false);

            //CardInfo card = player.deck.hand[index];
            HandCard slot = cardObj.GetComponent<HandCard>();

            //slot.AddCard(card, index, playerType);
        }
        
    }
}