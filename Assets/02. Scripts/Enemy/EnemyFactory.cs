using UnityEngine;
using Redcode.Pools;

public class EnemyFactory : MonoBehaviour
{

    private PoolManager _poolManager;

    public static EnemyFactory Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        _poolManager = GetComponent<PoolManager>();
    }

    public void Spawn(int ran, Vector2 pos)
    {
        EnemyStats enemy = _poolManager.GetFromPool<EnemyStats>(ran);
        enemy.transform.position = pos;
    }

    public void ReturnPool(EnemyStats enemy)
    {
        _poolManager.TakeToPool<EnemyStats>(enemy.IdName, enemy);
    }
}
