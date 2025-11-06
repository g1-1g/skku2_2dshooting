using UnityEngine;

public class EnemyFollowing : Enemy
{

    private GameObject _player;



    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        Speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((_player.transform.position - transform.position) * Speed * Time.deltaTime);

    }
}
