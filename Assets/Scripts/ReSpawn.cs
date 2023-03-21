using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPointObj;
    private Vector3 respawnPoint;

    private void Start()
    {
        respawnPoint = respawnPointObj.transform.position;
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
        if(collision.tag == "FallDetector")
        {
            this.transform.position = respawnPoint;
        }
    }
}
