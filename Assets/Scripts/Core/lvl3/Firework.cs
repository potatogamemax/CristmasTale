using System.Collections;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public float rocketSpeed = 5f;
    public float flyTime = 2f;

    public GameObject ballPrefab;
    public int ballCount = 8;
    public float explosionForce = 5f;

    private bool exploded;

    public IEnumerator Play()
    {
        // 1. полёт
        float t = 0f;

        while (t < flyTime)
        {
            transform.position += Vector3.up * rocketSpeed * Time.deltaTime;
            t += Time.deltaTime;
            yield return null;
        }

        // 2. взрыв
        Explode();
        gameObject.SetActive(false);
        // 3. ждём немного пока эффект “живёт”
        yield return new WaitForSeconds(1f);
        
    }

    void Explode()
    {
        exploded = true;

        for (int i = 0; i < ballCount; i++)
        {
            float angle = i * 360f / ballCount;
            Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.right;

            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.SetActive(true);

            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = dir * explosionForce;
            }
        }
    }
}