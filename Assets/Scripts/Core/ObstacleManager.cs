using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleMover[] obstacles;
    public int totalCount = 6;        // всего запусков
    public float delayBetween = 0.5f;

    void Start()
    {
        StartCoroutine(ObstacleSequence());
    }

    IEnumerator ObstacleSequence()
    {
        // список для порядка запуска
        List<ObstacleMover> sequence = new List<ObstacleMover>();

        // 1️⃣ гарантируем, что каждый появится хотя бы 1 раз
        foreach (var obstacle in obstacles)
        {
            if (obstacle != null)
                sequence.Add(obstacle);
        }

        // 2️⃣ добираем случайные, пока не будет totalCount
        while (sequence.Count < totalCount)
        {
            int index = Random.Range(0, obstacles.Length);
            if (obstacles[index] != null)
                sequence.Add(obstacles[index]);
        }

        // 3️⃣ перемешиваем порядок
        Shuffle(sequence);

        // 4️⃣ запускаем по очереди
        foreach (var obstacle in sequence)
        {
            yield return StartCoroutine(obstacle.Move());
            yield return new WaitForSeconds(delayBetween);
        }
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
