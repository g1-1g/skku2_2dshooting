using UnityEngine;

public class ItemLifeChanceUp : Item
{
    protected override void ApplyEffect(GameObject player)
    {
        PlayerStat playerStat = player.GetComponent<PlayerStat>();
        playerStat.LifeChanceUp();
    }
}
