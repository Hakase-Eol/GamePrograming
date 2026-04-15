using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;

    [Header("Sprites")]
    public Sprite idleSprite;
    public Sprite JumpSprite;
    public Sprite jumpForwardSprite;

    [Header("Jump Settings")]
    public float jumpHeight = 2f;
    public float jumpDuration = 0.5f;
    private SpriteRenderer spriteRenderer;
    private bool isJumping = false;
    private float jumpTimer = 0f;
    private Vector3 startPosition;
    private bool isMovingRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Move Script");
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && idleSprite != null)
        {
            spriteRenderer.sprite = idleSprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1f;
            isMovingRight = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1f;
        }

        moveDirection = moveDirection.normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartJump();
        }
        if (isJumping)
        {
            UpdateJump();
        }
    }

    void StartJump()
    {
        isJumping = true;
        startPosition = transform.position;
        jumpTimer = 0f;

        if (isMovingRight && jumpForwardSprite != null)
        {
            spriteRenderer.sprite = jumpForwardSprite;
        }
        else if (JumpSprite != null)
        {
            spriteRenderer.sprite = JumpSprite;
        }
    }

    void UpdateJump()
    {
        jumpTimer += Time.deltaTime;
        float progress = jumpTimer / jumpDuration;

        if (progress >= 1f)
        {
            transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
            isJumping = false;
            if (spriteRenderer != null && idleSprite != null)
            {
                spriteRenderer.sprite = idleSprite;
            }
        }
        else
        {
            float height = Mathf.Sin(progress * Mathf.PI) * jumpHeight;
            transform.position = new Vector3(transform.position.x, startPosition.y + height, transform.position.z);
        }
    }

}


