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
                        /*for (int j = 0; j <= 360; j = j + SubFireCycle)
                        {
                            GameObject subBullet = Instantiate(_subBulletPrefab, _subFirePosition[i].position, _subFirePosition[i].rotation);
                            subBullet.transform.Rotate(0, 0, j);
                        }*/

                    }
                    _nextFireTime = Time.time + FireCooldown;
                }
                /*for (int i = 0; i < subFirePosition.Length; i++)
                {
                    if (_subFireRotation >= 360)
                        _subFireRotation = 0;
                    GameObject subBullet = Instantiate(_subBulletPrefab, subFirePosition[i].position, subFirePosition[i].rotation);
                    subBullet.transform.Rotate(0, 0, _subFireRotation);
                    _subFireRotation += 5;
                }*/
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
}
