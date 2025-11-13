using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("공격")]
    public float Demage = 10;

    [Header("이동")]
    public float Speed = 5;
    public float TargetSpeed = 10f;

    public float AccelTime = 1.5f;
    public float Acceleration;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        EnemyGetDamage enemy = collision.GetComponent<EnemyGetDamage>();

        enemy.Hit(Demage);
        gameObject.SetActive(false);
    }

    
}
