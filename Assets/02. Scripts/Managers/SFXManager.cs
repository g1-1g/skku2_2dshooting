using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public static SFXManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void SoundPlay(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
