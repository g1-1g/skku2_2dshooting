using UnityEngine;

public class PlayerMove : MonoBehaviour
{



    // Update is called once per frame
    // 목표
    // "키보드 입력"에 따라 "방향"을 구하고 그 방향으로 이동시키고 싶다.

    // 1. 키보드 입력
    // 2. 방향 구하는 방법
    // 3. 이동


    // 필요 속성
    public float speed = 3; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 게임 오브젝트가 게임을 시작할 때
    private void Start()
    {

    }

    private void Update()
    {
        //1. 키보드 입력을 감지한다.
        // 유니티에는 Input 이라고 하는 모듈이 입력에 대한 모든 것을 담당한다.
        float h = Input.GetAxis("Horizontal"); // 수평 입력에 대한 값을 -1, 0, 1로 가져온다.
        float v = Input.GetAxis("Vertical"); // 수직 입력에 대한 값을 -1, 0, 1로 가져온다.

        Debug.Log($"h : {h}, v : {v}");

        // 2. 입력으로부터 방향을 구한다.
        Vector2 direction = new Vector2(h, v);

        // 3. 그 방향으로 이동 한다
        Vector2 position = transform.position; //현재 위치


        // 새로운 위치 = 현재 위치 + 속도 + 시간 (방향 * 속력 * 시간)
        Vector2 newPosition = position + direction*speed * Time.deltaTime;


          /*  delta: 얼마나 변화했나. 이전 프레임부터 현재 프레임까지 시간이 얼마나 흘렀는지 나타내는 것

        이동속도가 10일 때

        컴퓨터1은 50FPS: update → 초당 50번 실행 → 10 * 50 = 500

        컴퓨터2는 100FPS: update → 초당 100번 실행 → 10 * 100 = 1000

        * *⇒ 보간이 필요!**

        Time.deltaTime(1초 / fps)을 곱해주면 두 개의 값이 같아진다.*/
        transform.position = newPosition;
    }
}
