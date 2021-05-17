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
    public LayerMask targetMask;
    private Vector3 playerPos;
    
    private float detectionRange  = 15.0f;
    private float attackRange = 2.0f;
    private float timeBtwAttack;
    private float startTimeBtwAttack = 1.5f;

    [SerializeField]
    private Transform meleePos;
    [SerializeField]
    private float meleeRange;

    void Start()
    {
        currentState = State.Idle;
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");        
    }
    
    void Update()
    {
        updatePlayerPos();
        detectPlayer();
        updateAnimBools();
        if(isCurrently(State.Attacking)){attack();}
    }

    // Checks if the unit's current state is <input>
    bool isCurrently(State state){
        return (currentState == state);
    }

    // Sets animator boolean parameters to match corresponding states
    void updateAnimBools(){
        anim.SetBool("isIdle", isCurrently(State.Idle));
        anim.SetBool("isBlocking", isCurrently(State.Blocking));
        anim.SetBool("isAttacking", isCurrently(State.Attacking));
    }

    void updatePlayerPos(){
        playerPos = player.transform.position;
    }

    void detectPlayer(){
        if(Vector3.Distance(transform.position, playerPos) < detectionRange){
            // If the player is within detectionRange, ensure the unit is facing the player then act
            facePlayer();
            currentState = State.Attacking;
        } else {
            // When the player is not detected, the unit calms down in Idle
            currentState = State.Idle;
        }
    }

    // Flips the sprite horizontally when the player is behind it so it faces the player
    void facePlayer(){
        if((transform.position.x - playerPos.x) * transform.localScale.x < 0){
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void defend(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 10f, targetMask);
        if(hit){
            gameObject.GetComponent<EnemyStats>().invincible = true; // Nullify damage
            //Debug.Log("Blocking!");
        } else {
            gameObject.GetComponent<EnemyStats>().invincible = false;
        }
    }

    void attack(){
        if((timeBtwAttack <= 0)){
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 2.0f, targetMask);
            //if(hit){anim.SetTrigger("Attack");}
            anim.SetTrigger("Attack");
            timeBtwAttack = startTimeBtwAttack;
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    // The MeleeArea's Collider is what damages the player so activate it for a particular Attack frame
    void attackHitboxOn(){ // Procs in the middle of the Attack animation
        meleePos.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    void attackHitboxOff(){ // Procs at the end of the Attack animation
        meleePos.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
