using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject[] Enemys;



    public float probabilityA = 0.4f;
    public float probabilityB = 0.3f;
    public float probabilityC = 0.3f;


    private Vector3 _leftTop;
    private Vector3 _rightTop;

    public float CooldownTime = 1;
    public float MinCooldownTime = 1f;
    public float MaxCooldownTime = 3f;
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
            CooldownTime = UnityEngine.Random.Range(MinCooldownTime, MaxCooldownTime);

            float rand = UnityEngine.Random.Range(0f, 1f);

            if (rand < probabilityA)
            {
                _leftTop += Enemys[(int)EEnemyType.Direction].transform.localScale / 2;
                _rightTop -= Enemys[(int)EEnemyType.Direction].transform.localScale / 2;
                Instantiate(Enemys[(int)EEnemyType.Direction], new Vector2(UnityEngine.Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
            }
            else if (probabilityA < rand & rand < probabilityA+probabilityB)
            {
                _leftTop += Enemys[(int)EnemyType.Following].transform.localScale / 2;
                _rightTop -= Enemys[(int)EnemyType.Following].transform.localScale / 2;
                Instantiate(Enemys[(int)EnemyType.Following], new Vector2(UnityEngine.Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
            }
            else
            {
                _leftTop += Enemys[(int)EnemyType.Faster].transform.localScale / 2;
                _rightTop -= Enemys[(int)EnemyType.Faster].transform.localScale / 2;
                Instantiate(Enemys[(int)EnemyType.Faster], new Vector2(UnityEngine.Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
               
            }


            _nextSpawnTime = Time.time + CooldownTime;
        }
            
    }
}
