using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeStats : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerESI stats; 
    public Unit getPlayerStats(GameObject playerPrefab){
        GameObject test= GameObject.Find("PlayerESI");
        Unit PlayerStats =playerPrefab.GetComponent<Unit>();
        if(test==null)
        {
            playerPrefab.GetComponent<Unit>().currHealth=playerPrefab.GetComponent<Unit>().maxHealth;
            WSLoader weapon  = playerPrefab.GetComponent<WSLoader>();
            weapon.weaponSwap("Crowbar");
            return playerPrefab.GetComponent<Unit>();
            
        }
        else
        {
            stats = GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
            PlayerStats.maxHealth = stats.health;
            PlayerStats.currHealth = PlayerStats.maxHealth;
            WSLoader weapon  = playerPrefab.GetComponent<WSLoader>();
            //weapon.weaponSwap("Crowbar");
            weapon.weaponSwap(stats.equippedWeapon);
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
            PlayerStats.maxHealth = stats.health;
            PlayerStats.currHealth = PlayerStats.maxHealth;
            //Debug.Log(PlayerStats.maxHealth);
            return PlayerStats;
        }
    }
}
