using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void PlayGame(){
        SceneManager.LoadScene(2); //2 is "Game" Scene in queue
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ExitMainMenu(){
        SceneManager.LoadScene(1); //1 is "Menu" Scene in queue
    }
}
