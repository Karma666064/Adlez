using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameObject pannel;
    public GameObject timmer;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        pannel.SetActive(false);
        timmer.SetActive(true);

        GameData.Instance.elapsedTime = 0;
    }
}
