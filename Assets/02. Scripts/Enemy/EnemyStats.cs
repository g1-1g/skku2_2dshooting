using System;
using JetBrains.Annotations;
using UnityEngine;


public enum EEnemyType
{
    Direction,
    Following,
    Faster
}
public class EnemyStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("스탯")]
    private float _speed = 2;

    private float _health = 100;
    

    public float Speed { get {return _speed; } set { _speed = value; } }
    public float Health { get { return _health; } set { _health = value; } }
    private EnemyManager EnemyManager;

    private void Awake()
    {
    }
    void Start()
    {
        EnemyManager = GameObject.FindFirstObjectByType<EnemyManager>();
        EnemyManager.AddEnemy(this);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        EnemyManager.RemoveEnemy(this);
    }
}
