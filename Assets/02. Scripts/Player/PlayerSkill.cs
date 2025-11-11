using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
   
    private void Start()
    {
        Camera cam = Camera.main;
        Vector3 Center = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, transform.position.z - cam.transform.position.z));
    }
    private void Update()
    {
        if (Input.GetKey("2"))
        {
            
        }
    }
}
