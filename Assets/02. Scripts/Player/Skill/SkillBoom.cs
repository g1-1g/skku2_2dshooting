using UnityEngine;

public class SkillBoom : MonoBehaviour
{
    private float _skillSpawnTime = 0;
    private float _duration = 3;

    private void Start()
    {
        _skillSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > _skillSpawnTime + _duration)
        {
            Destroy(this.gameObject);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyGetDamage getDamage = collision.GetComponent<EnemyGetDamage>();
            if (getDamage != null) getDamage.Die();
        }
    }
}
