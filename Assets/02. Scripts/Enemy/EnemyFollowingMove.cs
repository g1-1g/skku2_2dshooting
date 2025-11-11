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
        Vector2 direction = _player.transform.position - transform.position;
        transform.Translate(direction.normalized * _enemyStat.Speed * Time.deltaTime);

        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle +90 );

    }
}
