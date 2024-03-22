using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSLoader : MonoBehaviour
{
    public SpriteRenderer weapon;
    public void weaponSwap(string weaponName){
        Sprite weaponToLoad = Resources.Load<Sprite>("Sprites/Character/"+weaponName);
        if(weaponToLoad == null){
            weaponToLoad = Resources.Load<Sprite>("Sprites/Character/Crowbar");
        }
        weapon.sprite = weaponToLoad;
        //Debug.Log("Called");
    }
}
