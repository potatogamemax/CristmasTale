using UnityEngine;
using UnityEngine.UI;

public class PasueController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonMainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (EventBus.Instance != null)
        {
            EventBus.Instance.OnGamePaused += ShowPausePanel;
            EventBus.Instance.OnGameResumed += HidePausePanel;
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (EventBus.Instance != null)
        {
            EventBus.Instance.OnGamePaused -= ShowPausePanel;
            EventBus.Instance.OnGameResumed -= HidePausePanel;
        }
    }

    private void Start()
    {
        if (buttonResume != null)

            buttonResume.onClick.AddListener(OnResumeClicked);


        if (buttonMainMenu != null)

            buttonMainMenu.onClick.AddListener(OnMainMenuClicked);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager instance is null . Cannot togle pause");
            return;
        }

        if (GameManager.Instance.CurrentState == GameState.Playing)
        {
            GameManager.Instance.Pause();
        }
        else if (GameManager.Instance.CurrentState == GameState.Paused)
        {
            GameManager.Instance.Resume();
        }

    }

    private void ShowPausePanel()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    private void HidePausePanel()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    private void OnResumeClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.Resume(); // вызовет EventBus, который скроет панель
    }

    private void OnMainMenuClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GoToMenu();
    }

}
