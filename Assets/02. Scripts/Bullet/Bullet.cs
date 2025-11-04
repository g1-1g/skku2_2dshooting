using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //[SerializeField]
    private float _speed = 4;

    public float TargetSpeed = 15f;
    
    public float AccelTime = 1.2f;
    public float Acceleration;

    public string state = "Ready";
    void Start()
    {
        Acceleration = (TargetSpeed - _speed) / AccelTime;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        _speed = Mathf.Min(_speed + Acceleration * Time.deltaTime, TargetSpeed);
        /*if (Input.GetMouseButtonDown(0))
        {
            state = "Shooting";
        }
        switch (state)
        {
            case "Ready":
             
                break;
            case "Shooting":
                //Debug.Log (_speed);
                transform.Translate(Vector2.up * _speed * Time.deltaTime);
                _speed = Mathf.Min(_speed + Acceleration * Time.deltaTime, TargetSpeed);
                break;



        }*/
        
    }

    
}
