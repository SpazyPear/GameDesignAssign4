using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    private SpriteRenderer SRend;
    public Sprite[] sprites;
    private bool isPlayerNear;
    private GameObject player;

    void Start()
    {
        SRend = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        isPlayerNear = false;
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector3(45, -6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetState(collision, 1, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetState(collision, 0, false);
    }

    private void SetState(Collider2D collision, int index, bool boolean)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SRend.sprite = sprites[index];
            isPlayerNear = boolean;
        }
    }
}
