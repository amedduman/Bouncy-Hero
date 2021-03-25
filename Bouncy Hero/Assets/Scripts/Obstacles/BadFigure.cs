using System;
using UnityEngine;



namespace Bouncy.Obstacles
{
    public class BadFigure : MonoBehaviour
    {
        public static event Action OnLevelFailed;

        protected void HandlePlayerDeath(GameObject player)
        {
            Destroy(player.gameObject);
            OnLevelFailed?.Invoke();
        }
    }
}

