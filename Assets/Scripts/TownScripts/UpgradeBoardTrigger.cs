using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeBoardTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer upgradeBoard;
    public PlayerESI stats;
    public Button upgrade;
    void Start()
    {
        upgradeBoard.gameObject.SetActive(false);
        stats=GameObject.Find("PlayerESI").GetComponent<PlayerESI>();
        upgrade.interactable=false;
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(stats.spareParts > 0)
            upgrade.interactable=true;
        upgradeBoard.gameObject.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D other){
        upgrade.interactable=false;
        upgradeBoard.gameObject.SetActive(false);
    }
    
}
