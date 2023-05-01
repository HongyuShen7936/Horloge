using System;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    private float second = 0.0f, minute = 0.0f, hour = 0.0f;
    public Transform minuteHandOrigin, hourHandOrigin;

    public Transform minuteHandSocket, hourHandSocket;

    private DateTime dateTime;

    private float minuteDegree = 0.0f, hourDegree = 0.0f;

    private float backupTime = 0.0f;

    void Start()
    {
        minuteDegree = 360.0f / 60.0f;
        hourDegree = 360.0f / 12.0f;

        backupTime = Time.realtimeSinceStartup;

        UpdateTime();

        new UnityEvent().AddListener(PlaySound);

        SetRandomAppearance();
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

    void PlaySound()
    {
        this.GetComponent<AudioSource>().Play();
    }

    void SetRandomAppearance()
    {
        // Random head
        var randomNumber = UnityEngine.Random.Range(0.0f, 30.0f);

        Transform head1, head2;

        if (randomNumber < 10.0f)
        {
            head1 = GameObject.Instantiate(Resources.Load("CubeHead") as GameObject).transform;
            head2 = GameObject.Instantiate(Resources.Load("CubeHead") as GameObject).transform;
        }
        else if (randomNumber > 10.0f & randomNumber < 20.0f)
        {
            head1 = GameObject.Instantiate(Resources.Load("CylinderHead") as GameObject).transform;
            head2 = GameObject.Instantiate(Resources.Load("CylinderHead") as GameObject).transform;
        }
        else
        {
            head1 = GameObject.Instantiate(Resources.Load("TriangleHead") as GameObject).transform;
            head2 = GameObject.Instantiate(Resources.Load("TriangleHead") as GameObject).transform;
        }

        head1.SetParent(minuteHandSocket);
        head1.localPosition = Vector3.zero;

        head2.SetParent(hourHandSocket);
        head2.localPosition = Vector3.zero;

        // Random color
        randomNumber = UnityEngine.Random.Range(0.0f, 30.0f);

        if (randomNumber < 10.0f)
        {
            head1.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            head2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        else if (randomNumber > 10.0f & randomNumber < 20.0f)
        {
            head1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            head2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else
        {
            head1.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            head2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
}