using UnityEngine;

public class EffectSoundPlay : MonoBehaviour
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
