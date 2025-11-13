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
    private int poolSize = 30;
    private GameObject[] _bulletObjectPool; //탄창

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        PoolInit();
    }
    
    //탄창 초기화
    private void PoolInit()
    {
        _bulletObjectPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++) { 
            GameObject bulletObject = Instantiate(_bulletPrefab, transform);

            _bulletObjectPool[i] = bulletObject;

            bulletObject.SetActive(false);
        }

    }

    public GameObject MakeBullet(Vector3 position)
    {
        //1. 탄창 안에 있는 총알들 중에서
        for (int i = 0; i < poolSize; i++)
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
        return Instantiate(_subBulletPrefab, position, Quaternion.identity, transform);
    }

    public GameObject MakePetBullet(Vector3 position)
    {
        return Instantiate(_petBulletPrefab, position, Quaternion.identity, transform);
    }
}
