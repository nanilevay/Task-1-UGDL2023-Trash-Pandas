using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This script allows for different game values to be read across scenes by 
/// accessing the settings present in the current scene as well as the static
/// instances from the static class GamePrefs.
/// </summary>
public class SettingsControl : MonoBehaviour
{
    // To control the unity music volume for menus
    public Slider MusicVolume;

    // Digital prototype fullscreen option for easier viewing of instructions
    public Toggle FullScreen;

    // Controls sounds of the game in the digital version
    public Toggle SoundsOnOff;

    // To find + toggle the object containing all the sound controllers on/off
    public GameObject SoundsObject;

    // Getting all the audiosources in the scene to control their volumes
    public AudioSource[] Sounds;

    public bool IsOn = true;

    /// <summary>
    /// This function allows us to get the values from either the predefined
    /// preferences or what the player chose in the main menu depending on what
    /// scene we're on.
    /// </summary>
    void Awake()
    {
       

        // Set the settings menu music volume slider to default/chosen value
        MusicVolume.value = GamePrefs.MusicVol;

      
        // Set the settings menu sounds on toggle to default/chosen value
        SoundsOnOff.isOn = GamePrefs.SoundOn;

     

        // Cycle through all the audiosources in the scene
        foreach (AudioSource Sound in Sounds)
        {
            // Set settings menu sound volume slider to default/chosen value
            Sound.volume = GamePrefs.MusicVol;
        }
    }

    /// <summary>
    /// This method is used to obtain the default / chosen values from previous
    /// scenes into the current game setup
    /// </summary>
    void Start()
    {
        LoadSettings();
    }

    /// <summary>
    /// This method is used to update the settings according to player input
    /// as the scene progresses.
    /// </summary>
    void Update()
    {
        // Constantly update settings while the player's input changes
        UpdateSettings();
    }

   
    /// <summary>
    /// This method allows us to toggle the sounds on and off according to 
    /// player input
    /// </summary>
    public void ToggleSounds()
    {
        // Check if the object containing all the sounds is active
        if (SoundsObject.activeSelf)
        {
            // Toggle off the sounds object in the scene 
            SoundsObject.SetActive(false);
        }

        // Check if the object containing all the sounds is not active
        else
        {
            // Toggle on the sound object in the scene
            SoundsObject.SetActive(true);
        }
    }

    /// <summary>
    /// This method allows us to change the volume of the game according to
    /// player input
    /// </summary>
    public void ChangeVolume()
    {
        // Cycle through all the audiosources in the scene
        foreach (AudioSource Sound in Sounds)
        {
            // Alter the volume of the audiosource based on slider value
            Sound.volume = MusicVolume.value;
        }
    }

  

    /// <summary>
    /// This method allows us to toggle on/off the fullscreen option of the
    /// digital part of the game according to player input on the menu.
    /// </summary>
    public void ToggleFullScreen()
    {
        // Check if the screen is currently in fullscreen mode
        if (Screen.fullScreen)
        {
            // Toggle off fullscreen mode
            Screen.fullScreen = false;
        }

        // Check if the screen is currently not in fullscreen mode
        else
        {
            // Toggle on fullscreen mode
            Screen.fullScreen = true;
        }
    }

    /// <summary>
    /// This method allows us to update all the settings in the GamePrefs script
    /// so we can preserve their values, it's to be called either on update
    /// as the player changes inputs or any time there's a transfer between 
    /// scenes and the new values need to be stored.
    /// </summary>
    public void UpdateSettings()
    {
       

        // Change the static music volume to the current slider value
        GamePrefs.MusicVol = MusicVolume.value;

        // Change the static sound on/off to the current toggle value
        GamePrefs.SoundOn = SoundsOnOff.isOn;



    }

    /// <summary>
    /// This method allows us to get all the settings values in the GamePrefs 
    /// script in order to update the settings screen in the current scene with
    /// the right values. it's to be called at the start or awake methods
    /// before the player changes inputs.
    /// </summary>
    public void LoadSettings()
    {
      
        // Change the volume slider value to the chosen preferences
        MusicVolume.value = GamePrefs.MusicVol;

        // Change the sound on/off toggle value to the chosen preferences
        SoundsOnOff.isOn = GamePrefs.SoundOn;

        // Go through all the audiosources in the scene
        foreach (AudioSource Sound in Sounds)
        {
            // Change the audiosource volume value to the chosen preferences
            Sound.volume = GamePrefs.MusicVol;
        }
    }
}