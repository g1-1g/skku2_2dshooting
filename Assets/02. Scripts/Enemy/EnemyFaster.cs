using UnityEngine;

public class EnemyFaster : MonoBehaviour
{
    private EnemyStats _enemyStats;
    private float _originalHealth;
    void Start()
    {
        _enemyStats = GetComponent <EnemyStats>();
        _originalHealth = _enemyStats.Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() != null)
        {
            _enemyStats.Speed += _enemyStats.Speed * (_enemyStats.Health / _originalHealth);
        }
    }
}
