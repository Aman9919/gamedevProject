using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string currentState="Idle";


    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeState(string state){
        if(currentState==state)
            return;
        currentState=state;
        animator.Play(currentState);
    }
}
