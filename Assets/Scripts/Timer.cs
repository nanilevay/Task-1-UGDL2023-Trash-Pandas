using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public bool timerActive = false;

    public float currentTime;
    public float startMinutes;

    public UnityEvent TimerRunsOut;

    // Start is called before the first frame update
    public void Start()
    {
        currentTime = startMinutes;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;

            if (currentTime <= 0)
            {
                timerActive = false;
                Start();
                StopTimer();
                TimerRunsOut.Invoke();
            }

        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);        

    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
        currentTime = startMinutes;
    }
}