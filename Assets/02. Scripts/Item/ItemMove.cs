using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private float _speed = 3.0f;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
