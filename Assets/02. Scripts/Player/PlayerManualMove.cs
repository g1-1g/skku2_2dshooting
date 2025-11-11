using UnityEngine;

public class PlayerManualMove : MonoBehaviour
{

    private PlayerStat _playerStat;
    private Animator _animator;

    [Header("이동 제한 영역")]
    public float MinX = -8f; // 예시 값
    public float MaxX = 8f;  // 예시 값
    public float MinY = -4f; // 예시 값
    public float MaxY = 4f;  // 예시 값

    [Header("시작위치")]
    private Vector3 _originPosition;

    [Header("오브젝트 크기")]
    private float _objectSize;
    void Start()
    {
        _playerStat = GetComponent<PlayerStat>();
        _animator = GetComponent<Animator>();

        Camera cam = Camera.main;

        Vector3 leftBottom = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - cam.transform.position.z));
        Vector3 rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - cam.transform.position.z));

        _objectSize = transform.localScale.x;
        MinX = leftBottom.x;
        MaxX = rightTop.x;
        MinY = leftBottom.y + _objectSize / 2;
        MaxY = 0 - _objectSize / 2;


        _playerStat.Speed = Mathf.Clamp(_playerStat.Speed, _playerStat.MinSpeed, _playerStat.MaxSpeed);
        _originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h > 0)
            _animator.SetBool("isRight", true);
        else if (h < 0)
            _animator.SetBool("isLeft", true);
        else
        {
            _animator.SetBool("isRight", false);
            _animator.SetBool("isLeft", false);
        }
            

        Vector2 direction = new Vector2(h, v);

        direction.Normalize();

        Vector2 position = transform.position; //현재 위치


        Vector2 newPosition = position + direction * _playerStat.Speed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

        newPosition.x = Mathf.Clamp(newPosition.x, MinX + _objectSize / 2, MaxX - _objectSize / 2);

        transform.position = newPosition; // 최종 위치 적용


        //원점이동
        if (Input.GetKey(KeyCode.R))
        {
            transform.Translate((_originPosition - transform.position).normalized * _playerStat.Speed * Time.deltaTime);
        }
        ;
    }
}
