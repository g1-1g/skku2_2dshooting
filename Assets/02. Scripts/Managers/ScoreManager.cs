using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text _currentScoreTextUI;
    private int _currentScore = 0;
    void Start()
    {
        Refresh();
    }

    public void ScoreUp(int score)
    {
        _currentScore += score;
        Refresh();
    }

    private void Refresh()
    {
        _currentScoreTextUI.text = $"현재 점수 : {_currentScore}";
    }
}
