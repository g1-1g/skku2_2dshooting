using UnityEngine;

public class ItemSpeedUp : MonoBehaviour
{
    public float SpeedUp = 1.0f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerSpeedChange player = collision.GetComponent<PlayerSpeedChange>();
            player.MoveSpeedUp(SpeedUp);
            Destroy(this.gameObject);
        }
    }
}
