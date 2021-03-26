using System;
using UnityEngine;
using Bouncy.Player;



namespace Bouncy.Obstacles
{
    public class Enemy : BadFigure
    {
        public static event Action OnLevelEnd;
        
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var playerController = other.gameObject.GetComponent<PlayerController>();
                if (playerController.IsinRageMode)
                {
                    Destroy(gameObject);
                    OnLevelEnd?.Invoke();
                }
                else
                {
                    HandlePlayerDeath(other.gameObject);
                }
            }
        }
    }
}

