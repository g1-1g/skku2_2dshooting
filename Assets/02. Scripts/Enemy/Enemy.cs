using System;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("스탯")]
    public float Speed = 2;

    public float Health = 100;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

        Health = Math.Max(Health - Demage, 0);
        Debug.Log(Health);

        if (Health == 0)
        {
            Destroy(this.gameObject);
        }
    }


}
