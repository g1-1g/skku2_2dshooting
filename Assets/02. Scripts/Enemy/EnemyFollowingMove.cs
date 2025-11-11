using UnityEngine;

public class EnemyFollowingMove : EnemyMove
{
    private EnemyStats _enemyStat;
    private GameObject _player;
    void Start()
    {
        _enemyStat = GetComponent<EnemyStats>();
        _player = GameObject.FindWithTag("Player");

    }


    protected override void Move()
    {
        if (_player == null) return;
        transform.Translate((_player.transform.position - transform.position).normalized * _enemyStat.Speed * Time.deltaTime);
    }
}
