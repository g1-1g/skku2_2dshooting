using System;
using UnityEngine;

public class SubBullet : Bullet
{

    private float _speed = 5;

    public float TargetSpeed = 10f;

    public float AccelTime = 1.5f;
    public float Acceleration;

  
    void Start()
    {
        _demage = 30;
        TargetSpeed = 10f;

        AccelTime = 1.5f;


         Acceleration = (TargetSpeed - _speed) / AccelTime;
        
        //transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        _speed = Mathf.Min(_speed + Acceleration * Time.deltaTime, TargetSpeed);
    }
    
}
