using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeStats : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerESI stats; 
    public Transform enemyStart;
    public Unit getPlayerStats(GameObject playerPrefab){
        GameObject test= GameObject.Find("PlayerESI");
        Unit PlayerStats =playerPrefab.GetComponent<Unit>();
        if(test==null)
        {
            playerPrefab.GetComponent<Unit>().currHealth=playerPrefab.GetComponent<Unit>().maxHealth;
            WSLoader weapon  = playerPrefab.GetComponent<WSLoader>();
            weapon.weaponSwap("Crowbar");
            PlayerStats.damage=5;
            return playerPrefab.GetComponent<Unit>();
            
        }
        else
        {
            stats = GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
            PlayerStats.maxHealth = stats.health;
            PlayerStats.maxHealth += stats.Weapons[stats.equippedWeaponNumber].bonusHealth;
            PlayerStats.currHealth = PlayerStats.maxHealth;
            WSLoader weapon  = playerPrefab.GetComponent<WSLoader>();
            //weapon.weaponSwap("Crowbar");
            weapon.weaponSwap(stats.equippedWeapon);
            int weaponDmg = stats.setWeaponDmg();
           // Debug.Log(stats.damage + " " + stats.equippedWeapon );
            Debug.Log(weaponDmg);
            PlayerStats.damage=weaponDmg + stats.Weapons[stats.equippedWeaponNumber].bonusDamage;
            PlayerStats.defense = stats.Weapons[stats.equippedWeaponNumber].bonusDefends;
            PlayerStats.recover=stats.Weapons[stats.equippedWeaponNumber].recover;
            PlayerStats.rust=stats.Weapons[stats.equippedWeaponNumber].rust;
           // Debug.Log(stats.Weapons[stats.equippedWeaponNumber].bonusDamage + " " + stats.damage);
            //Debug.Log(PlayerStats.maxHealth);
            return PlayerStats;
        }
    }
    public Unit getEnemyStats(GameObject enemyPrefab){
        GameObject test= GameObject.Find("PlayerESI");
        Unit PlayerStats =enemyPrefab.GetComponent<Unit>();
        if(test==null)
        {
            enemyPrefab.GetComponent<Unit>().currHealth=enemyPrefab.GetComponent<Unit>().maxHealth;
            return enemyPrefab.GetComponent<Unit>();
            
        }
        else
        {
            stats = GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
            //Debug.Log(PlayerStats.maxHealth);
            return PlayerStats;
        }
    }
    public GameObject enemyExists(){
        GameObject test= GameObject.Find("PlayerESI");
        if(test==null)
        {
            return Resources.Load<GameObject>("Prefabs/CombatPreFabs/Enemy");
            
        }
        else
        {
            stats = GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
            return Resources.Load<GameObject>("Prefabs/CombatPreFabs/"+stats.MonsterToFight);
        }
    }
}
