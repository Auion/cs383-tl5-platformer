using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    public float currentTime = 30f;
    private bool active = true;

    private void Update()
    {
        if (!active)
            return;

        currentTime -= Time.deltaTime;

        UpdateTimerUI();

        if (currentTime <= 0)
        {
            StopTimer();
        }
    }

    public void StopTimer()
    {
        active = false;
        currentTime = 0f;
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        if (timerText == null)
            return;

        TimeSpan t = TimeSpan.FromSeconds(currentTime);
        timerText.text = t.ToString(@"mm\:ss");
    }
}