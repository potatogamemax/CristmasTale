using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasueController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonMainMenu;
    [SerializeField] private Button buttonMainMenu2;

    // 🆕 ТРЕТЬЯ КНОПКА ВЫХОД В МЕНЮ
    [SerializeField] private Button buttonMainMenu3;

    [SerializeField] private Button buttonRestart;

    void OnEnable()
    {
        if (EventBus.Instance != null)
        {
            EventBus.Instance.OnGamePaused += ShowPausePanel;
            EventBus.Instance.OnGameResumed += HidePausePanel;
        }
    }

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

        if (buttonMainMenu2 != null)
            buttonMainMenu2.onClick.AddListener(OnMainMenuClicked);

        // 🆕 3-я кнопка меню
        if (buttonMainMenu3 != null)
            buttonMainMenu3.onClick.AddListener(OnMainMenuClicked);

        if (buttonRestart != null)
            buttonRestart.onClick.AddListener(OnRestartClicked);
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
            Debug.LogWarning("GameManager instance is null. Cannot toggle pause");
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
            pauseMenu.SetActive(true);
    }

    private void HidePausePanel()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    private void OnResumeClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.Resume();
    }

    private void OnMainMenuClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GoToMenu();
    }

    private void OnRestartClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}