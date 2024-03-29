using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CombatState {  START, PLAYERTURN, ENEMYTURN, WON, LOST  }
public class CombatHandler : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerStart;
    public Transform enemyStart;
    Unit playerUnit;
    Unit enemyUnit;
    public HealthScript enemyUI;
    public HealthScript playerUI;
    public CombatState state;
    public InitializeStats startStats;
    public SpriteRenderer endScreen;
    public Button end;
    // Start is called before the first frame update
    void Start()
    {
        state=CombatState.START;
        StartCoroutine(SetupCombat());
    }
    IEnumerator SetupCombat(){
        GameObject player = Instantiate(playerPrefab,playerStart);
        playerUnit=startStats.getPlayerStats(player);
        GameObject enemy = Instantiate(enemyPrefab,enemyStart);
        enemyUnit = startStats.getEnemyStats(enemy);
        playerUI.SetUp(playerUnit);
        enemyUI.SetUp(enemyUnit);
        yield return new WaitForSeconds(2f);
        state=CombatState.PLAYERTURN;
        PlayerTurn();
    }
    void EndBattle(){
    float timer = 0;
    endScreen.color=new Color(1f,1f,1f,0f);
    end.GetComponent<Image>().color =new Color(1f,1f,1f,0f);
    endScreen.gameObject.SetActive(true);
    GameObject test = GameObject.Find("PlayerESI");
    if(test != null)
    {
        PlayerESI drops = test.GetComponent<PlayerESI>();
        drops.spareParts+=1;
    }
    StartCoroutine(loadDone());
    IEnumerator loadDone(){
        while (timer < 1f){
            yield return null;
            timer+=Time.deltaTime;
            endScreen.color=new Color(1f,1f,1f,0f+timer);
            end.GetComponent<Image>().color =new Color(1f,1f,1f,0f+timer);
        }
    }
    if(state== CombatState.WON){
        //SceneManager.LoadScene("Town");
     }
    else if (state== CombatState.LOST){

     }


    }
    void PlayerTurn()
    {

    }
    public void onAttack()
    {
        if(state != CombatState.PLAYERTURN)
            return;
        state=CombatState.ENEMYTURN;
        StartCoroutine(PlayerAttack());
    }
    IEnumerator PlayerAttack(){
        float Start =playerStart.transform.localPosition.x;
        float movePos =(enemyStart.transform.localPosition.x+Start)/2;
        //Debug.Log(Start + "   " + movePos);
        bool isDead=false;
        float timer = 0;
            
         while (timer < .5f){
            yield return null;
            timer+=Time.deltaTime;
            playerStart.transform.localPosition=Vector3.Lerp(new Vector3(Start,playerStart.transform.localPosition.y,0),new Vector3(movePos,playerStart.transform.localPosition.y,0),timer/.5f);
        }
        isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyUI.SetHealth(enemyUnit.currHealth);
            
        timer = 0;
            
        while (timer < .5f){
            yield return null;
            timer+=Time.deltaTime;
            playerStart.transform.localPosition=Vector3.Lerp(new Vector3(movePos,playerStart.transform.localPosition.y,0),new Vector3(Start,playerStart.transform.localPosition.y,0),timer/.5f);
        }
        //isDead = enemyUnit.TakeDamage(playerUnit.damage);
       // enemyUI.SetHealth(enemyUnit.currHealth);
        yield return new WaitForSeconds(2f);
        if(isDead){
            state=CombatState.WON;
            EndBattle();
        }
        else{
            state=CombatState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        bool isDead=false;
        float Start =enemyStart.transform.localPosition.x;
        float movePos =(playerStart.transform.localPosition.x+Start)/2;
        float timer = 0;
            
         while (timer < .5f){
            yield return null;
            timer+=Time.deltaTime;
            enemyStart.transform.localPosition=Vector3.Lerp(new Vector3(Start,enemyStart.transform.localPosition.y,0),new Vector3(movePos,enemyStart.transform.localPosition.y,0),timer/.5f);
            }
        isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerUI.SetHealth(playerUnit.currHealth);
        timer = 0;
        while (timer < .5f){
            yield return null;
            timer+=Time.deltaTime;
            enemyStart.transform.localPosition=Vector3.Lerp(new Vector3(movePos,enemyStart.transform.localPosition.y,0),new Vector3(Start,enemyStart.transform.localPosition.y,0),timer/.5f);
        }
        if(isDead){
            state=CombatState.LOST;
            EndBattle();
        }
        else{
            state=CombatState.PLAYERTURN;
            PlayerTurn();
        }
    }
}
