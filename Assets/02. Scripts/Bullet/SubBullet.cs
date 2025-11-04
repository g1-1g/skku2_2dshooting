using UnityEngine;

public class SubBullet : MonoBehaviour
{

    private float _speed = 1;

    public float TargetSpeed = 3f;

    public float AccelTime = 0.5f;
    public float Acceleration;

    public string state = "Ready";
    void Start()
    {
        Acceleration = (TargetSpeed - _speed) / AccelTime;

    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        _speed = Mathf.Min(_speed + Acceleration * Time.deltaTime, TargetSpeed);
    }
}
