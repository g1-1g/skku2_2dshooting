using UnityEngine;

public class EnemyFaster : MonoBehaviour
{
    private EnemyStats enemyStats;
    private float originalHealth;
    void Start()
    {
        enemyStats = GetComponent <EnemyStats>();
        originalHealth = enemyStats.Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() != null)
        {
            enemyStats.Speed += enemyStats.Speed * (enemyStats.Health / originalHealth);
        }
    }
}
