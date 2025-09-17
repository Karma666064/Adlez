using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuActions : MonoBehaviour
{
    public GameObject settingPannel;

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowSettings()
    {
        settingPannel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingPannel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Le jeu s'est fermé ! (Logiquement)");
        Application.Quit();
    }
}
