using System.Collections;
using UnityEngine;

public class BossPhaseManager : MonoBehaviour
{
    public ObstacleManager obstacleManager;
    public IcicleManager icicleManager;
    public FireworkManager fireworkManager;

    // ВСЯ миниигра
    public GameObject arrowMiniGame;

    void Start()
    {
        // Скрываем миниигру в начале
        arrowMiniGame.SetActive(false);

        StartCoroutine(MainRoutine());
    }

    IEnumerator MainRoutine()
    {
        // ===== 1 ФАЗА =====
        yield return new WaitUntil(() => obstacleManager.isFinished);

        yield return StartCoroutine(ShowMiniGame());

        // ===== 2 ФАЗА =====
        yield return StartCoroutine(icicleManager.StartPhase());

        yield return StartCoroutine(ShowMiniGame());

        // ===== 3 ФАЗА =====
        yield return StartCoroutine(fireworkManager.StartPhase());

        yield return StartCoroutine(ShowMiniGame());

        Debug.Log("Бой закончен");
    }

    IEnumerator ShowMiniGame()
    {
        arrowMiniGame.SetActive(true);

        // ЖДЁМ окончания миниигры
        yield return new WaitUntil(() => arrowMiniGame.activeSelf == false);
    }
}