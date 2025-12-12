using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Set IsWalking
        bool isWalking = movement.sqrMagnitude > 0.01f;
        animator.SetBool("IsWalking", isWalking);

        // Flip sprite when moving left
        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;

        // Attack trigger
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("IsAttack");

        // Hurt trigger
        if (Input.GetKeyDown(KeyCode.H))
            animator.SetTrigger("IsHurt");
    }

    void FixedUpdate()
    {
        // Move character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
