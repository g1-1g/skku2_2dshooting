using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static public EnemyManager Instance { get; private set; }

    private HashSet<GameObject> _monsters = new HashSet<GameObject>();
    public HashSet<GameObject> Monsters { get { return _monsters; } }

    [SerializeField]
    private AudioClip _dieSound;


    public int ScorePerKill = 100;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void AddEnemy(GameObject enemy)
    {
        _monsters.Add(enemy);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        SFXManager.Instance.SoundPlay(_dieSound);
        if (ScoreManager.Instance != null) ScoreManager.Instance.ScoreUp(ScorePerKill);
        _monsters.Remove(enemy);
    }
}
