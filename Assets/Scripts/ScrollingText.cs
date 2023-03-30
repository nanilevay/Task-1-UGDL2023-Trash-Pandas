using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{

    [Header("Text Settings")]
    [SerializeField] [TextArea] private string[] Info;
    [SerializeField] private float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI infoText;
    private int currentDisplayingText = 0;

    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }


    IEnumerator AnimateText()
    {
        for(int i = 0; i < Info[currentDisplayingText].Length + 1; i++)
        {
            infoText.text = Info[currentDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(textSpeed);
        }

        if (currentDisplayingText < Info.Length - 1)
            currentDisplayingText++;
        else
            currentDisplayingText = 0;

        yield break;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ActivateText();
        }
    }
}