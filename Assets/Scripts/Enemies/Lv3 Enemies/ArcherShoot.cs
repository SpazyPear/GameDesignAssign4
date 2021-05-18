using UnityEngine;

public class ArcherShoot : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPoint;
    private void ShootArrow()
    {
        Instantiate(arrow, arrowPoint.transform);
    }
}
