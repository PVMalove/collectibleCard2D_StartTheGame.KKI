using UnityEngine;

namespace NewProject.CodeBase.Players

{
    public enum PlayerType { PLAYER, ENEMY };
    public class Player
    {
        public static GameManager gameManager;
        
        [Header("Deck")]
        public Deck deck;
        public Sprite cardback;
        public int tauntCount = 0; 
        
        
    }
}