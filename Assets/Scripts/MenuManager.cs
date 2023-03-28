using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool Paused = false;
    public GameObject PauseMenu;
    public GameObject Panel;
    public bool MainMenu = false;



    private void Start()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))  && !MainMenu)
        {
            if(Paused)
            {
                Continue();
            }

            else
            {
                Pause();
            }
        }
    }

    //Loads the scene in position num 1 on Build Settings
    public void Play(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }


    //Loads the scene in position num 0 on Build Settings
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    //Quits the game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has QUIT the game.");
    }

    //Pause the game
    public void Pause()
    {
        //opens Pause panel
        PauseMenu.SetActive(true);
        //Freezes time
        Time.timeScale = 0f;
        Paused = true;
       
    }
    public void Continue()
    {
        //closes Pause panel
        PauseMenu.SetActive(false);
        //Un-freezes time
        Time.timeScale = 1f;
        Paused = false;
    }

    //Reloads current scene
    public void RestartScene()
    {
        //Reloads Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //has some problems? Idk why yu can't do anything when you reset =_=
        Debug.Log("Scene loaded."); 
    }

    public void ShowPanel()
    {
        //opens Pause panel
        Panel.SetActive(true);
     

    }

    public void HidePanel()
    {
        //opens Pause panel
        Panel.SetActive(false);
   

    }

    public void EndGame()
    {
        //Reloads Scene
        SceneManager.LoadScene(2);  
    }
}
