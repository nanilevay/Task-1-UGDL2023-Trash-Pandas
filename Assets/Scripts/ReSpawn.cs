using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPointObj;
    //[SerializeField] private bool death;
    [SerializeField] private float deathCounter;
    [SerializeField] private float maxDeathCounter;

    private Vector3 respawnPoint;

    private void Start()
    {
        //death = false;
        deathCounter = 0;
        respawnPoint = respawnPointObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") || deathCounter >= maxDeathCounter)
        {
            Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector" || collision.tag == "Hazard")
        {
            this.transform.position = respawnPoint;
            deathCounter++;
        }
    }

    private void Restart()
    {
        this.transform.position = respawnPoint;
        deathCounter = 0;
    }
}
