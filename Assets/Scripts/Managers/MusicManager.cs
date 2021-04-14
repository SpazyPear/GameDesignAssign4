using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] musicTracks = new AudioClip[7]; //Can be changed and added on Unity

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays a soundtrack that corresponds to the
    /// track placed into the AudioClip array.
    /// </summary>
    /// <param name="ID">Index of the array</param>
    public void playTrack(int ID)
    {
        audioSource.clip = musicTracks[ID]; //Play music according to scene ID
        audioSource.Play(); //Play music
    }
}
