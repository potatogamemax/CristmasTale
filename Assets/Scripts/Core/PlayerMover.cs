using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Hitbox settings")]
    public Vector2 hitBoxSize = new Vector2(0.8f, 0.8f);
    public LayerMask enemyLayer;

    [Header("Movement Bounds")]
    public float minX, maxX;
    public float minY, maxY;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;

        Vector3 newPosition = transform.position + (Vector3)(movement * speed * Time.fixedDeltaTime);

        // Ограничение по координатам
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;

        CheckEnemyHit();
    }

    void CheckEnemyHit()
    {
        Collider2D hit = Physics2D.OverlapBox(
            transform.position,
            hitBoxSize,
            0f,
            enemyLayer
        );

        if (hit != null)
        {
            Debug.Log("Player hit enemy: " + hit.name);
        }
    }


}