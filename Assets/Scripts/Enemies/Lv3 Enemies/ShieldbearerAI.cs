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

    public GameObject player;
    private Vector3 playerPos;
    
    private float detectionRange  = 15.0f;
    private float attackRange = 2.0f;
    private float timeBtwAttack;
    private float startTimeBtwAttack = 2.0f;
    private int damage = 1;

    [SerializeField]
    private Transform meleePos;
    [SerializeField]
    private float meleeRange;

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
        if(isCurrently(State.Attacking)) attack();

    }
    
    void updatePlayerPos(){
        playerPos = player.transform.position;
    }

    void detectPlayer(){
        if(Vector3.Distance(transform.position, playerPos) < detectionRange){
            // If the player is within detectionRange, ensure the unit is facing the player then act
            facePlayer();

            currentState = State.Attacking;
            //currentState = State.Blocking;
        } else {
            // When the player is not detected, the unit calms down in Idle
            currentState = State.Idle;
        }
    }

    // Checks if the unit's current state is <input>
    bool isCurrently(State state){
        return (currentState == state);
    }
    
    // Sets animator boolean parameters to match corresponding states
    void setAllAnimBool(){
        anim.SetBool("isIdle", isCurrently(State.Idle));
        anim.SetBool("isBlocking", isCurrently(State.Blocking));
        anim.SetBool("isAttacking", isCurrently(State.Attacking));
    }

    // Flips the sprite horizontally when the player is behind it so it faces the player
    void facePlayer(){
        if((transform.position.x - playerPos.x) * transform.localScale.x < 0){
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void attack(){
        if((timeBtwAttack <= 0)){
            Collider2D[] playerToHit = Physics2D.OverlapCircleAll(meleePos.position, meleeRange);
            for(int i = 0; i < playerToHit.Length; i++){
                if(playerToHit[i].gameObject.tag == "Player"){
                    playerToHit[i].gameObject.GetComponent<StatManager>().changeHP(-damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }
}
