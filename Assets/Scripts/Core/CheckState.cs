using UnityEngine;

public class CheckState : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    private float moveX;
    private float moveY;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        float speed = new Vector2(moveX, moveY).magnitude;
        anim.SetFloat("Speed", speed);

        if (moveX > 0)
            sr.flipX = false; // вправо
        else if (moveX < 0)
            sr.flipX = true;  // влево
    }
}
