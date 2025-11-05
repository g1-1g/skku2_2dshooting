using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]   
    private float _speed = 2;

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

        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        Debug.Log("Enemy Destroyed");
    }
    
    
    
}
