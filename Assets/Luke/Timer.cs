using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to UI Text
    private float elapsedTime = 0f;
    private bool isRunning = true;

    public float ElapsedTime => elapsedTime; // Public property to get elapsed time
    public static float timeSurvived = 0f;

    void Update()
    {
        if (isRunning)
        {
            timeSurvived += Time.deltaTime;
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StopTimer()
    {
        isRunning = false; // Stop the timer
    }
}
