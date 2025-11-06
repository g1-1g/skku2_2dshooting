using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject EnemyDirection;
    public GameObject EnemyFollowing;

    public float probabilityA = 0.7f;
    public float probabilityB = 0.3f;


    private Vector3 _leftTop;
    private Vector3 _rightTop;

    public float CooldownTime = 1;
    public float MinCooldownTime = 1f;
    public float MaxCooldownTime = 2f;
    private float _nextSpawnTime = 0f;



    void Start()
    {
        Camera cam = Camera.main;

        _leftTop = cam.ViewportToWorldPoint(new Vector3(0, 1, transform.position.z - cam.transform.position.z));
        _rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - cam.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > _nextSpawnTime)
        {
            CooldownTime = Random.Range(MinCooldownTime, MaxCooldownTime);

            float rand = Random.Range(0f, 1f);
            if (rand < probabilityA)
            {
                _leftTop += EnemyDirection.transform.localScale / 2;
                _rightTop -= EnemyDirection.transform.localScale / 2;
                Instantiate(EnemyDirection, new Vector2(Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
            }
            else if (rand > probabilityA)
            {
                _leftTop += EnemyFollowing.transform.localScale / 2;
                _rightTop -= EnemyFollowing.transform.localScale / 2;
                Instantiate(EnemyFollowing, new Vector2(Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
            }
                
               
            _nextSpawnTime = Time.time + CooldownTime;
        }
            
    }
}
