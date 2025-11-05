using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("스탯")]
    [SerializeField]   
    private float _speed = 2;

    public float Health = 100;

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
            //Destroy(this.gameObject);

        }
            
    }
    
    void AttackPlayer(GameObject gameObject)
    {
        PlayerMove player = gameObject.GetComponent<PlayerMove>();
        if (player.LifeChance > 0)
        {
            player.LifeChance -= 1;
            Debug.Log("Player Life Chance: " + player.LifeChance);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Player Die");
        }
        Destroy(this.gameObject);
    }
    
    
}
