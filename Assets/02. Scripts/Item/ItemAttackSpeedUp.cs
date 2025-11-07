using UnityEngine;

public class ItemAttackSpeedUp : MonoBehaviour
{
    public float AttackspeedUp = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerFire player = collision.GetComponent<PlayerFire>();
            player.UpgradeFireRate(AttackspeedUp);
            Destroy(this.gameObject);
        }
    }
}
