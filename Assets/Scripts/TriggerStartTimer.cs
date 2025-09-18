using UnityEngine;

public class TriggerStartTimer : MonoBehaviour
{
    public void StartTimer()
    {
        GameData.Instance.isTimerStarted = true;
    }
}
