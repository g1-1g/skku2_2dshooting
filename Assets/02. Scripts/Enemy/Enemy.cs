using System;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("스탯")]
    [SerializeField]   
    private float _speed = 2;

    private float _health = 100;

    void Start()
    {
        _speed = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _speed * Time.deltaTime);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) //compareTag를 사용하면 해당 태그가 없을 경우 런타임 오류를 냄. == 보다는 comparetag를 사용할 것
        {
            AttackPlayer(collision.gameObject);

        }
            
    }
   
    void AttackPlayer(GameObject gameObject)
    {
        PlayerMove player = gameObject.GetComponent<PlayerMove>();
        player.Hit();
        Destroy(this.gameObject);
    }

    public void Hit(float Demage)
    {

        _health = Math.Max(_health - Demage, 0);
        Debug.Log(_health);

        if (_health == 0)
        {
            Destroy(this.gameObject);
        }
    }


}
