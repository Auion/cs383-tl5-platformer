using UnityEngine;
using TMPro;

public class TimeSurvived : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to UI Text
    private float time = 0f;
   

    

    void Start()
    {

        time = Timer.timeSurvived;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
