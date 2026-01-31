using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void OpenGallery()
    {
        SceneManager.LoadScene("GalleryMenu");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Gioco chiuso");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
