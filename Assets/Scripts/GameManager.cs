using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Panels")]
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    private bool isPaused = false;

    private void Awake()
    {
        // Singleton pattern (optional, but helpful)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep between scenes if needed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShowMainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else if (SceneManager.GetActiveScene().buildIndex != 0) // Not on Main Menu
            {
                PauseGame();
            }
        }
    }

    // Main Menu controls
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); 
        mainMenu?.SetActive(false);
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMainMenu()
    {
        mainMenu?.SetActive(true);
        pauseMenu?.SetActive(false);
        settingsMenu?.SetActive(false);
        Time.timeScale = 0f; // Pause on main menu
    }

    // Pause Menu controls
    public void PauseGame()
    {
        pauseMenu?.SetActive(true);
        settingsMenu?.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu?.SetActive(false);
        settingsMenu?.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Settings Menu controls
    public void OpenSettings()
    {
        settingsMenu?.SetActive(true);
        mainMenu?.SetActive(false);
        pauseMenu?.SetActive(false);
    }

    public void CloseSettings()
    {
        // Go back to where we came from
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ShowMainMenu();
        }
        else if (isPaused)
        {
            PauseGame();
        }
    }
}