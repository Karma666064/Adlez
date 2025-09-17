using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public GameObject pannel;
    public Timer timerScript;

    private void Start()
    {
        timerScript = Timer.Instance;
    }

    public void SceneReloader(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            Time.timeScale = 0f;

            pannel.SetActive(true);

            StartCoroutine(Blinker(timerScript.timerText));
        }
    }

    public IEnumerator Blinker(TextMeshProUGUI obj)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            obj.enabled = false;
            yield return new WaitForSecondsRealtime(0.6f);
            obj.enabled = true;
        }
    }
}
