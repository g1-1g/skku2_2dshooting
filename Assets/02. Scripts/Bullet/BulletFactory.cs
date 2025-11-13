using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BulletFactory : MonoBehaviour
{
    static public BulletFactory Instance { get; private set; }
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _subBulletPrefab;
    [SerializeField]
    private GameObject _petBulletPrefab;

    [Header("풀링")]
    [SerializeField]
    private int mainPoolSize = 30;
    private GameObject[] _bulletObjectPool; //탄창

    [SerializeField]
    private int subPoolSize = 30;
    private GameObject[] _subBulletObjectPool;

    [SerializeField]
    private int petPoolSize = 30;
    private GameObject[] _petBulletObjectPool; //탄창


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        PoolInit(mainPoolSize, ref _bulletObjectPool, _bulletPrefab);
        PoolInit(subPoolSize, ref _subBulletObjectPool, _subBulletPrefab);
        PoolInit(petPoolSize, ref _petBulletObjectPool, _petBulletPrefab);
    }
    
    //탄창 초기화
    private void PoolInit(int size, ref GameObject[] pool, GameObject prefab)
    {
        pool = new GameObject[size];
        for (int i = 0; i < size; i++) 
        { 
            GameObject bulletObject = Instantiate(prefab, transform);

            pool[i] = bulletObject;

            bulletObject.SetActive(false);
        }

    }

    public GameObject MakeBullet(Vector3 position)
    {
        //1. 탄창 안에 있는 총알들 중에서
        for (int i = 0; i < mainPoolSize; i++)
        {
            GameObject bulletObject = _bulletObjectPool[i];

            //2. 비활성화된 총알 하나를 찾아
            if (bulletObject.activeInHierarchy == false)
            {
                //3. 비활성화된 총알 하나를 찾아
                bulletObject.transform.position = position;
                bulletObject.SetActive (true);

                return bulletObject;
            }
        }
        return null;
    }
    public GameObject MakeSubBullet(Vector3 position)
    {
        for (int i = 0; i < subPoolSize; i++)
        {
            GameObject bulletObject = _subBulletObjectPool[i];

            if (bulletObject.activeInHierarchy == false)
            {
                bulletObject.transform.position = position;
                bulletObject.SetActive(true);

                return bulletObject;
            }
        }
        return null;
    }

    public GameObject MakePetBullet(Vector3 position)
    {
        for (int i = 0; i < petPoolSize; i++)
        {
            GameObject bulletObject = _petBulletObjectPool[i];

            if (bulletObject.activeInHierarchy == false)
            {
                bulletObject.transform.position = position;
                bulletObject.SetActive(true);

                return bulletObject;
            }
        }
        return null;
    }
}
