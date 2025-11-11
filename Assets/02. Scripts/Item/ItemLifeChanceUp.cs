using UnityEngine;

public class ItemLifeChanceUp : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerStat player = collision.GetComponent<PlayerStat>();
            player.LifeChaceUp();
        }
    }
}
