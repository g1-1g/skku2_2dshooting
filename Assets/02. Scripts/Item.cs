using UnityEngine;

public class Item : MonoBehaviour
{
    public float SpeedUp = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerMove player = collision.GetComponent<PlayerMove>();
            player.Speed += SpeedUp;
            Destroy(this.gameObject);
        }
    }
}
