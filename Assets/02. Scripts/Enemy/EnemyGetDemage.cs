using System;
using UnityEngine;

public class EnemyGetDemage : MonoBehaviour
{
    private EnemyStats _enemyStat;
    private Animator _animator;

    void Start()
    {
        _enemyStat = GetComponent<EnemyStats>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void Hit(float Demage)
    {

        _enemyStat.Health = Math.Max(_enemyStat.Health - Demage, 0);
        if (_animator != null)
        {
            _animator.SetTrigger("isHit");

        }
            
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
