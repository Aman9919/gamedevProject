using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BountyBoard : MonoBehaviour
{
    public Canvas canvas;
    //public GameObject bountyboard;
    public SpriteRenderer bountyBoard;
    [SerializeField] public Button buttonBounty1;
    // Start is called before the first frame update
    public void Start(){
        buttonBounty1.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D other){
        canvas.sortingLayerName = "Player";
        bountyBoard.sortingLayerName = "Player";
        buttonBounty1.gameObject.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D other){
        buttonBounty1.gameObject.SetActive(false);
        if(canvas != null){
            canvas.sortingLayerName = "Default";
            bountyBoard.sortingLayerName  = "Default";
            }
    }
    public void BountyOne(){
        SceneManager.LoadScene("Combat-grassland");
    }
}
