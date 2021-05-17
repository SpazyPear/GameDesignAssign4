using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAI : MonoBehaviour
{
    
    private Animator anim;

    public GameObject player;
    private Vector3 playerPos;
    private Vector3 targetPos; // Where the shot will move towards

    public Transform firePoint; // Point of source for arrow projectile
    public GameObject arrowPrefab;

    private float range = 20.0f; // Detection range = attack range
    private float attackSpeed = 4.0f; // How often the Archer shoots
    private float nextShot;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerPos();
        detectPlayer();
    }

    void updatePlayerPos(){
        playerPos = player.transform.position;
    }

    void facePlayer(){
        if(transform.position.x >= playerPos.x){
            // Player is at left of enemy
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            transform.rotation = Quaternion.identity; // Player is at right
        }
    }

    void detectPlayer(){
        if(Vector3.Distance(transform.position, playerPos) < range){
            facePlayer();
            anim.SetTrigger("shoot"); // shoot function is called as an animation event
        }
    }

    void shoot(){
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
