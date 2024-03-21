using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuHandler : MonoBehaviour
{
    //[SerializeField] private ScreenTransition screen;
    public void play(){
       SceneManager.LoadScene("Town");
       Debug.Log("Button works, quit to come when a game actually exists");
       //screen.Transition("GameScreen");
    }
    public void quit(){
       // Debug.Log("Button works, quit to come when a game actually exists");
        Application.Quit();
    }
}
