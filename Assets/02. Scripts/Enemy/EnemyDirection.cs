using UnityEngine;

public class EnemyDirection : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
