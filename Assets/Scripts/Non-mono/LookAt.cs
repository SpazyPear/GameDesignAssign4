using UnityEngine;

public class LookAt
{
    public static Quaternion GetRotation(Vector2 pos1, Vector2 pos2)
    {
        float opposite = pos2.y - pos1.y;
        float adjacent = pos2.x - pos1.x;
        float angle = Mathf.Atan2(opposite, adjacent) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
