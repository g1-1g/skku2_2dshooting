using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField]
    public GameObject _bulletPrefab;

    private Vector3 _followPos;
    private int followDelay = 5;

    [SerializeField]
    private Transform _parent;
    private Queue<Vector3> parentPos;


    private void Awake()
    {
        parentPos = new Queue<Vector3>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        Watch();
        Follow();
    }

    void Watch()
    {
        parentPos.Enqueue(_parent.position);

        _followPos = parentPos.Dequeue();
    }
    void Follow()
    {
        transform.position = _followPos;
    }

}
