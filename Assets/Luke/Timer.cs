using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;

    public float ElapsedTime => elapsedTime; // Public property to get elapsed time

    public string timer = "0";

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timer = $"{minutes:00}:{seconds:00}";
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(20, 80, 500, 500), "Time Survived: " + timer);
        PlayerPrefs.SetString("Time", timer);
    }
}
