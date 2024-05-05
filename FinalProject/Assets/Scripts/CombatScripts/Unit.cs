using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public new string name;
    public int damage;
    public int maxHealth;
    public int currHealth;
    public int recover=0;
    public int rust =0;
    int rustCounter = 0;
    public int defense=0;
    public HealthScript UI;
    public bool TakeDamage(int dmg){
        if(dmg > defense)
            currHealth -=(dmg-defense);
        if (currHealth<= 0)
            return true;
        else    
            return false;
    }
    public void Recover(){
        if(recover > 0)
        { 
            UI.Recovering();
            if(currHealth<maxHealth && currHealth < maxHealth-recover){
            currHealth+=recover;
            }
            else if (currHealth<maxHealth)
            {
                currHealth+=maxHealth-currHealth;
            }
        }
    }
    public void addRust(int num){
        rustCounter +=num;
    }
    public void Special(int value){
        if(currHealth<maxHealth && currHealth < maxHealth-value){
            currHealth+=value;
        }
        else if (currHealth<maxHealth)
        {
            currHealth+=maxHealth-currHealth;
        }
    }
    public bool Rust(){
        if(rustCounter > 0)
        {
            UI.RustDamageTaken();
            rustCounter--;
            return TakeDamage(rustCounter+1);
        }
        return TakeDamage(rustCounter);
    }
    public void heal(){
        recover+=1;
    }
}
