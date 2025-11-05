using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainBullet : Bullet
{

    // 지그재그 설정 (모두 동일하게 적용)
    public float Amplitude = 1.0f;   // 좌우 진폭
    public float Frequency = 4.0f;   // 흔들림 속도 (Hz가 아닌 rad/s 유사값)
    public float Phase = 0f;         // 위상(기본 0, 모든 총알 동일)

    // 내부 상태
    private Vector2 _startPosition;
    private float _verticalOffset = 0f;
    private float _elapsedTime = 0f;


    void Start()
    {
        Demage = 60;
        Speed = 4;
        TargetSpeed = 15f;
        AccelTime = 1.2f;


         Acceleration = (TargetSpeed - Speed) / AccelTime;
        _startPosition = transform.position;
    }

    void Update()
    {
        float dt = Time.deltaTime;

        // 속도 업데이트 (가속 적용)
        Speed = Mathf.Min(Speed + Acceleration * dt, TargetSpeed);

        // 수직 이동량 누적
        _verticalOffset += Speed * dt;

        // 시간 누적(지그재그 계산용)
        _elapsedTime += dt;

        // 사인 함수로 가로 오프셋 계산 (모든 탄환이 동일한 Phase를 사용)
        float xOffset = Mathf.Sin(_elapsedTime * Frequency + Phase) * Amplitude;

        // 최종 위치 계산 및 적용 (월드 좌표 기준으로 위로 이동하면서 좌우 흔들림)
        Vector2 newPosition = _startPosition + Vector2.up * _verticalOffset + Vector2.right * xOffset;
        transform.position = newPosition;
    }


    
}
