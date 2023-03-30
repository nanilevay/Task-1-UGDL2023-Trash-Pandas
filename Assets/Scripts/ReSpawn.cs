using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPointObj;
    [SerializeField] private float deathCounter;
    [SerializeField] private float maxDeathCounter;

    public GameObject PlayerPrefab;

    public Timer timer;

    private Vector3 respawnPoint;

    private void Start()
    {
        deathCounter = 0;
        respawnPoint = respawnPointObj.transform.position;
        GameEventsManager.instance.onRestartLevel += OnRestartLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && !timer.timerActive)
        {
            GameEventsManager.instance.RestartLevel();

            Restart();
        }

        if (deathCounter >= maxDeathCounter)
        {
            GameEventsManager.instance.GoalReached(); //replays
            Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector" || collision.tag == "Hazard")
        {
            Instantiate(PlayerPrefab, this.transform.position, this.transform.rotation);
            this.transform.position = respawnPoint;
            deathCounter++;
            
        }
    }

    private void Restart()
    {
       
        timer.timerActive = true;
        GameEventsManager.instance.onRestartLevel += OnRestartLevel;
        this.transform.position = respawnPoint;
        deathCounter = 0;
    }

    private void OnGoalReached()
    {
        //activate 'restart' UI
    }

    private void OnRestartLevel()
    {
        //deactivate 'restart' UI
    }
}
