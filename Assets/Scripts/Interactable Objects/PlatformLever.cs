using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLever : MonoBehaviour
{
    private bool nearPlayer = false;
    public bool active = false;
    public Sprite[] leverSprites;
    private SpriteRenderer spriteRenderer;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = leverSprites[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(nearPlayer && Input.GetKeyDown(KeyCode.E)){
            activatePlatform();
        }
    }

    void activatePlatform(){
        active = true;
        platform.GetComponent<VerticalMovingPlatform>().enabled = active;
        spriteRenderer.sprite = leverSprites[0];
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            nearPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        nearPlayer = false;
    }
}
