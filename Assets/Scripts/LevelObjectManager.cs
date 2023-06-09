using System.Collections.Generic;
using UnityEngine;

public class LevelObjectManager : MonoBehaviour
{
    public static int timeSourceId = 0;

    public List<Clock> clockList = new List<Clock>();

    public int numberOfClocksToSpawn = 3;

    void Start()
    {
        for (int i = 0; i < numberOfClocksToSpawn; i++)
            SpawnOneClock();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnOneClock();
        }
    }

    void SpawnOneClock()
    {
        GameObject newClock = GameObject.Instantiate(Resources.Load("Clock") as GameObject);

        Clock clock = newClock.GetComponent<Clock>();

        clockList.Add(clock);

        clock.timeSourceId = timeSourceId;

        newClock.name = "Clock " + clockList.Count;

        // Spread out 10 clocks in a row
        newClock.transform.position = new Vector3(5.0f * (clockList.Count % 10), 0.0f, 5.0f * (clockList.Count / 10));
    }
}