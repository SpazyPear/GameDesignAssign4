using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject inventoryScreen;
    private Screens screens;
    private List<GameObject> objs = new List<GameObject>();

    public void Add(GameObject obj)
    {
        objs.Add(obj);
        screens = inventoryScreen.GetComponent<Screens>();
    }

    public void SetPauseState(bool boolean)
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(!boolean);
        }
        inventoryScreen.SetActive(boolean);
        screens.Reset(!boolean);
    }

    public void Clean()
    {
        objs.Clear();
    }
}
