using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    private PlayerStat _playerStat;
    private EnemyManager _enemyManager;


    [Header("시작위치")]
    public Vector3 _originPosition;

    [Header("이동 제한 영역")]
    public float MinX = -8f; // 예시 값
    public float MaxX = 8f;  // 예시 값
    public float MinY = -4f; // 예시 값
    public float MaxY = 4f;  // 예시 값

    [Header("오브젝트 크기")]
    public float objectSize ;

    [Header("자동 모드")]
    private float keepDistance = 7f;
    private Vector2 _moveDir = Vector2.zero;


    private void Start()
    {
        _playerStat = GetComponent<PlayerStat>();
        _enemyManager = GameObject.FindFirstObjectByType<EnemyManager>();

        Camera cam = Camera.main;

        Vector3 leftBottom = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - cam.transform.position.z));
        Vector3 rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - cam.transform.position.z));

        objectSize = transform.localScale.x;
        MinX = leftBottom.x;
        MaxX = rightTop.x;
        MinY = leftBottom.y + objectSize / 2;
        MaxY = 0 - objectSize / 2;


        _playerStat.Speed = Mathf.Clamp(_playerStat.Speed, _playerStat.MinSpeed, _playerStat.MaxSpeed);
        _originPosition = transform.position;
    }

    private void Update()
    {

        switch(_playerStat.Mode)
        {
            case 1:
                AutoMove();
                break;
            case 2:
                BasicMove();
                break;
        }
    }

    private void BasicMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, v);

        direction.Normalize();

        Vector2 position = transform.position; //현재 위치


        Vector2 newPosition = position + direction * _playerStat.Speed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

        //if (newPosition.x < MinX - obejctSize/2)
        //{
        //    newPosition.x = MaxX + obejctSize/2;
        //}
        //if (newPosition.x > MaxX + obejctSize/2)
        //{
        //    newPosition.x = MinX - obejctSize/2;
        //}
        newPosition.x = Mathf.Clamp(newPosition.x, MinX + objectSize / 2, MaxX - objectSize / 2);

        transform.position = newPosition; // 최종 위치 적용


        //원점이동
        if (Input.GetKey(KeyCode.R))
        {
            transform.Translate((_originPosition - transform.position).normalized * _playerStat.Speed * Time.deltaTime);
        }
        ;
    }

    private void AutoMove()
    {
        Vector2 position = transform.position; //현재 위치

        if (_enemyManager.Monsters.Count == 0) return;


        GameObject target = null;
        float closestDist = float.MaxValue;

        foreach (GameObject monster in _enemyManager.Monsters)
        {
            if (monster.transform.position.y < MinY + objectSize) 
                continue;
           float dist = Vector2.SqrMagnitude((Vector2)monster.transform.position- position);
           if (dist < closestDist)
            {
                closestDist = dist;
                target = monster;
            }
        }

        if (target == null) return;

        Vector2 newPosition;
        Vector2 direction = ((Vector2)target.transform.position - position).normalized;
        if (closestDist < keepDistance)
        {
            if (position.y > MaxY- objectSize * 2)
            {
                direction = Vector2.down;
            }
            else
            {
                direction = -direction;
            }   
        }

        //_moveDir = Vector2.Lerp(_moveDir, direction, 0.1f * Time.deltaTime);
        newPosition = direction * _playerStat.Speed * Time.deltaTime;



        float nextY = Mathf.Clamp(transform.position.y + newPosition.y, MinY, MaxY);
        float nextX = Mathf.Clamp(transform.position.x + newPosition.x, MinX + objectSize / 2, MaxX - objectSize / 2);
        newPosition.y = nextY - transform.position.y;
        newPosition.x = nextX - transform.position.x;

        transform.Translate(newPosition); // 최종 위치 적용
      
    }
    

}
