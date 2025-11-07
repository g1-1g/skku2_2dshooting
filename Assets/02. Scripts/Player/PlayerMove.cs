using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    private PlayerStat _playerStat;
    

    [Header("시작위치")]
    public Vector3 _originPosition;

    [Header("이동 제한 영역")]
    public float MinX = -8f; // 예시 값
    public float MaxX = 8f;  // 예시 값
    public float MinY = -4f; // 예시 값
    public float MaxY = 4f;  // 예시 값


    public float obejctSize ; 

  
    private void Start()
    {
        _playerStat = GetComponent<PlayerStat>();

        Camera cam = Camera.main;

        Vector3 leftBottom = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - cam.transform.position.z));
        Vector3 rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - cam.transform.position.z));

        obejctSize = transform.localScale.x;
        MinX = leftBottom.x;
        MaxX = rightTop.x;
        MinY = leftBottom.y + obejctSize/2;
        MaxY = 0- obejctSize/2;


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
        newPosition.x = Mathf.Clamp(newPosition.x, MinX + obejctSize / 2, MaxX - obejctSize / 2);

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
        Vector2 newPosition = position + Vector2.right * _playerStat.Speed * Time.deltaTime;
        


        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);
        if (newPosition.x < MinX - obejctSize / 2)
        {
            newPosition.x = MaxX + obejctSize / 2;
        }
        if (newPosition.x > MaxX + obejctSize / 2)
        {
            newPosition.x = MinX - obejctSize / 2;
        }
        transform.position = newPosition; // 최종 위치 적용
    }

}
