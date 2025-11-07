using UnityEngine;

public class ItemSpeedUp : MonoBehaviour
{
    public float SpeedUp = 2.0f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerMove player = collision.GetComponent<PlayerMove>();
            player.MoveSpeedUp(SpeedUp);
            Destroy(this.gameObject);
        }
    }
}
