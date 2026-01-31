using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // il Panel PauseMenu

    public static bool isPaused = false;

    void Update()
    {
        // Premi ESC per aprire/chiudere il menu di pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // ferma il gioco
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // riprende il gioco
        isPaused = false;
    }

    public void OpenOptions()
    {
        // Puoi aprire la scena Options oppure un pannello interno
        SceneManager.LoadScene("OptionsMenu");
        Time.timeScale = 1f; // riprende il tempo
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // riprende il tempo prima di cambiare scena
        SceneManager.LoadScene("MainMenu");
    }

}
