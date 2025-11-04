using UnityEngine;

public class SubBullet : MonoBehaviour
{

    private float _speed = 5;

    public float TargetSpeed = 10f;

    public float AccelTime = 1.5f;
    public float Acceleration;

    public string state = "Ready";
    void Start()
    {
        Acceleration = (TargetSpeed - _speed) / AccelTime;
        
        //transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        _speed = Mathf.Min(_speed + Acceleration * Time.deltaTime, TargetSpeed);
        Debug.Log(Acceleration);
    }
}
