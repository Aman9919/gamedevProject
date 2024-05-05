using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerESI : MonoBehaviour
{
    public static PlayerESI singleton;
    [Header("Stats")]
    [SerializeField] public int health = 25;
    [SerializeField] public string PlayerName = "Andrew";
    [SerializeField] public string equippedWeapon="Crowbar";
    [SerializeField] public int spareParts = 0;
    [SerializeField] public int damage = 5;

    [SerializeField] public WeaponStats []Weapons = new WeaponStats[2];
    public int equippedWeaponNumber = 0;
    public int Blunderbussdmg = 7;
    public int Crowbardmg = 5;
    public int unlockedBB = 0;
    public string MonsterToFight ="Enemy";
    public void Awake(){
        if(singleton==null)
            singleton=this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(gameObject);
    }
        public int setWeaponDmg(){
        switch(equippedWeaponNumber){
            case 1:
                return Blunderbussdmg;
            default:
                return Crowbardmg;
        }
        //Debug.Log(damage);
    }
    public void setHealth(float multiplier){
        health = (int)(multiplier*25);
    }
    public void setDamage(float multiplier){
        Crowbardmg =(int)(multiplier*5);
        Blunderbussdmg = (int)(multiplier*7);
    }
}
