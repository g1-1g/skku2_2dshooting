using System.Collections.Generic;
using UnityEngine;
using static PlayerDie;

public class Pet : MonoBehaviour
{
    private Vector3 _followPos;
    [SerializeField]
    private int followDelay = 110;

    [SerializeField]
    private Transform _parent;
    private Queue<Vector3> parentPos;

    [SerializeField]
    private float _coolTime = 5;

    private float _shootTime = 0;


    private void Awake()
    {
        parentPos = new Queue<Vector3>();
        _shootTime = Time.time;
    }
    void Update()
    {
        Watch();
        Follow();
        Fire();
    }

    void Watch()
    {
        if (!parentPos.Contains(_parent.position))
        {
            parentPos.Enqueue(_parent.position);
        }
            
        if (parentPos.Count > followDelay)
        {
            _followPos = parentPos.Dequeue();
        }else if (parentPos.Count < followDelay)
        {
            _followPos = _parent.position;
        }
    }
    void Follow()
    {
        transform.position = _followPos;
    }
    void Fire()
    {
        if (Time.time > _shootTime + _coolTime)
        {
            BulletFactory.Instance.MakePetBullet(transform.position);
            _shootTime = Time.time;
        }
    }
}
