using System;
using UnityEngine;



namespace Bouncy.Player
{
    public class JumpDirectionIndicator : MonoBehaviour
    {
        [SerializeField] PlayerController pc;
        [SerializeField] SpriteRenderer indicator;

        Transform _tr;
        private Camera _cam;

        private void Awake()
        {
            _tr = GetComponent<Transform>();
            _cam = Camera.main;
        }

        void Update()
        {
            switch (pc.playerState)
            {
                case PlayerState.Holding:
                    ShowIndicator();
                    break;
                case PlayerState.Idled:
                    HideIndicator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void ShowIndicator()
        {
            GrowIndicator();
            RotateIndicator();
        }

        private void RotateIndicator()
        {
            var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            var dir = mousePos - _tr.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            _tr.rotation = Quaternion.Euler(0, 0, angle);
        }

        void HideIndicator()
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
