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

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    public GameObject MakeBullet(Vector3 position)
    {
        return Instantiate(_bulletPrefab, position, Quaternion.identity, transform);
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
