using Unity.VisualScripting;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            return;
        }
        if (collision.CompareTag("Enemy"))
        {
            EnemyFactory.Instance.ReturnPool(collision.GetComponent<EnemyStats>());
            return;
        }
        Destroy(collision.gameObject);

    }
}
