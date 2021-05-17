using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingWallToWall : MonoBehaviour
{
    public float enemyMovementSpeed = 3.0f;
    public bool enemyIsGoingRight = true;
    public float raycastingDistance = 2f;

    public int mAttackDamage = 2;
    public float timer = 5;

    private SpriteRenderer _mSpriteRenderer;

    [SerializeField] Animator enemyAnim;

    void Start()
    {
        _mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _mSpriteRenderer.flipX = enemyIsGoingRight;

        enemyAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //if enemy goes right get vector pointing right
        Vector3 directionTranslation = (enemyIsGoingRight) ? transform.right : -transform.right;
        directionTranslation *= Time.deltaTime * enemyMovementSpeed;

        transform.Translate(directionTranslation);

        CheckForWalls();

        if (timer == 0)
        {
            //attack
        }
    }

    private void CheckForWalls()
    {
        Vector3 raycastDirection = (enemyIsGoingRight) ? Vector3.right : Vector3.left;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastDirection * raycastingDistance - new Vector3(0f, 0.25f, 0f), raycastDirection, 0.075f);

        if (hit.collider != null)
        {
            if (hit.transform.tag == "Ground" || hit.transform.tag == "Enemy" || hit.transform.tag == "Hazard" || hit.transform.tag == "Wall" )
            {
                enemyIsGoingRight = !enemyIsGoingRight;
                _mSpriteRenderer.flipX = enemyIsGoingRight;
            }
        }     
    }
}
