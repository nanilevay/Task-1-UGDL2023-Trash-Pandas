using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Teleporter":
                FindObjectOfType<SoundManager>().Play("Portal");
                transform.position = collision.transform.GetChild(0).position;
                break;
            default:
                break;
        }
    }


}
