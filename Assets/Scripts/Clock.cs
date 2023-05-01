using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private float second = 0.0f, minute = 0.0f, hour = 0.0f;
    public Transform minuteHandOrigin, hourHandOrigin;

    private DateTime dateTime;

    private float minuteDegree = 0.0f, hourDegree = 0.0f;

    private float backupTime = 0.0f;

    void Start()
    {
        minuteDegree = 360.0f / 60.0f;
        hourDegree = 360.0f / 12.0f;

        backupTime = Time.realtimeSinceStartup;

        UpdateTime();
    }

    void Update()
    {
        if (Time.realtimeSinceStartup - backupTime > 1.0f)
        {
            backupTime = Time.realtimeSinceStartup;

            UpdateTime();
        }
    }

    void UpdateTime()
    {
        dateTime = System.DateTime.Now;

        second = dateTime.Second;
        minute = dateTime.Minute;
        hour = dateTime.Hour;

        minuteHandOrigin.localRotation = Quaternion.Euler(0.0f, 0.0f, (minute + second / 60.0f) * minuteDegree);
        hourHandOrigin.localRotation = Quaternion.Euler(0.0f, 0.0f, (hour + minute / 60.0f + second / 3600.0f) * hourDegree);
    }
}