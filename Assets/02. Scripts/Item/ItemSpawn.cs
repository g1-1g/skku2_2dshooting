using System;
using UnityEngine;

public enum EItemType
{
    AttackSpeedUp,
        MoveSpeedUp,
        HealthUp,
}
public class ItemSpawn : MonoBehaviour
{
    public GameObject[] Item;

    public float ProbabilityAttackSpeedUp = 0.1f;
    public float ProbabilityMoveSpeedUp = 0.2f;
    public float ProbabilityHealthUp = 0.7f;


    public void SpawnItem(Vector3 position)
    {

        float rand = UnityEngine.Random.Range(0, 1.0f);
        if (rand <= 0.5f)
        {
            return;
        }
        GameObject item = ChooseItem();
        Instantiate(item, position, Quaternion.identity);
    }

    private GameObject ChooseItem()
    {
        float rand = UnityEngine.Random.Range(0, 1.0f);
        if (rand <= ProbabilityHealthUp)
        {
            return Item[(int)EItemType.HealthUp];
        } else if (ProbabilityHealthUp < rand && rand <= ProbabilityHealthUp + ProbabilityMoveSpeedUp)
        {
            return Item[(int)EItemType.MoveSpeedUp];
        }
        else
        {
            return Item[(int)EItemType.AttackSpeedUp];
        }

    }
}
