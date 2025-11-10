using UnityEngine;

public class ItemBasicMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool _isFreeze = true;
    private float _delay = 2f;
    private float _currentTime = 0f;
    private float _speed = 5f;

    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        _currentTime = Time.time;
    }

        // Update is called once per frame
        void Update()
    {
        if (_isFreeze)
        {
            if (Time.time - _currentTime >= _delay)
            {
                _isFreeze = false;
            }
            else
            {
                return;
            }
        }
        if (player == null) return;
        gameObject.transform.Translate((player.transform.position - transform.position).normalized * Time.deltaTime * _speed);
    }
}
