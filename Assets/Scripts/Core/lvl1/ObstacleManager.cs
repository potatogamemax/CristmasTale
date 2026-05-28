using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleMover[] obstacles;
    public int totalCount = 6;
    public float delayBetween = 0.5f;
    public float startDelay = 2f;

    public bool isFinished = false;

    void Start()
    {
        StartCoroutine(ObstacleSequence());
    }

    IEnumerator ObstacleSequence()
    {
        yield return new WaitForSeconds(startDelay);

        List<ObstacleMover> sequence = new List<ObstacleMover>();

        foreach (var obstacle in obstacles)
        {
            if (obstacle != null)
                sequence.Add(obstacle);
        }

        while (sequence.Count < totalCount)
        {
            int index = Random.Range(0, obstacles.Length);

            if (obstacles[index] != null)
                sequence.Add(obstacles[index]);
        }

        Shuffle(sequence);

        foreach (var obstacle in sequence)
        {
            yield return StartCoroutine(obstacle.Move());
            yield return new WaitForSeconds(delayBetween);
        }

        isFinished = true;
    }

    void Shuffle(List<ObstacleMover> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            var temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}