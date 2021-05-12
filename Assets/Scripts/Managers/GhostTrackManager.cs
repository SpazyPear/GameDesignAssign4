using UnityEngine;

public class GhostTrackManager : MonoBehaviour
{ 
    private AudioSource audioSource;
    public AudioClip[] musicTracks = new AudioClip[7]; //Can be changed and added on Unity

    void Start()
    {
        audioSource = GameObject.Find("SpectrualAnalyser").GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays a soundtrack that corresponds to the
    /// track placed into the AudioClip array.
    /// </summary>
    /// <param name="ID">Index of the array</param>
    public void playGhostTrack(int ID)
    {
        if (ID != 0)
        {
            audioSource = GameObject.Find("SpectrualAnalyser").GetComponent<AudioSource>();
            audioSource.clip = musicTracks[ID]; //Play music according to scene ID
            audioSource.Play(); //Play music
        }
    }
}
