using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]  Player player;
    public SpriteRenderer options;
    int optionsMenu = 0;
    void Update()
    {
        
        Vector3 input = Vector3.zero;
        if(Input.GetKey(KeyCode.W)){
            input.y += 1f;
        }
        if(Input.GetKey(KeyCode.S)){
            input.y += -1;
        }
        if(Input.GetKey(KeyCode.A)){
            input.x += -1f;
        }
        if(Input.GetKey(KeyCode.D)){
            input.x += 1f;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (optionsMenu == 0){
                optionsMenu=1;
                options.gameObject.SetActive(true);
             }
            else{
                optionsMenu=0;
                options.gameObject.SetActive(false);
            }

        }
        player.moveCreatureTransform(input);
       // playercreature.Movement(input);
    }
}
