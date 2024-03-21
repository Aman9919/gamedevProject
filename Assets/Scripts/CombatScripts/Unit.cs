using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string name;
    public int damage;
    public int maxHealth;
    public int currHealth;
    
    public bool TakeDamage(int dmg){
        currHealth -=dmg;
        if (currHealth<= 0)
            return true;
        else    
            return false;
    }
}
