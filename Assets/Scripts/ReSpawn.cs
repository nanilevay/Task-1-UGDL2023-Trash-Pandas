using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReSpawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPointObj;
    [SerializeField] private float deathCounter;
    [SerializeField] private float maxDeathCounter;
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject RespawnUI;


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
        if (Input.GetKeyDown("r"))
        {
            //GameEventsManager.instance.RestartLevel();

            //Restart();
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

        if (deathCounter >= maxDeathCounter)
        {
            RespawnUI.active = true;
            FindObjectOfType<SoundManager>().Play("Rewind");
            this.GetComponent<Movement>().enabled = false;
           
            GameEventsManager.instance.GoalReached(); //replays
            Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector" || collision.tag == "Hazard")
        {
            FindObjectOfType<SoundManager>().Play("Death");
            Instantiate(PlayerPrefab, this.transform.position, this.transform.rotation);
            this.transform.position = respawnPoint;
            deathCounter++;
        }
    }

    private void Restart()
    {
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

    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
