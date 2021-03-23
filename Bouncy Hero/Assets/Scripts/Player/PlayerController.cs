using UnityEngine;



namespace Bouncy.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float longClickTimeThreshold = 0.1f;
        [SerializeField] float normalJumpForce = 6;
        [SerializeField] float longJumpMinForce = 100;
        [Tooltip("this value will multiply with player holding time")]
        [SerializeField] float holdingTimeJumpMultiplayer = 100;

        public PlayerState playerState = PlayerState.Idled;
        public float  maxHoldingTime = 1;
        [HideInInspector] public float holdingTime;
        
        Rigidbody2D _rb;

        private void Awake()
        {
            playerState = playerState = PlayerState.Idled;
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            ControlPlayerInput();
        }

        void ControlPlayerInput()
        {
            if (Input.GetMouseButton(0))
            {
                playerState = PlayerState.Holding;
                holdingTime += Time.deltaTime;
            }

            if (Input.GetMouseButtonUp(0))
            {
                playerState = PlayerState.Idled;
                
                if (holdingTime > longClickTimeThreshold)
                {
                    LongJump(holdingTime);
                }
                else
                {
                    NormalJump();
                }

                holdingTime = 0;
            }
        }

        void NormalJump()
        {
            _rb.AddForce(Vector2.up * normalJumpForce);
        }

        void LongJump(float holdingTime)
        {
            holdingTime = Mathf.Clamp(holdingTime,0, maxHoldingTime);
            _rb.AddForce(Vector2.up * (longJumpMinForce + holdingTime * holdingTimeJumpMultiplayer));
        }
    }
}
