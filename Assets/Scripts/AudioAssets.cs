using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// Class the settings of each Audio source
/// </summary>
[System.Serializable]
public class AudioAssets
{
    // Defines what is asked on the Inspector
    // To edit in each Audio Source
    public string name;

    public AudioClip clip;
    public AudioMixer mix;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
