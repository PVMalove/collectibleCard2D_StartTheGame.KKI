using NewProject.CodeBase.UI;
using NewProject.CodeBase.Players;
using UnityEngine;

namespace NewProject.CodeBase
{
    public class Deck : MonoBehaviour
    {
        [Header("Player")]
        public Player player;
        public int deckSize = 30;
        public int handSize = 7;
        
        
        public bool spawnInitialCards = true;
        
        
        public void DrawCard(int amount)
        {
            PlayerHand playerHand = Player.gameManager.playerHand;
            for (int i = 0; i < amount; ++i)
            {
                int index = i;
                playerHand.AddCard(index);
            }
            spawnInitialCards = false;
        }
        
    }
}