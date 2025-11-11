using Unity.VisualScripting;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int dog = 5;

    private int dog2 = 5;
    private int speed = 3;
    void Update()
    {
        transform.position += movePosition();
        Debug.Log("dfdaf" + speed);
    }
    private Vector3 movePosition()
    {
        return Vector3.up * Time.deltaTime * speed;
    }
}
