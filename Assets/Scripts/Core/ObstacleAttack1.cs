using System.Collections;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float moveDistance = 2f;
    public float moveTime = 0.5f;
    public float stayTime = 1f;

    private Vector3 startLocalPos;

    void Awake()
    {
        startLocalPos = transform.localPosition;
    }

    public IEnumerator Move()
    {
        Vector3 endLocalPos =
            startLocalPos + moveDirection.normalized * moveDistance;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;
            transform.localPosition =
                Vector3.Lerp(startLocalPos, endLocalPos, t);
            yield return null;
        }

        yield return new WaitForSeconds(stayTime);

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;
            transform.localPosition =
                Vector3.Lerp(endLocalPos, startLocalPos, t);
            yield return null;
        }
    }
}
