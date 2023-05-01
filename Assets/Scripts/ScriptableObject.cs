using System;
using UnityEngine;

public class ScriptableObject : MonoBehaviour
{
    public float staticTimeSourceSecond = 0.0f, staticTimeSourceMinute = 0.0f, staticTimeSourceHour = 0.0f;

    public static float staticSecond = 0.0f, staticMinute = 0.0f, staticHour = 0.0f;

    void Update()
    {
        staticSecond = staticTimeSourceSecond;
        staticMinute = staticTimeSourceMinute;
        staticHour = staticTimeSourceHour;
    }
}

public abstract class TimeSource
{
    public virtual float GetSecond()
    {
        return 0.0f;
    }

    public virtual float GetMinute()
    {
        return 0.0f;
    }

    public virtual float GetHour()
    {
        return 0.0f;
    }
}

public class ComputerTimeSource : TimeSource
{
    private DateTime dateTime;

    public override float GetSecond()
    {
        dateTime = System.DateTime.Now;

        return dateTime.Second;
    }

    public override float GetMinute()
    {
        dateTime = System.DateTime.Now;

        return dateTime.Minute;
    }

    public override float GetHour()
    {
        dateTime = System.DateTime.Now;

        return dateTime.Hour;
    }
}

public class StaticTimeSource : TimeSource
{
    public override float GetSecond()
    {
        return ScriptableObject.staticSecond;
    }

    public override float GetMinute()
    {
        return ScriptableObject.staticMinute;
    }

    public override float GetHour()
    {
        return ScriptableObject.staticHour;
    }
}

public class ElapsedTimeSource : TimeSource
{
    public override float GetSecond()
    {
        return Time.realtimeSinceStartup % 60.0f;
    }

    public override float GetMinute()
    {
        return (Time.realtimeSinceStartup % 60.0f) / 60.0f;
    }

    public override float GetHour()
    {
        return Time.realtimeSinceStartup / 3600.0f;
    }
}