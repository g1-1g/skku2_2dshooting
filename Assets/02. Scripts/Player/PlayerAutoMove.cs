using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{

    private PlayerStat _playerStat;
    
    private EnemyManager _enemyManager;

    [Header("이동 제한 영역")]
    public float MinX = -8f; // 예시 값
    public float MaxX = 8f;  // 예시 값
    public float MinY = -4f; // 예시 값
    public float MaxY = 4f;  // 예시 값

    [Header("자동 모드")]
    private float _keepDistance = 7f;

    [Header("오브젝트 크기")]
    private float _objectSize;


    private void Start()
    {
        _playerStat = GetComponent<PlayerStat>();
        _enemyManager = GameObject.FindFirstObjectByType<EnemyManager>();



        Camera cam = Camera.main;

        Vector3 leftBottom = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - cam.transform.position.z));
        Vector3 rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - cam.transform.position.z));

        _objectSize = transform.localScale.x;
        MinX = leftBottom.x;
        MaxX = rightTop.x;
        MinY = leftBottom.y + _objectSize / 2;
        MaxY = 0 - _objectSize / 2;
    }
    
    public void AutoMove()
    {
        Vector2 position = transform.position; //현재 위치

        if (_enemyManager.Monsters.Count == 0) return;


        GameObject target = null;
        float closestDist = float.MaxValue;

        foreach (GameObject monster in _enemyManager.Monsters)
        {
            if (monster.transform.position.y < MinY + _objectSize)
                continue;
            float dist = Vector2.SqrMagnitude((Vector2)monster.transform.position - position);
            if (dist < closestDist)
            {
                closestDist = dist;
                target = monster;
            }
        }

        if (target == null) return;

        Vector2 newPosition;
        Vector2 direction = ((Vector2)target.transform.position - position).normalized;
        if (closestDist < _keepDistance)
        {
            direction = -direction;
        }
        else
        {
            direction = direction * Vector2.right;
        }

        newPosition = direction * _playerStat.Speed * Time.deltaTime;

        float nextY = Mathf.Clamp(transform.position.y + newPosition.y, MinY, MaxY);
        float nextX = Mathf.Clamp(transform.position.x + newPosition.x, MinX + _objectSize / 2, MaxX - _objectSize / 2);
        newPosition.y = nextY - transform.position.y;
        newPosition.x = nextX - transform.position.x;

        transform.Translate(newPosition); // 최종 위치 적용

    }
}
