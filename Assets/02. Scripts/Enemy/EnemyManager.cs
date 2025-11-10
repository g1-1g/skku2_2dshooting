using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private HashSet<GameObject> _monsters = new HashSet<GameObject>();
    public HashSet<GameObject> Monsters { get { return _monsters; } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void AddEnemy(GameObject enemy)
    {
        _monsters.Add(enemy);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        _monsters.Remove(enemy);
    }
}
