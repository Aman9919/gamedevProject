using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuHandler : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas optionsMenu;
    public void play(){
       SceneManager.LoadScene("Town");
       Debug.Log("Button works, quit to come when a game actually exists");
       //screen.Transition("GameScreen");
    }
    public void quit(){
       // Debug.Log("Button works, quit to come when a game actually exists");
        Application.Quit();
    }
    public void options(){
        mainMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(true);
    }
    public void back(){
        mainMenu.gameObject.SetActive(true);
        optionsMenu.gameObject.SetActive(false);
    }
}
