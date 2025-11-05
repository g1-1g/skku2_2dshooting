using System;
using UnityEngine;

public class SubBullet : MonoBehaviour
{

    private float _speed = 5;
    public float _demage = 30;

    public float TargetSpeed = 10f;

    public float AccelTime = 1.5f;
    public float Acceleration;

  
    void Start()
    {
        Acceleration = (TargetSpeed - _speed) / AccelTime;
        
        //transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        _speed = Mathf.Min(_speed + Acceleration * Time.deltaTime, TargetSpeed);
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
