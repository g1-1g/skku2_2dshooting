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
    public int AttackMode;

    private float _nextFireTime;
    public float FireCooldown;
    public int SubFireCycle;


    void Start()
    {
        _nextFireTime = 0f;
        AttackMode = 2;
        FireCooldown = 1;
        SubFireCycle = 20;
    }

    // Update is called once per frame
    void Update()
    {      
        switch(AttackMode)
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
        if (Input.GetKeyDown("1"))
        {
            AttackMode = 1;  
        }
        if (Input.GetKeyDown("2"))
        {
            AttackMode = 2;
        }

        
    }
    public void UpgradeFireRate(float amount)
    {
        FireCooldown -= amount;
        if (FireCooldown < 0.1f)
        {
            FireCooldown = 0.1f;
        }
        Debug.Log("Fire Rate Upgraded! ");
    }


}
