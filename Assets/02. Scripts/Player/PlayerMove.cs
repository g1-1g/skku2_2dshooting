using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{


    // 필요 속성
    private float _speed = 3;
    public float Speed { get { return _speed; } set { _speed = value; } }

    public float TempSpeed;

    private int _lifeChance = 3;
    public int LifeChance { get { return _lifeChance; } set { _lifeChance = value; } }


    public float Rush = 2f;


    [Header("시작위치")]
    public Vector3 _originPosition;

    [Header("이동 제한 영역")]
    public float MinX = -8f; // 예시 값
    public float MaxX = 8f;  // 예시 값
    public float MinY = -4f; // 예시 값
    public float MaxY = 4f;  // 예시 값


    [Header("속도 조절 관련 속성")]
    public float MinSpeed = 1f; // 최소 속도
    public float MaxSpeed = 10f; // 최대 속도
    public float SpeedChangeAmount = 1f; // 속도 변경량



    public float obejctSize ; //

  
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


        _speed = Mathf.Clamp(_speed, MinSpeed, MaxSpeed);
        _originPosition = transform.position;
    }

    private void Update()
    {

        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical"); 

        Vector2 direction = new Vector2(h, v);

        direction.Normalize();

        Vector2 position = transform.position; //현재 위치


        Vector2 newPosition = position + direction * _speed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

        //if (newPosition.x < MinX - obejctSize/2)
        //{
        //    newPosition.x = MaxX + obejctSize/2;
        //}
        //if (newPosition.x > MaxX + obejctSize/2)
        //{
        //    newPosition.x = MinX - obejctSize/2;
        //}
        newPosition.x = Mathf.Clamp(newPosition.x, MinX + obejctSize / 2 , MaxX - obejctSize / 2);

        transform.position = newPosition; // 최종 위치 적용

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _speed = Mathf.Clamp(_speed + SpeedChangeAmount, MinSpeed, MaxSpeed);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _speed = Mathf.Clamp(_speed - SpeedChangeAmount, MinSpeed, MaxSpeed);

        }

        if (Input.GetKeyDown((KeyCode.LeftShift)))
        {
            TempSpeed = _speed;
            _speed = _speed * Rush;
        };
        if (Input.GetKeyUp((KeyCode.LeftShift)))
        {
            _speed = TempSpeed;
        };
        
        //원점이동
        if (Input.GetKey(KeyCode.R))
        { 
            transform.Translate((_originPosition - transform.position).normalized * _speed * Time.deltaTime);
        };

        
        
     
    }
    public void Hit()
    {
        _lifeChance -= 1;
        if (_lifeChance > 0)
        {
            Debug.Log("Player Life Chance: " + _lifeChance);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Player Die");
        }

    }

    public void MoveSpeedUp(float amount)
    {
        _speed += amount;
        Debug.Log("Player Speed Up ");
    }

    public void LifeChaceUp()
    {
        _lifeChance += 1;
        Debug.Log("Player Life Chance Up: " + _lifeChance);
    }



}
