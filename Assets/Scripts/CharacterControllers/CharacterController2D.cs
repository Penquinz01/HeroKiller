using UnityEngine;


namespace CharacterControllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class CharacterController2D : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private CapsuleCollider2D _col;
        
        #region Movement
        [Header("Movement")]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _accelarationTime = 0.2f;
        [SerializeField] private float _decelerationTime = 0.02f;
        #endregion
        #region Jump
        [Header("Ground Check")]
        [SerializeField] private float _groundCheckDistance = 0.2f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _jumpHeight = 2f;
        [SerializeField] private float _jumpRange = 2f;
        [SerializeField] private float _gravity = 9.8f;
        #endregion
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<CapsuleCollider2D>();
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            Physics2D.gravity = new Vector2(0, -_gravity);
        }

        public void Move(Vector2 movement)
        {
            Vector2 velocity = _rb.linearVelocity;
            float acceleration = movement.x == 0 ? HelperMath.CalculateAcceleration(velocity,movement,0,_decelerationTime) :HelperMath.CalculateAcceleration(velocity, movement, _moveSpeed, _accelarationTime);
            _rb.AddForce(movement * acceleration);
        }

        public void Jump()
        {
            if (!GroundCheck())
            {
                return;
            }
            Debug.Log("Jump");
            Vector2 jumpForce = HelperMath.CalculateJumpForce(_jumpHeight, _jumpRange, _gravity);
            _rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }

        private bool GroundCheck()
        {
            return Physics2D.CircleCast(transform.position, _col.bounds.size.x / 2, Vector2.down, _groundCheckDistance, _groundLayer);
        }
    }
}
