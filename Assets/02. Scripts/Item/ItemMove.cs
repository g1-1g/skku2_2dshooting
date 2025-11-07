using UnityEngine;

/// 계획(의사코드) - 매우 자세하게 단계별로
/// 1. 시작 위치 p0를 현재 transform.position으로 기록한다.
/// 2. 끝 위치 p2는 아래 방향으로 일정 거리(랜덤 보정 포함)만큼 이동한 위치로 정한다.
/// 3. 변곡점(제어점) p1은 p0과 p2의 중간을 기준으로 수평/수직 오프셋을 랜덤하게 더해 만든다.
///    - 수평 범위와 수직 범위는 직렬화된 필드로 노출해 조정 가능하게 한다.
/// 4. 이동 지속시간(duration)도 직렬화된 필드로 둔다.
/// 5. 매 프레임 t를 Time.deltaTime/duration만큼 증가시키고(0..1), 베지어 방정식으로 위치를 계산해 적용한다.
///    - 2차 베지어: B(t) = (1-t)^2*p0 + 2(1-t)t*p1 + t^2*p2
/// 6. 이동이 끝나면( t >= 1 ) 오브젝트를 파괴하거나 비활성화한다(옵션).
/// 7. 디버깅을 위해 OnDrawGizmosSelected에서 베지어 곡선을 그려준다(선분으로 근사).
/// 8. 필요시 속도/곡률을 바꾸기 위해 duration, horizontalRange, verticalOffsetRange를 노출한다.
///
/// 이제 위 계획을 구현한 코드:
public class ItemMove : MonoBehaviour
{
    [Header("Bezier 이동 설정")]
    [Tooltip("전체 이동에 걸리는 시간(초)")]
    [SerializeField] private float duration = 2.0f;

    [Tooltip("변곡점의 수평 랜덤 범위")]
    [SerializeField] private float horizontalRange = 3f;

    [Tooltip("끝 위치까지의 기본 수직 거리")]
    [SerializeField] private float verticalDistance = 50.0f;

    [Tooltip("끝 위치 수직 거리의 랜덤 보정 범위")]
    [SerializeField] private float verticalRandomness = 1.5f;

    [Tooltip("변곡점의 수직 랜덤 보정 범위 (중간 기준)")]
    [SerializeField] private float controlVerticalRange = 2.0f;

    [Tooltip("곡선 표시를 위한 세그먼트 수")]
    [SerializeField] private int gizmoSegments = 20;

    private Vector3 p0; // 시작점
    private Vector3 p1; // 제어점
    private Vector3 p2; // 끝점
    private float t = 0f;
    private bool started = false;

    private bool _isFreeze = true;
    private float _delay = 2f;
    private float currentTime = 0f;

    void Start()
    {

        currentTime = Time.time;
        InitializeCurve();

    }

    private void InitializeCurve()
    {
        p0 = transform.position;

        // 끝 위치: 아래로 기본 거리 + 랜덤 보정, 약간의 수평 흔들 추가
        float verticalRand = Random.Range(-verticalRandomness, verticalRandomness);
        float endY = p0.y - (verticalDistance + verticalRand);
        float endX = p0.x + Random.Range(-horizontalRange * 0.5f, horizontalRange * 0.5f);
        p2 = new Vector3(endX, endY, p0.z);

        // 제어점: p0-p2 중간을 기준으로 수평/수직 랜덤 오프셋(변곡점)
        Vector3 mid = (p0 + p2) * 0.5f;
        float controlOffsetX = Random.Range(-horizontalRange, horizontalRange);
        float controlOffsetY = Random.Range(-controlVerticalRange, controlVerticalRange);
        p1 = new Vector3(mid.x + controlOffsetX, mid.y + controlOffsetY, mid.z);

        t = 0f;
        started = true;
    }

    void Update()
    {

        if (_isFreeze)
        {
            if (currentTime + _delay <= Time.time)
            {
                _isFreeze = false;

            }
        }

        if (!started || !_isFreeze) return;

        if (duration <= 0f)
        {
            // 즉시 도달
            transform.position = p2;
            OnFinished();
            return;
        }

        t += Time.deltaTime / duration;
        if (t >= 1f)
        {
            transform.position = p2;
            OnFinished();
        }
        else
        {
            transform.position = BezierQuadratic(p0, p1, p2, t);

            // 선택적: 이동 방향으로 회전(2D에서는 z축 회전)
            // Vector3 velocity = BezierQuadraticDerivative(p0, p1, p2, t);
            // float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnFinished()
    {
        // 기본 동작: 오브젝트 파괴
        // 필요하면 풀링/비활성화 로직으로 바꿔라.
        Destroy(gameObject);
    }

    // 2차 베지어 위치 계산
    private Vector3 BezierQuadratic(Vector3 a, Vector3 b, Vector3 c, float tt)
    {
        float u = 1f - tt;
        return u * u * a + 2f * u * tt * b + tt * tt * c;
    }

    // 베지어 1차 미분(속도 벡터) - 주석 처리: 필요하면 사용
    private Vector3 BezierQuadraticDerivative(Vector3 a, Vector3 b, Vector3 c, float tt)
    {
        return 2f * (1f - tt) * (b - a) + 2f * tt * (c - b);
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            // 편집 모드에서도 시작 위치를 기준으로 임시 곡선 그리기
            Vector3 start = transform.position;
            Vector3 end = start + Vector3.down * verticalDistance;
            Vector3 mid = (start + end) * 0.5f;
            Vector3 ctrl = mid + new Vector3(horizontalRange * 0.5f, -controlVerticalRange * 0.2f, 0f);
            DrawQuadraticGizmo(start, ctrl, end);
        }
        else
        {
            // 플레이 중이면 실제 p0/p1/p2를 그린다.
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(p0, 0.05f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(p1, 0.05f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(p2, 0.05f);

            DrawQuadraticGizmo(p0, p1, p2);
        }
    }

    private void DrawQuadraticGizmo(Vector3 a, Vector3 b, Vector3 c)
    {
        Gizmos.color = Color.cyan;
        Vector3 prev = a;
        int segments = Mathf.Max(4, gizmoSegments);
        for (int i = 1; i <= segments; i++)
        {
            float tt = (float)i / segments;
            Vector3 pt = BezierQuadratic(a, b, c, tt);
            Gizmos.DrawLine(prev, pt);
            prev = pt;
        }
    }
#endif
}
