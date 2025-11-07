using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("생명")]
    private int _lifeChance = 3;
    private int _lifeMaxChance = 5;
    public int LifeChance { get { return _lifeChance; } set { _lifeChance = value; } }


    [Header("속도 조절 관련 속성")]
    private float _speed = 3;
    public float Speed { get { return _speed; } set { _speed = value; } }


    private float _minSpeed = 1f;
    private float _maxSpeed = 10f;
    public float MinSpeed { get { return _minSpeed;  } set { _minSpeed = value;  } } // 최소 속도
    public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = value; } } // 최대 속도

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
