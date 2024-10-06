using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject gblight;
    [SerializeField] TextMeshProUGUI timerText;

    float timeLight = 15;

    private void Update()
    {
        
        if (timeLight <= 0)
        {
            timeLight = 15;
            gblight.SetActive(false);
            gameObject.SetActive(false);
        }
        timeLight -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLight / 60);
        int seconds = Mathf.FloorToInt(timeLight % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
