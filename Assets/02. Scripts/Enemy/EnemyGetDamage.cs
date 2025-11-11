using System;
using UnityEngine;

public class EnemyGetDamage : MonoBehaviour
{
    private EnemyStats _enemyStat;
    private Animator _animator;

    private ItemSpawn _itemSpawn;

    [Header("Demage Effect")]
    public GameObject DamageEffect;

    void Start()
    {
        _enemyStat = GetComponent<EnemyStats>();
        _animator = GetComponent<Animator>();
        _itemSpawn = GameObject.FindFirstObjectByType<ItemSpawn>();
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
