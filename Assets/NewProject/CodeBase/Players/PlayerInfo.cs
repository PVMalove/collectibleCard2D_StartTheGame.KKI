using System;
using UnityEngine;

namespace NewProject.CodeBase.Players
{
    [Serializable]
    public struct PlayerInfo
    {
        public GameObject player;

        public PlayerInfo(GameObject player)
        {
            this.player = player;
        }

        public Player Data
        {
            get
            {
                // Return ScriptableItem from our cached list, based on the card's uniqueID.
                return player.GetComponentInChildren<Player>();
            }
        }
    }
}