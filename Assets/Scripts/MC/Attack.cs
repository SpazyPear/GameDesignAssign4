using UnityEngine;

public class Attack : MonoBehaviour
{
    public int str;
    public float lifeSpan;
    private float delta;

    void Update()
    {
        delta = Time.deltaTime;
        if ((lifeSpan -= delta) < 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
