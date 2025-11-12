using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private HashSet<GameObject> _monsters = new HashSet<GameObject>();
    public HashSet<GameObject> Monsters { get { return _monsters; } }
    
    private ScoreManager _scoreManager;

    public int Getscore = 100;
    void Start()
    {
        _scoreManager = GetComponent<ScoreManager>();
    }
    public void AddEnemy(GameObject enemy)
    {
        _monsters.Add(enemy);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        if (_scoreManager != null) _scoreManager.ScoreUp(Getscore);
        _monsters.Remove(enemy);
    }
}
