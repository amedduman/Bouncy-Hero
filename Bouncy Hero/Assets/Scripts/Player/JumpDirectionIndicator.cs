using System;
using UnityEngine;



namespace Bouncy.Player
{
    public class JumpDirectionIndicator : MonoBehaviour
    {
        [SerializeField] PlayerController pc;
        [SerializeField] SpriteRenderer indicator;

        Transform _tr;

        private void Awake()
        {
            _tr = GetComponent<Transform>();
        }

        void Update()
        {
            switch (pc.playerState)
            {
                case PlayerState.Holding:
                    GrowIndicator();
                    break;
                case PlayerState.Idled:
                    DisappearIndicator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void DisappearIndicator()
        {
            indicator.enabled = false;
            _tr.localScale = Vector3.zero;
        }

        void GrowIndicator()
        {
            var clampedHoldingTime = Mathf.Clamp(pc.holdingTime, 0, pc.maxHoldingTime);
            var scaleFactor = clampedHoldingTime / pc.maxHoldingTime;
            _tr.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            indicator.enabled = true;
        }
    }

}
