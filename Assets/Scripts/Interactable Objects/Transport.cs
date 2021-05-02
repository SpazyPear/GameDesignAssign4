using System.Collections;
using UnityEngine;

public class Transport : MonoBehaviour
{
    private SpriteRenderer SRend;
    public Sprite[] sprites;
    public float[] xyz;
    private bool isPlayerNear;
    private GameObject player;
    private Transitions transitions;

    void Start()
    {
        SRend = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        transitions = GameObject.FindGameObjectWithTag("Transition Manager").GetComponent<Transitions>();
        isPlayerNear = false;
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Teleport");
            isPlayerNear = false;
        }
    }

    IEnumerator Teleport()
    {
        PlayerControls controls = player.GetComponent<PlayerControls>();
        controls.AllowInput(false);

        transitions.Play();
        while (transitions.isOn)
        {
            yield return new WaitForEndOfFrame();
        }

        player.transform.position = new Vector3(xyz[0], xyz[1], xyz[2]);

        transitions.Play();
        while (transitions.isOn)
        {
            yield return new WaitForEndOfFrame();
        }

        controls.AllowInput(true);
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
