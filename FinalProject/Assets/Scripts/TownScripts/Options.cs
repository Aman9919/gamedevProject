using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
public class Options : MonoBehaviour
{
    public Slider volumeMasterSlider;
    public AudioMixer mixerMaster;
    public Slider volumeMusicSlider;
    public Slider healthMultiplierSlider;
    public Slider damageMultiplierSlider;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI multiplierTextDamage;
    public PlayerESI playerStats;
    float ConvertToDev(float value){
        return Mathf.Log10(Mathf.Max(value,0.0001f))*20;
    }
    public void setMasterVolume(){
        mixerMaster.SetFloat("MasterVolume",ConvertToDev(volumeMasterSlider.value));
    }
    public void setMusicVolume(){
        mixerMaster.SetFloat("MusicVolume",ConvertToDev(volumeMusicSlider.value));
    }
    public void setHealthMultipler(){
        playerStats.setHealth(healthMultiplierSlider.value);
        multiplierText.text="x"+healthMultiplierSlider.value.ToString("#.##");
    }
    public void setDamageMultipler(){
        playerStats.setDamage(damageMultiplierSlider.value);
        multiplierTextDamage.text="x"+damageMultiplierSlider.value.ToString("#.##");
    }
}
