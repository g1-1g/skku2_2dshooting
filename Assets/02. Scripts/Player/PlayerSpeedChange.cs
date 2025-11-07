using UnityEngine;

public class PlayerSpeedChange : MonoBehaviour
{
    private PlayerStat _playerStat;

    public float TempSpeed;
    public float Rush = 2f;

    
    public float SpeedChangeAmount = 1f; // 속도 변경량

    void Start()
    {
        _playerStat = GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _playerStat.Speed = Mathf.Clamp(_playerStat.Speed + SpeedChangeAmount, _playerStat.MinSpeed, _playerStat.MaxSpeed);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerStat.Speed = Mathf.Clamp(_playerStat.Speed - SpeedChangeAmount, _playerStat.MinSpeed, _playerStat.MaxSpeed);

        }

        if (Input.GetKeyDown((KeyCode.LeftShift)))
        {
            TempSpeed = _playerStat.Speed;
            _playerStat.Speed = _playerStat.Speed * Rush;
        }
        ;
        if (Input.GetKeyUp((KeyCode.LeftShift)))
        {
            _playerStat.Speed = TempSpeed;
        }
        ;

    }
    public void MoveSpeedUp(float amount)
    {
        _playerStat.Speed += amount;
        Debug.Log("Player Speed Up ");
    }


}
