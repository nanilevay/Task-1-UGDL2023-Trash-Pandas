using System;
using UnityEngine;

/// <summary>
/// Class that handles the sounds in-game
/// </summary>
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Array of audio assets to store the sounds
    /// </summary>
    public AudioAssets[] sounds;

    private void Awake()
    {
        // Creates an Audio Source for each AudioAssets
        // With each defined settings
        foreach (AudioAssets s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    // Playes the defined Audio Sound with the defined settings when called
    public void Play(string name)
    {
        AudioAssets s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    
    //Stops the Audio Source from playing when called
    public void Stop(string name)
    {
        AudioAssets s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}