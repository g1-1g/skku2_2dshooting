using System;
using System.Linq;
using Unity.VisualScripting;
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




    public float[] ItemWeight = { 10f, 20f, 30f };
    private float totalWeight;

    public void Start()
    {
        totalWeight = ItemWeight.Sum();

    }

    public void SpawnItem(Vector3 position)
    {


        if (UnityEngine.Random.Range(0, 1.0f) <= 0.5f) return;

        GameObject item = ChooseItem();
        Instantiate(item, position, Quaternion.identity);
    }

    private GameObject ChooseItem()
    {
        float rand = UnityEngine.Random.Range(0, 100);
        if (rand <= ItemWeight[(int)EItemType.HealthUp]/ totalWeight*100)
        {
            return Item[(int)EItemType.HealthUp];
        } else if (rand <= ItemWeight[(int)EItemType.HealthUp] / totalWeight * 100 + ItemWeight[(int)EItemType.MoveSpeedUp] / totalWeight * 100)
        {
            return Item[(int)EItemType.MoveSpeedUp];
        }
        else
        {
            return Item[(int)EItemType.AttackSpeedUp];
        }

    }
}
