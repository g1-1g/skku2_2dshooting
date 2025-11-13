using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text _currentScoreTextUI;

    [SerializeField]
    private Text _BestScoreTextUI;

    private int _currentScore = 0;
    private int _bestScore = 0;

    private Coroutine _currentScoreAnim;
    private Coroutine _bestScoreAnim;

    private const string _bestScoreKey = "bestScore";

    void Start()
    {
        _bestScore = BestScoreGet();
        Refresh();
        BestScoreRefresh(); 
    }


    public void ScoreUp(int score)
    {
        _currentScore += score;
        Refresh();
        RefreshEffect(_currentScoreTextUI);

        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            RefreshEffect(_BestScoreTextUI);
            BestScoreSet(_currentScore);
            BestScoreRefresh();
        }
    }

    private void Refresh()
    {
        _currentScoreTextUI.text = $"{_currentScore.ToString("#,0")}";
    }

    private void BestScoreRefresh()
    {
        BestScoreSet(_bestScore);
        _BestScoreTextUI.text = $"{_bestScore.ToString("#,0")}";
    }

    private void BestScoreSet(int Score)
    {
        PlayerPrefs.SetInt(_bestScoreKey, Score);
        Debug.Log("저장했습니다.");
    }

    private int BestScoreGet()
    {
        return PlayerPrefs.GetInt(_bestScoreKey, 0);
    }

    private void RefreshEffect(Text textUI)
    {
        textUI.rectTransform.DOPunchScale(Vector2.one * 0.2f, 0.3f, 1, 0.5f);
    }
}
