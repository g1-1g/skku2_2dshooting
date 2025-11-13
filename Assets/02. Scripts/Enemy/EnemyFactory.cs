using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private GameObject[] _enemyobjectPool;
    private int _enemyPoolSize = 30;

    private void Awake()
    {
        PoolInit(_enemyPoolSize, ref _enemyobjectPool, _enemyPrefab);
    }

    private void PoolInit(int size, ref GameObject[] pool, GameObject prefab)
    {
        pool = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            GameObject enemyObject = Instantiate(prefab, transform);

            pool[i] = enemyObject;

            enemyObject.SetActive(false);
        }
    }

}
