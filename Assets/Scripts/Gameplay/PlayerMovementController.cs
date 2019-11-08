using Platformer.GameSystem;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;
        [SerializeField]
        private float jumpForce = 1f;
        [SerializeField]
        private bool invert;
        private InputData inputData;
        private Rigidbody2D rb2d;
        private Vector3 direction;
        private bool jump;
        private float jumpTime = 0.1f;
        private float actualJumpTime;
        private Bounds bounds;
        private float lastYPos;
        private bool isFalling;
        private bool isJumping;

        private void Start()
        {
            inputData = GameContext.Instance.InputData;
            rb2d = GetComponent<Rigidbody2D>();
            bounds = GetComponent<SpriteRenderer>().bounds;
            lastYPos = transform.position.y;
        }

        private void Update()
        {
            direction = Vector3.zero;            
            if (inputData.leftKeyPressed)
            {
                direction += Vector3.left * speed;                
            }
            if (inputData.rightKeyPressed)
            {
                direction += Vector3.right * speed;
            }
            if (inputData.upKeyDown && IsGrounded())
            {
                jump = true;
            }
            if (inputData.upKeyUp)
            {
                jump = false;
                actualJumpTime = 0f;
            }
            direction = invert ? -direction : direction;
        }

        private void FixedUpdate()
        {
            rb2d.velocity = new Vector3(direction.x, rb2d.velocity.y, direction.z);
            if (jump && actualJumpTime < jumpTime)
            {
                rb2d.AddForce(Vector3.up * jumpForce * 100f);
            }
            if (jump)
            {
                actualJumpTime += Time.fixedDeltaTime;
                if (actualJumpTime > jumpTime)
                {
                    jump = false;
                }
            }
        }

        public Vector3 GetDirection()
        {
            return direction;
        }

        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - (bounds.extents.y + 0.01f), 0f), Vector3.down, 0.01f);            
            if (hit.collider != null && hit.collider.CompareTag(GameTag.GROUND))
            {
                return true;
            }
            return false;
        }
    }
}