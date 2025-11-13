using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void SoundPlay(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
