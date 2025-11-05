using System;
using UnityEngine;

public class SubBullet : Bullet
{


  
    void Start()
    {
        Demage = 30;
        Speed = 5;
        TargetSpeed = 10f;

        AccelTime = 1.5f;

         Acceleration = (TargetSpeed - Speed) / AccelTime;
        
        //transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
    }

    void Update()
    {
        shoot();
    }

    void shoot()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
        Speed = Mathf.Min(Speed + Acceleration * Time.deltaTime, TargetSpeed);
    }
    
}
