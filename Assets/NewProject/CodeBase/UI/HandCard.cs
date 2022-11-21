using NewProject.CodeBase.Players;
using UnityEngine;
using UnityEngine.UI;

namespace NewProject.CodeBase.UI
{
    public class HandCard : MonoBehaviour
    {
        [Header("Sprite")] public Image image;

        [Header("Front & Back")] public Image cardfront;
        public Image cardback;

        [Header("Properties")] public Text cardName;
        public Text cost;
        public Text strength;
        public Text health;
        public Text description;
        public Text creatureType;

        [Header("Card Drag & Hover")] public HandCardDragHover cardDragHover;

        [Header("Outline")] public Image cardOutline;
        public Color readyColor;
        [HideInInspector] public int handIndex;
        [HideInInspector] public PlayerType playerType;
    }
}