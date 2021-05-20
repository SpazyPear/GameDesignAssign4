using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardModeActivated : MonoBehaviour
{

    private SongController songController;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        songController = GameObject.Find("SpectrualAnalyser").GetComponent<SongController>();
        player = GameObject.Find("MC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == player.name)
        {
            songController.realTimeSpectralFluxAnalyzer.thresholdMultiplier = 7f;
            Destroy(this.gameObject, 0f);
            Destroy(GameObject.Find("Hard Mode Canvas"));
            Debug.Log(songController.realTimeSpectralFluxAnalyzer.thresholdMultiplier);
        }
    }
}
