using System;
using UnityEngine;

public class EnemyGetDemage : MonoBehaviour
{
    private EnemyStats _enemyStat;

    void Start()
    {
        _enemyStat = GetComponent<EnemyStats>();
    }

    void Update()
    {
        
    }
    public void Hit(float Demage)
    {

        _enemyStat.Health = Math.Max(_enemyStat.Health - Demage, 0);
        Debug.Log(_enemyStat.Health);

        if (_enemyStat.Health == 0)
        {
            ItemSpawn itemSpawn = GameObject.FindFirstObjectByType<ItemSpawn>();
            if (itemSpawn != null)
            {
                itemSpawn.SpawnItem(this.transform.position);
            }

            Destroy(this.gameObject);
        }
    }

}
