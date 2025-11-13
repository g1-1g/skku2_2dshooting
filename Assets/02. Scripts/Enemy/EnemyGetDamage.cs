using System;
using UnityEngine;

public class EnemyGetDamage : MonoBehaviour
{
    private EnemyStats _enemyStat;
    private Animator _animator;

    [Header("Damage Effect")]
    public GameObject DamageEffect;
   
    private EnemyManager _enemyManager;

    void Start()
    {
        _enemyStat = GetComponent<EnemyStats>();
        _animator = GetComponent<Animator>();
        _enemyManager = GameObject.FindFirstObjectByType<EnemyManager>();
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
        if (gameObject.activeInHierarchy == false ) return;
        EnemyFactory.Instance.ReturnPool(_enemyStat);
    }

    private void MakeExplosionEffect()
    {
        Instantiate(DamageEffect, this.transform.position, Quaternion.identity);
    }

    public void ItemDrop()
    {
        ItemFactory.Instance.SpawnItem(this.transform.position);
    }

}
