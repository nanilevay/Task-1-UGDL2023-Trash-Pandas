using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalSpikes : MonoBehaviour
{
    [SerializeField]  private float MoveSpeed = 3f;
    [SerializeField] private float waitTimeUp;
    [SerializeField] private float waitTimeDown;
    [SerializeField] private bool cycle;

    public GameObject waypointsUp;
    public GameObject waypointsDown;

    private void Awake()
    {
        StartCoroutine(MovePauseAndReturn());
    }
    private void Update()
    {
        if(cycle)
        {
            cycle = false;
            StartCoroutine(MovePauseAndReturn());
        }
    }

    IEnumerator MovePauseAndReturn()
    {
        yield return new WaitForSeconds(waitTimeDown);
        yield return MoveTo(waypointsDown.transform);
        if(this.tag == "Hazard")
            FindObjectOfType<SoundManager>().Play("Spikes");
        yield return new WaitForSeconds(waitTimeUp);
        yield return MoveTo(waypointsUp.transform);
        if (this.tag == "Hazard")
            FindObjectOfType<SoundManager>().Play("Spikes");
        cycle = true;
    }
    IEnumerator MoveTo(Transform destination)
    {
        while (transform.position != destination.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination.position, MoveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
