using UnityEngine;

public class EnemyDirectionMove : EnemyMove
{

    private EnemyStats _enemyStat;
    void Start()
    {
        _enemyStat = GetComponent<EnemyStats>();
    }



    override protected void Move()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _enemyStat.Speed * Time.deltaTime);
    }
}
