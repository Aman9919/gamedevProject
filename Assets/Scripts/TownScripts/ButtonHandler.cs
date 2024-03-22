using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TownButtonHandler : MonoBehaviour
{
    public PlayerESI stats;
    public Player player;
    void Start()
    {
        stats=GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
    }
    public void unlockBlunderbuss(){
        stats.equippedWeapon="Blunderbuss";
        player.loader.weaponSwap(stats.equippedWeapon);
    }
    public void BountyOne(){
        SceneManager.LoadScene("Combat-grassland");
    }
}
