using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{

    public GameObject BoomPrefab;
    private Vector3 _center;

    [SerializeField]
    private AudioClip _boomClip;

    [SerializeField]
    private AudioClip _boomStartClip;


    void Start()
    {
        Camera cam = Camera.main;
        _center = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, transform.position.z - cam.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SFXManager.Instance.SoundPlay(_boomStartClip);
            SFXManager.Instance.SoundPlay(_boomClip);
            Instantiate(BoomPrefab, _center, Quaternion.identity);        
        }      
    }
}
