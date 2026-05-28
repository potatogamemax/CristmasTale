//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LevelManager : MonoBehaviour
//{
//    public ObstacleManager obstacleManager;
//    public IcicleManager icicleManager;
//    public FireworkManager fireworkManager;

//    bool isRunning = false;

//    void Start()
//    {
//        StartCoroutine(RunLevelsRandom());
//    }

//    IEnumerator RunLevelsRandom()
//    {
//        if (isRunning) yield break;
//        isRunning = true;

//        List<IEnumerator> levels = new List<IEnumerator>();

//        if (obstacleManager != null)
//            levels.Add(obstacleManager.RunLevel());

//        if (icicleManager != null)
//            levels.Add(icicleManager.RunLevel());

//        if (fireworkManager != null)
//            levels.Add(fireworkManager.RunLevel());

//        Shuffle(levels);

//        foreach (var level in levels)
//        {
//            yield return StartCoroutine(level);
//        }

//        isRunning = false;

//        Debug.Log("Все уровни завершены");
//    }

//    void Shuffle(List<IEnumerator> list)
//    {
//        for (int i = 0; i < list.Count; i++)
//        {
//            int r = Random.Range(i, list.Count);
//            (list[i], list[r]) = (list[r], list[i]);
//        }
//    }
//}