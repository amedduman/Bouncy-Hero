using System;
using UnityEngine;

namespace Bouncy.Player
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] PhysicsMaterial2D _boucyMat;
        [SerializeField] PhysicsMaterial2D _notBoucyMat;
        [SerializeField] int maxJumpCount = 5;

        

        Rigidbody2D _rb;
        PlayerController _pc;
        bool _isCountingJumps;
        int _jumpCount;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _pc = GetComponent<PlayerController>();
            _rb.sharedMaterial = _notBoucyMat;
        }

        private void Update()
        {
            if (_pc.playerState == PlayerState.Holding)
            {
                StartLongJump();
            }
        }

        private void StartLongJump()
        {
            // start long jump
            _rb.sharedMaterial = _boucyMat;
            _isCountingJumps = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_isCountingJumps) return;
            _jumpCount++;
            if (_jumpCount > maxJumpCount)
            {
                _rb.sharedMaterial = _notBoucyMat;
                // finish long jump
            }
        }
    }
}