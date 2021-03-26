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
        [SerializeField] bool isInRageMode = false;
        [SerializeField] bool isGrounded = false;
        public bool IsinRageMode { get { return isInRageMode; } private set { } }
        [SerializeField] float rageModeSpeed = 5f;
        [SerializeField] private Transform directionIndicator;
        [SerializeField] SpriteRenderer playerGFX;
        [SerializeField] Color normalModeColor;
        [SerializeField] Color rageModeColor;


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
            CheckRageMode();
            CheckIsOnGround();
        }

        void ControlPlayerInput()
        {
            if(isGrounded & !isInRageMode)
            {
                if (Input.GetMouseButton(0))
                {

                    holdingTime += Time.deltaTime;
                    if (holdingTime > longClickTimeThreshold)
                    {
                        playerState = PlayerState.Holding;
                    }
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
        }

        void NormalJump()
        {
            _rb.AddForce(Vector2.up * normalJumpForce);
        }

        void LongJump(float holdingTime_)
        {
            holdingTime_ = Mathf.Clamp(holdingTime_,0, maxHoldingTime);
            _rb.AddForce(GetJumpDir() * (longJumpMinForce + holdingTime_ * holdingTimeJumpMultiplayer));
        }

        Vector3 GetJumpDir()
        {
            return directionIndicator.position - transform.position;
        }

        public void CheckRageMode()
        {
            //Debug.Log(_rb.velocity.magnitude);
            if (_rb.velocity.magnitude > rageModeSpeed)
            {
                isInRageMode = true;
                playerGFX.color = rageModeColor;
            }
            else
            {
                isInRageMode = false;
                playerGFX.color = normalModeColor;
            }
        }

        public void CheckIsOnGround()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down,1f,LayerMask.GetMask("Ground"));
            Debug.DrawRay(transform.position,Vector3.down, Color.red);
            //Debug.Log(hit.point);
            if (hit)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            Debug.Log(isGrounded);
        }
    }
}
