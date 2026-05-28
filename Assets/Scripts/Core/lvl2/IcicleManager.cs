using System.Collections;
using UnityEngine;

public class IcicleManager : MonoBehaviour
{
    public iciclefall[] icicles;

    public bool isFinished = false;

    [SerializeField] float moveDownAmount = 0.65f;
    [SerializeField] float moveDuration = 0.3f;
    [SerializeField] float wiggleAmount = 0.2f;
    [SerializeField] float wiggleDuration = 1f;
    [SerializeField] float fallTime = 2f;

    // ЗАПУСКАЕТСЯ ТЕПЕРЬ ВРУЧНУЮ
    public IEnumerator StartPhase()
    {
        yield return StartCoroutine(MainLoop());

        isFinished = true;
    }

    IEnumerator MainLoop()
    {
        for (int round = 0; round < 5; round++)
        {
            System.Array.Sort(icicles, (a, b) =>
                a.transform.position.x.CompareTo(b.transform.position.x));

            int maxStart = icicles.Length - 3;
            int safeStart = Random.Range(0, maxStart + 1);

            for (int i = 0; i < icicles.Length; i++)
            {
                bool safe = (i >= safeStart && i < safeStart + 3);

                if (!safe)
                    icicles[i].MoveDown(moveDownAmount, moveDuration);
            }

            yield return new WaitForSeconds(moveDuration);

            for (int i = 0; i < icicles.Length; i++)
            {
                bool safe = (i >= safeStart && i < safeStart + 3);

                if (!safe)
                    icicles[i].Wiggle(wiggleAmount, wiggleDuration);
            }

            yield return new WaitForSeconds(wiggleDuration);

            for (int i = 0; i < icicles.Length; i++)
            {
                bool safe = (i >= safeStart && i < safeStart + 3);

                if (!safe)
                    icicles[i].StartFall();
            }

            yield return new WaitForSeconds(fallTime);

            foreach (var icicle in icicles)
                icicle.StopFall();

            yield return new WaitForSeconds(0.5f);
        }
    }
}