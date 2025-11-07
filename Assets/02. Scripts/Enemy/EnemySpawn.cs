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
    private Vector3 _spawnLeftTop;
    private Vector3 _spawnRightTop;

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
                _spawnLeftTop = _leftTop + Enemys[(int)EEnemyType.Direction].transform.localScale / 2;
                _spawnRightTop =  _rightTop - Enemys[(int)EEnemyType.Direction].transform.localScale / 2;
                Instantiate(Enemys[(int)EEnemyType.Direction], new Vector2(UnityEngine.Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
            }
            else if (probabilityA < rand & rand < probabilityA+probabilityB)
            {
                _spawnLeftTop = _leftTop + Enemys[(int)EEnemyType.Following].transform.localScale / 2;
                _spawnRightTop = _rightTop - Enemys[(int)EEnemyType.Following].transform.localScale / 2;
                Instantiate(Enemys[(int)EEnemyType.Following], new Vector2(UnityEngine.Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
            }
            else
            {
                _spawnLeftTop = _leftTop + Enemys[(int)EEnemyType.Faster].transform.localScale / 2;
                _spawnRightTop = _rightTop - Enemys[(int)EEnemyType.Faster].transform.localScale / 2;
                Instantiate(Enemys[(int)EEnemyType.Faster], new Vector2(UnityEngine.Random.Range(_leftTop.x, _rightTop.x), transform.position.y), transform.rotation);
               
            }


            _nextSpawnTime = Time.time + CooldownTime;
        }
            
    }
}
