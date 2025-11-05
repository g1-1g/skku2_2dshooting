using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    // Update is called once per frame
    // 목표
    // "키보드 입력"에 따라 "방향"을 구하고 그 방향으로 이동시키고 싶다.

    // 1. 키보드 입력
    // 2. 방향 구하는 방법
    // 3. 이동


    // 필요 속성
    public float Speed = 3;
    public float TempSpeed;
    public int LifeChance = 3;

    public float Rush = 2f;


    [Header("시작위치")]
    public Vector3 _originPosition;

    [Header("이동 제한 영역")]
    // 이동 제한 영역 (인스펙터에서 값 조절 필요)
    public float MinX = -8f; // 예시 값
    public float MaxX = 8f;  // 예시 값
    public float MinY = -4f; // 예시 값
    public float MaxY = 4f;  // 예시 값

    // 속도 조절 관련 속성
    public float MinSpeed = 1f; // 최소 속도
    public float MaxSpeed = 10f; // 최대 속도
    public float SpeedChangeAmount = 1f; // 속도 변경량



    public float obejctSize ; //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 게임 오브젝트가 게임을 시작할 때
    private void Start()
    {
        Camera cam = Camera.main;

        Vector3 leftBottom = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - cam.transform.position.z));
        Vector3 rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - cam.transform.position.z));

        obejctSize = transform.localScale.x;
        MinX = leftBottom.x;
        MaxX = rightTop.x;
        MinY = leftBottom.y + obejctSize/2;
        MaxY = 0- obejctSize/2;


        Speed = Mathf.Clamp(Speed, MinSpeed, MaxSpeed);
        _originPosition = transform.position;
    }

    private void Update()
    {

        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical"); 

        Vector2 direction = new Vector2(h, v);

        direction.Normalize();

        Vector2 position = transform.position; //현재 위치


        Vector2 newPosition = position + direction * Speed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

        if (newPosition.x < MinX - obejctSize/2)
        {
            newPosition.x = MaxX + obejctSize/2;
        }
        if (newPosition.x > MaxX + obejctSize/2)
        {
            newPosition.x = MinX - obejctSize/2;
        }

        transform.position = newPosition; // 최종 위치 적용

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed = Mathf.Clamp(Speed + SpeedChangeAmount, MinSpeed, MaxSpeed);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed = Mathf.Clamp(Speed - SpeedChangeAmount, MinSpeed, MaxSpeed);

        }

        if (Input.GetKeyDown((KeyCode.LeftShift)))
        {
            TempSpeed = Speed;
            Speed = Speed * Rush;
        };
        if (Input.GetKeyUp((KeyCode.LeftShift)))
        {
            Speed = TempSpeed;
        };
        
        //원점이동
        if (Input.GetKey(KeyCode.R))
        { 
            transform.Translate((_originPosition - transform.position).normalized * Speed * Time.deltaTime);
        };

        
        
     
    }
    public void Hit()
    {
        LifeChance -= 1;
        if (LifeChance > 0)
        {
            Debug.Log("Player Life Chance: " + LifeChance);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Player Die");
        }

    }
}
