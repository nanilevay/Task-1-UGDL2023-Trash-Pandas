using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPointObj;
<<<<<<< HEAD
=======
    [SerializeField] private float deathCounter;
    [SerializeField] private float maxDeathCounter;

>>>>>>> origin/Replay
    private Vector3 respawnPoint;

    private void Start()
    {
<<<<<<< HEAD
=======
        deathCounter = 0;
>>>>>>> origin/Replay
        respawnPoint = respawnPointObj.transform.position;
        GameEventsManager.instance.onGoalReached += OnGoalReached;
        GameEventsManager.instance.onRestartLevel += OnRestartLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            this.transform.position = respawnPoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        if(collision.tag == "FallDetector")
=======
        if (collision.tag == "FallDetector" || collision.tag == "Hazard")
>>>>>>> origin/Replay
        {
            this.transform.position = respawnPoint;
        }
    }
<<<<<<< HEAD
=======

    private void Restart()
    {
        GameEventsManager.instance.GoalReached(); //replays
        GameEventsManager.instance.onGoalReached += OnGoalReached;
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
>>>>>>> origin/Replay
}
