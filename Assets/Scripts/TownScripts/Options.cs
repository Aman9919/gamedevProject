using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Options : MonoBehaviour
{
    public Slider volumeMasterSlider;
    public AudioMixer mixerMaster;
    public Slider volumeMusicSlider;
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
