using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BountyBoardTrigger : MonoBehaviour
{

    public SpriteRenderer bountyBoard;
    public void Start(){
        bountyBoard.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D other){
        bountyBoard.gameObject.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D other){
        bountyBoard.gameObject.SetActive(false);
    }

}
