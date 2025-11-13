using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField]
    public GameObject _bulletPrefab;

    private Vector3 _followPos;
    private int followDelay = 15;

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
        if (!parentPos.Contains(_parent.position))
            parentPos.Enqueue(_parent.position);


        if (parentPos.Count > followDelay)
        {
            _followPos = parentPos.Dequeue();
        }    
    }
    void Follow()
    {
        transform.position = _followPos;
    }

}
