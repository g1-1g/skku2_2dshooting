using UnityEngine;

public class ItemLifeChanceUp : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerMove player = collision.GetComponent<PlayerMove>();
            player.LifeChaceUp();
            Destroy(this.gameObject);
        }
    }
}
