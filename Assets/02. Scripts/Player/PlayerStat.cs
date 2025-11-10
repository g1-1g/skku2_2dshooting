using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("생명")]
    private int _lifeChance = 3;
    private int _lifeMaxChance = 5;
    public int LifeChance { get { return _lifeChance; } set { _lifeChance = value; } }


    [Header("속도 조절 관련 속성")]
    private float _speed = 2;
    public float Speed { get { return _speed; } set { _speed = value; } }

    private int _mode = 2; // 1: 오토, 2: 조작
    public int Mode { get { return _mode; } set { _mode = value; } }

    private float _minSpeed = 1f;
    private float _maxSpeed = 10f;
    public float MinSpeed { get { return _minSpeed;  } set { _minSpeed = value;  } } // 최소 속도
    public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = value; } } // 최대 속도

    public void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            _mode = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            _mode = 2;
        }

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
    public void LifeChaceUp()
    {
        if (_lifeChance <= _lifeMaxChance)
        {
            _lifeChance += 1;
            Debug.Log("Player Life Chance Up: " + _lifeChance);
        }
        
    }


}
