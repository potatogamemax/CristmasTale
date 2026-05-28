using System.Collections;
using UnityEngine;

public class iciclefall : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isFalling = false;

    void Awake()
    {
        // фиксируем ИСХОДНУЮ позицию один раз
        startPosition = transform.position;
    }

    void Update()
    {
        if (isFalling)
        {
            transform.position += Vector3.down * 5f * Time.deltaTime;

            if (transform.position.y < -10f)
            {
                StopFall();
            }
        }
    }

    public void MoveDown(float amount, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(MoveDownRoutine(amount, duration));
    }

    IEnumerator MoveDownRoutine(float amount, float duration)
    {
        Vector3 target = startPosition + Vector3.down * amount;

        float t = 0f;
        while (t < duration)
        {
            transform.position = Vector3.Lerp(startPosition, target, t / duration);
            t += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }

    public void Wiggle(float amount, float duration)
    {
        StartCoroutine(WiggleRoutine(amount, duration));
    }

    IEnumerator WiggleRoutine(float amount, float duration)
    {
        Vector3 basePos = transform.position;

        float t = 0f;
        while (t < duration)
        {
            float x = Mathf.Sin(t * 20f) * amount;

            transform.position = new Vector3(
                basePos.x + x,
                basePos.y,
                basePos.z
            );

            t += Time.deltaTime;
            yield return null;
        }

        transform.position = basePos;
    }

    public void StartFall()
    {
        isFalling = true;
    }

    public void StopFall()
    {
        isFalling = false;
        transform.position = startPosition;
    }
}