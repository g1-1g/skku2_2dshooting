using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject subBulletPrefab;
    [SerializeField]
    private Transform[] firePosition;
    [SerializeField]
    private Transform[] subFirePosition;

    public Vector3 ScaleVector;
    public int AttackMode;

    private float nextFireTime;
    public float FireCooldown;
    public int subFireCycle;


    void Start()
    {
        nextFireTime = 0f;
        AttackMode = 2;
        FireCooldown = 1;
        subFireCycle = 20;
    }

    // Update is called once per frame
    void Update()
    {      
        switch(AttackMode)
        {
            case 1:
                if (Time.time >= nextFireTime)
                {
                    for (int i = 0; i < firePosition.Length; i++)
                    {
                        Instantiate(bulletPrefab, firePosition[i].position, firePosition[i].rotation);
                        
                    }
                    for (int i = 0; i < subFirePosition.Length; i++)
                    {

                        for (int j = 0; j <= 360; j = j + subFireCycle)
                        {
                            GameObject subBullet = Instantiate(subBulletPrefab, subFirePosition[i].position, subFirePosition[i].rotation);
                            subBullet.transform.Rotate(0, 0, j);
                        }
                        
                    }
                    nextFireTime = Time.time + FireCooldown;
                }
                /*for (int i = 0; i < subFirePosition.Length; i++)
                {
                    if (_subFireRotation >= 360)
                        _subFireRotation = 0;
                    GameObject subBullet = Instantiate(subBulletPrefab, subFirePosition[i].position, subFirePosition[i].rotation);
                    subBullet.transform.Rotate(0, 0, _subFireRotation);
                    _subFireRotation += 5;
                }*/
                break;
            case 2:
                if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
                {
                    for (int i = 0; i < firePosition.Length; i++)
                        Instantiate(bulletPrefab, firePosition[i].position, firePosition[i].rotation);
                    //for (int i = 0; i < subFirePosition.Length; i++)
                    //    Instantiate(subBulletPrefab, subFirePosition[i].position, subFirePosition[i].rotation);
                    for (int i = 0; i < subFirePosition.Length; i++)
                    {

                        for (int j = 0; j <= 360; j = j + subFireCycle)
                        {
                            GameObject subBullet = Instantiate(subBulletPrefab, subFirePosition[i].position, subFirePosition[i].rotation);
                            subBullet.transform.Rotate(0, 0, j);
                        }

                    }
                    nextFireTime = Time.time + FireCooldown;
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
