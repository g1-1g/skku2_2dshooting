using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _subBulletPrefab;
    [SerializeField]
    private Transform[] _firePosition;
    [SerializeField]
    private Transform[] _subFirePosition;

    public Vector3 ScaleVector;


    private float _nextFireTime;
    public float FireCooldown;
    public float MinFireCooldown = 0.3f;
    public int SubFireCycle;

    private PlayerStat _playerStat;

    void Start()
    {
        _nextFireTime = 0f;

        FireCooldown = 1;
        SubFireCycle = 20;

        _playerStat = GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {      
        switch(_playerStat.Mode)
        {
            case 1:
                if (Time.time >= _nextFireTime)
                {
                    for (int i = 0; i < _firePosition.Length; i++)
                    {
                        Instantiate(_bulletPrefab, _firePosition[i].position, _firePosition[i].rotation);
                        
                    }
                    for (int i = 0; i < _subFirePosition.Length; i++)
                    {

                        Instantiate(_subBulletPrefab, _subFirePosition[i].position, _subFirePosition[i].rotation);
        

                    }
                    _nextFireTime = Time.time + FireCooldown;
                }

                break;
            case 2:
                if (Input.GetKey(KeyCode.Space) && Time.time >= _nextFireTime)
                {
                    for (int i = 0; i < _firePosition.Length; i++)
                        Instantiate(_bulletPrefab, _firePosition[i].position, _firePosition[i].rotation);

                    for (int i = 0; i < _subFirePosition.Length; i++)
                    {

                        Instantiate(_subBulletPrefab, _subFirePosition[i].position, _subFirePosition[i].rotation);

                    }
                    _nextFireTime = Time.time + FireCooldown;
                }
                
                break;
        }
        
        
    }
    public void UpgradeFireRate(float amount)
    {

        FireCooldown -= amount;
        if (FireCooldown < MinFireCooldown)
        {
            FireCooldown = MinFireCooldown;
        }
        Debug.Log("Fire Rate Upgraded! ");
    }


}
