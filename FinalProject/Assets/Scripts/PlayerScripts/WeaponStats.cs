using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{

    public string[] Modifiers;
    public int modifierCount = 0;
    public int bonusHealth =0;
    public int bonusDamage = 0;
    public int bonusDefends = 0;
    public int recover=0;
    public int rust=0;
    public WeaponStats(){
        Modifiers=new string[6];
        Modifiers[0]="test";
    }
    public void randomModifiersRare(){
        Modifiers=new string[6];
        int randStaters = Random.Range(1,4);
        int randHelpers = Random.Range(0,2);
        Debug.Log(randHelpers);
        modifierCount=randStaters+randHelpers-1;
        int i = 0;
        int randModifier = 0;
        int randTier = 0;
        ArrayList arr = new ArrayList(){0,0,0,0,0,0}; // Used to make sure no modifiers are duplicated
        bonusDamage=0;
        bonusHealth=0;
        bonusDefends=0;
        recover=0;
        rust=0;
        while( i < randStaters ){
            randModifier=Random.Range(1,6);
            randTier= Random.Range(1,4);
            if(arr.Contains(randModifier)){
                //Debug.Log("duplicate");
                continue;
                }
            switch(randModifier){
                case 1:
                    Modifiers[i] = "Full of Life Tier "+randTier;
                    switch(randTier){
                        case 1:
                        bonusHealth=Random.Range(11,21);
                        break;
                        case 2:
                        bonusHealth=Random.Range(6,11);
                        break;
                        case 3:
                        bonusHealth=Random.Range(1,6);
                        break;
                    }
                    Modifiers[i] += "\n"+ bonusHealth + " Bonus Health";
                    break;
                case 2: 
                    Modifiers[i] = "Blunting Tier " +randTier;
                    switch(randTier){
                        case 1:
                        bonusDamage=7;
                        break;
                        case 2:
                        bonusDamage=5;
                        break;
                        case 3:
                        bonusDamage=3;
                        break;
                    }
                    Modifiers[i] += "\n"+ bonusDamage + " Bonus Damage";
                    break;
                case 3: Modifiers[i] = "Plated Tier " +randTier;
                switch(randTier){
                        case 1:
                        bonusDefends=5;
                        break;
                        case 2:
                        bonusDefends=4;
                        break;
                        case 3:
                        bonusDefends=3;
                        break;
                    }
                    Modifiers[i] += "\n"+ bonusDefends + " Bonus Defence";
                    break;
                case 4: Modifiers[i] = "Debugging Tier " +randTier;
                     Modifiers[i] += "\n 1 Wasted Space";
                    break;
                case 5: Modifiers[i] = "Playtesting Tier " +randTier;
                    Modifiers[i] += "\n 1 Wasted Space";
                    break;
                case 6: Modifiers[i] = "Of Frustration Tier " +randTier;
                    Modifiers[i] += "\n 1 Wasted Space";
                    break;
                
            }
            arr[i]=randModifier;
            i++;
        }
        //generates Helper modifiers
        arr = new ArrayList(){0,0,0,0,0,0};
        while( i < randStaters + randHelpers ){
            randModifier=Random.Range(1,3);
            randTier= Random.Range(1,4);
            if(arr.Contains(randModifier)){
                //Debug.Log("duplicate");
                continue;
                }
            switch(randModifier){
                case 1:
                    Modifiers[i] = "Corroding "+randTier;
                    switch(randTier){
                        case 1:
                        rust=2;
                        break;
                        case 2:
                        rust=1;
                        break;
                        case 3:
                        rust=1;
                        break;
                    }
                    Modifiers[i] += "\n Inflict "+ rust+ " Rust on Hit";
                    break;
                case 2:
                    Modifiers[i] = "Regenerating "+randTier;
                    switch(randTier){
                        case 1:
                        recover=3;
                        break;
                        case 2:
                        recover=2;
                        break;
                        case 3:
                        recover=1;
                        break;
                    }
                    Modifiers[i] += "\n Recover "+ recover+ " on end of turn";
                    break;
                
            }
            arr[i]=randModifier;
            i++;
            }
    }
}
