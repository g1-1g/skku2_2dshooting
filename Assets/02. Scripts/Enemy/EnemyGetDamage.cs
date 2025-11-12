using System;
using UnityEngine;

public class EnemyGetDamage : MonoBehaviour
{
    private EnemyStats _enemyStat;
    private Animator _animator;

    private ItemSpawn _itemSpawn;

    [Header("Demage Effect")]
    public GameObject DamageEffect;

    private EnemyManager _enemyManager;
    void Start()
    {
        _enemyStat = GetComponent<EnemyStats>();
        _animator = GetComponent<Animator>();
        _itemSpawn = GameObject.FindFirstObjectByType<ItemSpawn>();
        _enemyManager = GameObject.FindFirstObjectByType<EnemyManager>();
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
            Die();
        }

    }

    public void Die()
    {

        ItemDrop();
        MakeExplosionEffect();
        _enemyManager.RemoveEnemy(this.gameObject);
        Destroy(this.gameObject);   
    }

    private void MakeExplosionEffect()
    {
        Instantiate(DamageEffect, this.transform.position, Quaternion.identity);
    }

    public void ItemDrop()
    {
        if (_itemSpawn != null)
        {
            _itemSpawn.SpawnItem(this.transform.position);
        }
    }

}
