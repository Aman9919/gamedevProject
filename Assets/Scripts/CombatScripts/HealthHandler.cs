using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public Transform playerHealthTransform;
    public Transform playerHealthCatchup;
    public Transform enemyHealthTransform;
    public float speed = 5.0f;
    [Range(0f,1f)]
    public float percentage = 1f;
    // Update is called once per frame
    void Update()
    {
        playerHealthTransform.localScale = new Vector3(percentage,1f,1f);
        float catchupSize = Mathf.Lerp(playerHealthCatchup.localScale.x,percentage,Time.deltaTime*speed);
        if(catchupSize < percentage){
            catchupSize=percentage;
        }
        playerHealthCatchup.localScale = new Vector3(catchupSize,1.0f,1.0f);
    }
}
