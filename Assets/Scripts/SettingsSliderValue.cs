using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsSliderValue : MonoBehaviour
{
    public Slider slider;

    public TextMeshProUGUI TextToChange;

    // Update is called once per frame
    void Update()
    {
        TextToChange.text = slider.value.ToString();
    }
}