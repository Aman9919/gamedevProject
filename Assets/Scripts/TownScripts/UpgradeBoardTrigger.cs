using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeBoardTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer upgradeBoard;
    public PlayerESI stats;
    public Button upgrade;
    public Button BBunlock;
    public TextMeshProUGUI textStats;
    public TextMeshProUGUI spareParts;
    void Start()
    {
        upgradeBoard.gameObject.SetActive(false);
        stats=GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
        upgrade.interactable=false;
        BBunlock.interactable=false;
    }
    public void OnTriggerEnter2D(Collider2D other){
            if(stats.spareParts > 0)
                upgrade.interactable=true;
            if(stats.spareParts >= 3 && stats.unlockedBB != 1)
                BBunlock.interactable=true;
            spareParts.text="Spare Parts Left: " +stats.spareParts;
            textStats.text="";
            if(stats.Weapons[stats.equippedWeaponNumber].modifierCount!=0){
                textStats.color= new Color(255,255,255);
                textStats.text="Current Stats:\n";
                int i =0;
                for(i = 0; i < stats.Weapons[stats.equippedWeaponNumber].modifierCount; i++){
                    textStats.text+= stats.Weapons[stats.equippedWeaponNumber].Modifiers[i] + "\n";
                }
            }
            upgradeBoard.gameObject.SetActive(true);

    }
    public void OnTriggerExit2D(Collider2D other){
            upgrade.interactable=false;
            upgradeBoard.gameObject.SetActive(false);
    }
    
}
