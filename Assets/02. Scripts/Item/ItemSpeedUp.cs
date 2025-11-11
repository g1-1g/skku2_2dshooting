using UnityEngine;

public class ItemSpeedUp : Item
{
    public float SpeedUp = 1.0f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerSpeedChange playerSpeedChange = player.GetComponent<PlayerSpeedChange>();
        playerSpeedChange.MoveSpeedUp(SpeedUp);
    }
}
