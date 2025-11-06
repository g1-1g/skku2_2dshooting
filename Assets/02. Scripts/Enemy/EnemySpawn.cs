using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject Enemy;


    private Vector3 _leftTop;
    private Vector3 _rightTop;

    public float CooldownTime = 1;
    public float MinCooldownTime = 1f;
    public float MaxCooldownTime = 2f;
    private float _nextSpawnTime = 0f;



    void Start()
    {
        Camera cam = Camera.main;

        _leftTop = cam.ViewportToWorldPoint(new Vector3(0, 1, transform.position.z - cam.transform.position.z)) + Enemy.transform.localScale/2;
        _rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - cam.transform.position.z)) - Enemy.transform.localScale / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > _nextSpawnTime)
        {
            CooldownTime = Random.Range(MinCooldownTime, MaxCooldownTime);
            Instantiate(Enemy, new Vector2(Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
            _nextSpawnTime = Time.time + CooldownTime;
        }
            
    }
}
