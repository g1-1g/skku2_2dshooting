using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{

    public GameObject BoomPrefab;

    private Vector3 _center;


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
            Instantiate(BoomPrefab, _center, Quaternion.identity);        
        }      
    }
}
