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
            return playerPrefab.GetComponent<Unit>();
            
        }
        else
        {
            stats = GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
            PlayerStats.maxHealth = stats.health;
            PlayerStats.currHealth = PlayerStats.maxHealth;
            Debug.Log(PlayerStats.maxHealth);
            return PlayerStats;
        }
    }
}
