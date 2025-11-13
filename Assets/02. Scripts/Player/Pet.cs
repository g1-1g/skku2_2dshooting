using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerDie;

public class Pet : MonoBehaviour
{
    [SerializeField]
    public GameObject _bulletPrefab;

    private Vector3 _followPos;
    [SerializeField]
    private int followDelay = 110;

    [SerializeField]
    private Transform _parent;
    private Queue<Vector3> parentPos;


    private void Awake()
    {
        parentPos = new Queue<Vector3>();
    }
    void Update()
    {
        Watch();
        Follow();
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

}
