using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerESI : MonoBehaviour
{
    public static PlayerESI Instance;
    [Header("Stats")]
    [SerializeField] public int health = 25;
    [SerializeField] public string PlayerName = "Andrew";
    [SerializeField] public string equippedWeapon="Crowbar";
    [SerializeField] public int spareParts = 0;
    public void Awake(){
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
