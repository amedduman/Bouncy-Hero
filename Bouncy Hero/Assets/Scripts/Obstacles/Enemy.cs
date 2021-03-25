using System;
using UnityEngine;



namespace Bouncy.Obstacles
{
    public class Enemy : BadFigure
    {
        public static event Action OnLevelEnd;
        
        [SerializeField] private float deadlySpeed = 1;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var playerRb = other.gameObject.GetComponent<Rigidbody2D>();
                var playerSpeed = playerRb.velocity;
                if (playerSpeed.magnitude >deadlySpeed)
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

