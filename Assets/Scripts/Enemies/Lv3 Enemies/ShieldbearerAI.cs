using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldbearerAI : MonoBehaviour
{
    private enum State {
        Idle,
        Blocking,
        Attacking
    }

    private State currentState;
    private Animator anim;
    private float detectionRange  = 25f;

    public GameObject player;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerPos();
        detectPlayer();
        setAllAnimBool();

    }
    
    void updatePlayerPos(){
        playerPos = player.transform.position;
    }

    void detectPlayer(){
        if(Vector3.Distance(transform.position, playerPos) < detectionRange){
            facePlayer();
            currentState = State.Blocking;
        } else {
            currentState = State.Idle;
        }
    }

    bool isCurrently(State state){
        return (currentState == state);
    }
    
    void setAllAnimBool(){
        anim.SetBool("isIdle", isCurrently(State.Idle));
        anim.SetBool("isBlocking", isCurrently(State.Blocking));
        anim.SetBool("isAttacking", isCurrently(State.Attacking));
    }

    void facePlayer(){
        if((transform.position.x - playerPos.x) * transform.localScale.x < 0){
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
