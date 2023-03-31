using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkOnCollission : MonoBehaviour
{
    public GameObject Platform;

    public float TimeAfterHit = 0.2f;
    public float TimeToShowPlatform = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(HidePlatform());
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(ShowPlatform());
        }
    }

    IEnumerator ShowPlatform()
    {
        yield return new WaitForSeconds(TimeAfterHit);
        Platform.SetActive(true);
    }

    IEnumerator HidePlatform()
    {
        FindObjectOfType<SoundManager>().Play("PlatformPoof");
        yield return new WaitForSeconds(TimeToShowPlatform);
        Platform.SetActive(false);
    }


}
