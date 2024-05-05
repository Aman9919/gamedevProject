using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MainMenuHandler : MonoBehaviour
{
    [Header("Menus")]
    public Canvas mainMenu;
    public Canvas optionsMenu;
    [Header("Options")]
    public Slider volumeMasterSlider;
    public AudioMixer mixerMaster;
    public Slider volumeMusicSlider;
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
    float ConvertToDev(float value){
        return Mathf.Log10(Mathf.Max(value,0.0001f))*20;
    }
    public void setMasterVolume(){
        mixerMaster.SetFloat("MasterVolume",ConvertToDev(volumeMasterSlider.value));
    }
    public void setMusicVolume(){
        mixerMaster.SetFloat("MusicVolume",ConvertToDev(volumeMusicSlider.value));
    }
}
