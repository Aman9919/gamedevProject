using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int health = 30;
    [SerializeField]  float speed = 0.5f;
    public enum MovementType {tf,physics};
     [Header("Flavor")]
     [SerializeField] LayerMask groundMask;
     [SerializeField] private GameObject body;
    [SerializeField]  string creatureName = "Andrew";
    [SerializeField] private List<AnimationChanger> animationStateChanger;
     [Header("Data")]
    [SerializeField]  Vector3 homepos;
    [SerializeField] GameObject box;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        homepos = new Vector3(0,0,0);
        rb =GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    public void moveCreatureTransform(Vector3 direction){
        rb.velocity = direction * speed;

        if(rb.velocity.x < 0)
            body.transform.localScale = new Vector3(-1,1,1);
        else if (rb.velocity.x > 0)
            body.transform.localScale = new Vector3(1,1,1);
        if(rb.velocity.x != 0 || rb.velocity.y!=0){
            foreach(AnimationChanger asc in animationStateChanger){
                asc.ChangeState("Walking");
            }
        }
        else{
            foreach(AnimationChanger asc in animationStateChanger){
                asc.ChangeState("Idle");
            }
        }
    }
    public void moveCreature(Vector3 direction){
        transform.position += direction; //* Time.deltaTime; //* speed;
    }
}
