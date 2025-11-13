using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainBullet : Bullet
{

    void Start()
    {
        Demage = 60;
        Speed = 8;
        TargetSpeed = 15f;
        AccelTime = 1.2f;

    }

    void Update()
    {
        Vector2 newPosition = Vector2.up * Speed * Time.deltaTime + (Vector2)transform.position;
        transform.position = newPosition;
    }   
}
