using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class TownButtonHandler : MonoBehaviour
{
    public PlayerESI stats;
    public Player player;
    public TextMeshProUGUI textStats;
    public TextMeshProUGUI spareParts;
    public Button upgrade;
    public Button BBunlock;
    public Button swap;
    void Start()
    {
        stats=GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
    }
    public void randomizeStats(){
        GetComponent<AudioSource>().Play();
        stats.Weapons[stats.equippedWeaponNumber].randomModifiersRare();
        textStats.color= new Color(255,255,255);
        textStats.text="Current Stats:\n";
                int i =0;
                for(i = 0; i <= stats.Weapons[stats.equippedWeaponNumber].modifierCount; i++){
                    textStats.text+= stats.Weapons[stats.equippedWeaponNumber].Modifiers[i] + "\n\n";
                }
        stats.spareParts--;
        if(stats.spareParts == 0)
            upgrade.interactable=false;
        if(stats.spareParts < 3)
            BBunlock.interactable=false;
        spareParts.text="Spare Parts Left: " +stats.spareParts;
    }
    public void unlockBB(){
        GetComponent<AudioSource>().Play();
        stats.unlockedBB = 1;
        stats.spareParts-= 3;
        BBunlock.interactable=false;
        if(stats.spareParts <= 0)
            upgrade.interactable=false;
        spareParts.text="Spare Parts Left: " +stats.spareParts;
    }
    public void SwapSwapons(){
        if(stats.equippedWeaponNumber == 1)
          {  
            stats.equippedWeaponNumber = 0;
            stats.equippedWeapon = "Crowbar";
          }
        else if(stats.unlockedBB == 1){
            stats.equippedWeaponNumber = 1;
            stats.equippedWeapon = "Blunderbuss";
        }
        player.loader.weaponSwap(stats.equippedWeapon);
        textStats.color= new Color(255,255,255);
        textStats.text="Current Stats on " + stats.equippedWeapon +":\n";
                int i =0;
                for(i = 0; i <= stats.Weapons[stats.equippedWeaponNumber].modifierCount; i++){
                    textStats.text+= stats.Weapons[stats.equippedWeaponNumber].Modifiers[i] + "\n\n";
                }
    }
    public void BountyOne(){
        stats.MonsterToFight="Enemy";
        SceneManager.LoadScene("Combat-grassland");
    }
    public void BountyTwo(){
        stats.MonsterToFight="Cycleclops";
        SceneManager.LoadScene("Combat-grassland");
    }
    public void BountyThree(){
        stats.MonsterToFight="Enemy";
        SceneManager.LoadScene("Combat-desert");
    }
    public void BountyFour(){
        stats.MonsterToFight="Nursebot";
        SceneManager.LoadScene("Combat-grassland");
    }
    public void quitGame(){
       // Debug.Log("Button works, quit to come when a game actually exists");
        Application.Quit();
    }
}
