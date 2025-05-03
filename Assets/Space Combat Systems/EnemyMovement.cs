using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private float right;
    private float left;
    private float spriteHalfWidth;
    private int direction = 1; // 1 = right, -1 = left


    void Start()
    {
        float camHeight = Camera.main.orthographicSize * 2f;
        float camWidth = camHeight * Camera.main.aspect;

        left = Camera.main.transform.position.x - camWidth / 2;
        right = Camera.main.transform.position.x + camWidth / 2;

        // Get half-width of sprite for accurate edge detection
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteHalfWidth = sr != null ? sr.bounds.size.x / 2f : 0f;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        // Check if enemy is at or beyond camera edge
        float leftEdge = transform.position.x - spriteHalfWidth;
        float rightEdge = transform.position.x + spriteHalfWidth;

        if (rightEdge > right)
        {
            direction = -1;
        }
        else if (leftEdge < left)
        {
            direction = 1;
        }
    }

}
