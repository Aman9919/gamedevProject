using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        enemyUnit = enemy.GetComponent<Unit>();
        playerUI.SetUp(playerUnit);
        enemyUI.SetUp(enemyUnit);
        yield return new WaitForSeconds(2f);
        state=CombatState.PLAYERTURN;
        PlayerTurn();
    }
    void EndBattle(){
        if(state== CombatState.WON){
            SceneManager.LoadScene("Town");
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
        
        StartCoroutine(PlayerAttack());
    }
    IEnumerator PlayerAttack(){
        float Start =playerStart.transform.localPosition.x;
        bool isDead=false;
        StartCoroutine(attackForward());
        IEnumerator attackForward(){
            float timer = 0;
            
            while (timer < .5f){
                yield return null;
                timer+=Time.deltaTime;
                playerStart.transform.localPosition=Vector3.Lerp(new Vector3(Start,0,0),new Vector3(Start+1.5f,0,0),timer/.5f);
            }
            StartCoroutine(attackBack());
            isDead = enemyUnit.TakeDamage(playerUnit.damage);
            enemyUI.SetHealth(enemyUnit.currHealth);
            IEnumerator attackBack(){
            float timer = 0;
            
            while (timer < .5f){
                yield return null;
                timer+=Time.deltaTime;
                playerStart.transform.localPosition=Vector3.Lerp(new Vector3(Start+1.5f,0,0),new Vector3(Start,0,0),timer/.5f);
            }
        }
        }
        //isDead = enemyUnit.TakeDamage(playerUnit.damage);
       // enemyUI.SetHealth(enemyUnit.currHealth);
        state=CombatState.ENEMYTURN;
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
        StartCoroutine(attackForward());
        IEnumerator attackForward(){
            float timer = 0;
            
            while (timer < .5f){
                yield return null;
                timer+=Time.deltaTime;
                enemyStart.transform.localPosition=Vector3.Lerp(new Vector3(Start,0,0),new Vector3(Start-1.5f,0,0),timer/.5f);
            }
            StartCoroutine(attackBack());
            isDead = playerUnit.TakeDamage(enemyUnit.damage);
            playerUI.SetHealth(playerUnit.currHealth);
            IEnumerator attackBack(){
            float timer = 0;
            while (timer < .5f){
                yield return null;
                timer+=Time.deltaTime;
                enemyStart.transform.localPosition=Vector3.Lerp(new Vector3(Start-1.5f,0,0),new Vector3(Start,0,0),timer/.5f);
            }
            }
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
