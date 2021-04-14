using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] SFX; //Can be changed and added on Unity

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays a soundeffect that corresponds to the
    /// track placed into the AudioClip array.
    /// </summary>
    /// <param name="ID">Index of the array</param>
    public void Play(int ID)
    {
        audioSource.clip = SFX[ID];
        audioSource.Play();
    }
}
