using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatHandlerDesert : MonoBehaviour
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
        //GameObject enemy = Instantiate(enemyPrefab,enemyStart);
        GameObject enemy = Instantiate(startStats.enemyExists(),enemyStart);
        enemyUnit = startStats.getEnemyStats(enemy);
        
        playerUI.SetUp(playerUnit);
        enemyUI.SetUp(enemyUnit);
        playerUnit.UI=playerUI;
        enemyUnit.UI=enemyUI;


        //Debug.Log(playerUnit.damage);
        yield return new WaitForSeconds(2f);
        playerUI.HarshSun();
        playerUnit.addRust(1);
        state=CombatState.PLAYERTURN;
        PlayerTurn();
    }
    void EndBattle(){
    float timer = 0;
    endScreen.color=new Color(1f,1f,1f,0f);
    end.GetComponent<Image>().color =new Color(1f,1f,1f,0f);
    endScreen.gameObject.SetActive(true);
    GameObject test = GameObject.Find("PlayerESI");
    if(test != null && state==CombatState.WON)
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
    public void onSpecial()
    {
        if(state != CombatState.PLAYERTURN)
            return;
        //Debug.Log(playerUnit.damage);
        state=CombatState.ENEMYTURN;
        StartCoroutine(PlayerSpecial());
    }
    public void onAttack()
    {
        if(state != CombatState.PLAYERTURN)
            return;
        //Debug.Log(playerUnit.damage);
        state=CombatState.ENEMYTURN;
        StartCoroutine(PlayerAttack());
    }
    public void onHeal()
    {
        if(state != CombatState.PLAYERTURN)
            return;
        state=CombatState.ENEMYTURN;
        StartCoroutine(PlayerHeal());
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
        if(playerUnit.rust >0){
            enemyUnit.addRust(playerUnit.rust);
            enemyUI.RustText();
        }
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
           MidTurn();
        }
    }
    void MidTurn()
    {
        bool isDead=false;
        playerUnit.Recover();
        playerUI.SetHealth(playerUnit.currHealth);
        isDead = playerUnit.Rust();
        playerUI.SetHealth(playerUnit.currHealth);
        if(isDead){
            state=CombatState.LOST;
            EndBattle();
            return;
        }
        
        enemyUnit.Recover();
        enemyUI.SetHealth(enemyUnit.currHealth);
        isDead = enemyUnit.Rust();
        enemyUI.SetHealth(enemyUnit.currHealth);
        if(isDead){
            state=CombatState.WON;
            EndBattle();
            return;
        }
        state=CombatState.PLAYERTURN;
        playerUI.HarshSun();
        playerUnit.addRust(1);
        PlayerTurn();
        
        
    }
    IEnumerator PlayerHeal(){

        //Debug.Log(Start + "   " + movePos);
        bool isDead=false;
        float timer = 0;
            
         while (timer < .5f){
            yield return null;
            timer+=Time.deltaTime;
        }

        enemyUI.SetHealth(enemyUnit.currHealth);
        playerUnit.heal();
        playerUI.RecoverText();
        timer = 0;         
        while (timer < .5f){
            yield return null;
            timer+=Time.deltaTime;
        }
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
    IEnumerator PlayerSpecial(){
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
        isDead = enemyUnit.TakeDamage(playerUnit.damage/2);
        enemyUI.SetHealth(enemyUnit.currHealth);
        playerUnit.Special(playerUnit.damage/2);
        playerUI.SetHealth(playerUnit.currHealth);
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
}
