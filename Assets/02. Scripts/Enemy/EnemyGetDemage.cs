using System;
using UnityEngine;

public class EnemyGetDemage : MonoBehaviour
{
    private EnemyStats _enemyStat;
    private Animator _animator;

    [Header("Demage Effect")]
    public GameObject demageEffect;

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
            MakeExplosionEffect();
            Destroy(this.gameObject);
        }

    }

    private void MakeExplosionEffect()
    {
        Instantiate(demageEffect, this.transform.position, Quaternion.identity);
    }

}
