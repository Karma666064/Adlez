using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (GameData.Instance.isTimerStarted)
        {
            GameData.Instance.elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(GameData.Instance.elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(GameData.Instance.elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((GameData.Instance.elapsedTime * 1000f) % 1000);

            timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:000}";
        }
    }
}
