using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected float _demage = 10;
    protected float _speed = 5;

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

        AttackEnemy(collision.gameObject);
        Destroy(gameObject);
    }

    void AttackEnemy(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();

        enemy.Health = Math.Max(enemy.Health - _demage, 0);
        Debug.Log(enemy.Health);

        if (enemy.Health == 0)
        {
            Destroy(target.gameObject);
        }
    }
}
