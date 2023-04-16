using UnityEngine;
using UnityEngine.UI;

public class PmTest : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private Text positionText;

    private float dirX = 0f;
    private int jumpCount = 0;

    private enum MovementState { idle, running, jumping, falling }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        UpdateAnimationState();
        UpdatePositionUI();
    }

    private void HandleInput()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }

        if (IsGrounded())
        {
            jumpCount = 0;
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX != 0f)
        {
            state = MovementState.running;
            sprite.flipX = dirX < 0f;
        }
        else
        {
            state = MovementState.idle;
        }

        if (Mathf.Abs(rb.velocity.y) > 0.1f)
        {
            state = rb.velocity.y > 0f ? MovementState.jumping : MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, jumpableGround);
        return hit.collider != null;
    }

    private void UpdatePositionUI()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        positionText.text = "Position: (" + x.ToString("F2") + ", " + y.ToString("F2") + ")";
    }
}