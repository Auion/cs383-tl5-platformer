using UnityEngine;
using TMPro;

public class EndTimer : MonoBehaviour
{
    public string timer = "No time";
    public float screenWidth;
    public float screenHeight;

    private void Start()
    {
        timer = PlayerPrefs.GetString("Time");
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(screenWidth * 0.36f, screenHeight * 0.85f, 500, 500), "Time Survived: " + timer);
        PlayerPrefs.SetString("Time", timer);
    }
}
