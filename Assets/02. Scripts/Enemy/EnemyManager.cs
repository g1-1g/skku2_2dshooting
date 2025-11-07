using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private EnemyStats[] _enermies; 
    public EnemyStats[] Enermies { get { return _enermies; } } 
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void AddEnemy(EnemyStats enemy)
    {
        _enermies = _enermies.Append(enemy).ToArray();
    }
    public void RemoveEnemy(EnemyStats enemy)
    {

    }
}
