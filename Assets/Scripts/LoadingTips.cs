using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingTips : MonoBehaviour
{
    public List <string> tips;

    public TextMeshProUGUI DisplayText;

    public float t;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        int firstTip = UnityEngine.Random.Range(0, tips.Count);

        DisplayText.text = tips[firstTip];

    }

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime;

        if (t >= 3)
        {  
            anim.SetBool("switching", true);

            StartCoroutine(ToggleFalse());
            
            t = 0;          
        }     
    }

    IEnumerator ToggleFalse()
    {
        int nextTip = UnityEngine.Random.Range(0, tips.Count);
        yield return new WaitForSeconds(1);
        DisplayText.text = tips[nextTip];
        anim.SetBool("switching", false);
        anim.SetBool("back", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("back", false);
        yield break;
    }       
}