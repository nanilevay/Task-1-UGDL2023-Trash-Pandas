using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    public GameObject ObjectToBlink;

    public float ActiveDuration = 0.3f;
    public float InactiveDuration = 0.1f;

    public bool visible = true;

   public void BlinkObject()
    {
        StartCoroutine(BlinkTimer());
    }


    public IEnumerator BlinkTimer()
    {
        if (ObjectToBlink.activeSelf && visible)
        {
            ObjectToBlink.SetActive(false);
            yield return new WaitForSeconds(InactiveDuration);
            visible = false;
        }

        else if (!ObjectToBlink.activeSelf && !visible)
        {
            ObjectToBlink.SetActive(true);
            yield return new WaitForSeconds(ActiveDuration);
            visible = true;
        }

        yield break;
    }
}
