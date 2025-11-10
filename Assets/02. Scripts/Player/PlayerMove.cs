using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    private PlayerStat _playerStat;
    private PlayerAutoMove _playerAutoMove;
    private PlayerManualMove _playerManualMove;



    private void Start()
    {
        _playerStat = GetComponent<PlayerStat>();
        _playerAutoMove = GetComponent<PlayerAutoMove>();
        _playerManualMove = GetComponent<PlayerManualMove>();


    }

    private void Update()
    {

        switch(_playerStat.Mode)
        {
            case 1:
                _playerAutoMove.AutoMove();
                break;
            case 2:
                _playerManualMove.BasicMove();
                break;
        }
    }

    



}
