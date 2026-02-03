using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Hitbox settings")]
    public Vector2 hitBoxSize = new Vector2(0.8f, 0.8f);
    public LayerMask enemyLayer;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Движение
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        transform.position += (Vector3)(movement * speed * Time.fixedDeltaTime);

        CheckEnemyHit();
    }

    void CheckEnemyHit()
    {
        Collider2D hit = Physics2D.OverlapBox(
            transform.position, // центр бокса
            hitBoxSize,         // размер
            0f,                 // поворот
            enemyLayer          // кого ищем
        );

        if (hit != null)
        {
            Debug.Log("Player hit enemy: " + hit.name);
        }
    }

    // Для визуализации бокса в редакторе
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, hitBoxSize);
    }
}
