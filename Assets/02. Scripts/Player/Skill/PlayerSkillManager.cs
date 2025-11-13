using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{

    public GameObject BoomPrefab;
    private Vector3 _center;

    [SerializeField]
    private AudioClip _boomClip;

    [SerializeField]
    private AudioClip _boomStartClip;
    private AudioSource _audioSource;

    void Start()
    {
        Camera cam = Camera.main;
        _center = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, transform.position.z - cam.transform.position.z));

        _audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _audioSource.PlayOneShot(_boomStartClip);
            _audioSource.PlayOneShot(_boomClip);
            Instantiate(BoomPrefab, _center, Quaternion.identity);        
        }      
    }
}
