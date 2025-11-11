using UnityEngine;

public class ItemAttackSpeedUp : Item
{
    public float AttackspeedUp = 0.1f;


    protected override void ApplyEffect(GameObject player)
    {
        PlayerFire playerFire = player.GetComponent<PlayerFire>();
        playerFire.UpgradeFireRate(AttackspeedUp);
    }
}
