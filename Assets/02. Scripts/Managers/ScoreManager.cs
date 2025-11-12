using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text _currentScoreTextUI;
    private int _currentScore = 0;

    private const string _scoreKey = "currentScore";
    void Start()
    {
        _currentScore = AccrueScoreGet();
        Refresh(); 
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha9)) ResetScore();
    }

    public void ScoreUp(int score)
    {
        _currentScore += score;
        AccrueScoreSet(_currentScore);
        Refresh();
    }

    private void Refresh()
    {
        _currentScoreTextUI.text = $"현재 점수 : {_currentScore.ToString("#,0")}";
    }

    private void AccrueScoreSet(int Score)
    {
        PlayerPrefs.SetInt(_scoreKey, Score);
        Debug.Log("저장했습니다.");
    }

    private int AccrueScoreGet()
    {
        return PlayerPrefs.GetInt(_scoreKey, 0);
    }
    
    private void ResetScore()
    {
        PlayerPrefs.SetInt(_scoreKey, 0);
        _currentScore = 0;
        Refresh();
    }
}
