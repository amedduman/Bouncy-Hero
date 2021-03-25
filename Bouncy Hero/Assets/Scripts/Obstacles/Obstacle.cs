using UnityEngine;



namespace Bouncy.Obstacles
{
    public class Obstacle : BadFigure
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                HandlePlayerDeath(other.gameObject);
            }
        }
    }
}

