using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{

    public GameObject BoomPrefab;
    private Vector3 _center;

    [SerializeField]
    private AudioClip _boomClip;

    [SerializeField]
    private AudioClip _boomStartClip;
    private SFXManager _sfxManager;

    void Start()
    {
        Camera cam = Camera.main;
        _center = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, transform.position.z - cam.transform.position.z));

        _sfxManager = GetComponentInChildren<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _sfxManager.SoundPlay(_boomStartClip);
            _sfxManager.SoundPlay(_boomClip);
            Instantiate(BoomPrefab, _center, Quaternion.identity);        
        }      
    }
}
