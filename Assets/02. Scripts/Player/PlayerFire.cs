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
    public int AttackMode = 1;

    private float nextFireTime;
    public float FireCooldown = 0.6f;

    void Start()
    {
        nextFireTime = 0f;
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
                        Instantiate(bulletPrefab, firePosition[i].position, firePosition[i].rotation);
                    for (int i = 0; i < subFirePosition.Length; i++)
                        Instantiate(subBulletPrefab, subFirePosition[i].position, subFirePosition[i].rotation);

                    nextFireTime = Time.time + FireCooldown;
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
                {
                    for (int i = 0; i < firePosition.Length; i++)
                        Instantiate(bulletPrefab, firePosition[i].position, firePosition[i].rotation);
                    for (int i = 0; i < subFirePosition.Length; i++)
                        Instantiate(subBulletPrefab, subFirePosition[i].position, subFirePosition[i].rotation);
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
