using UnityEngine;
using Redcode.Pools;

public enum EEnemyType
{
    Direction,
    Following,
    Faster
}
public class EnemyStats : MonoBehaviour, IPoolObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("스탯")] 
    private float _speed = 2;
    private float _health = 100;

    public string IdName;
    public bool IsReturned;

    public float Speed { get {return _speed; } set { _speed = value; } }
    public float Health { get { return _health; } set { _health = value; } }

    void Start()
    {
        EnemyManager.Instance.AddEnemy(this.gameObject);
    }

    void Init()
    {
        _speed = 2;
        _health = 100;
    }
    public void OnCreatedInPool()
    {

    }

    public void OnGettingFromPool()
    {
        Init();
    }
}
