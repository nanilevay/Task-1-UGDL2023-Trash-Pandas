using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameEventsManager.instance.GoalReached();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
