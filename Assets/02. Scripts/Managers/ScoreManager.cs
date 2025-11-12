using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

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

        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            BestScoreSet(_currentScore);
            BestScoreRefresh();
        }
    }

    private void Refresh()
    {
        RefreshEffect(_currentScoreTextUI);
        _currentScoreTextUI.text = $"{_currentScore.ToString("#,0")}";
    }

    private void BestScoreRefresh()
    {
        BestScoreSet(_bestScore);
        RefreshEffect(_BestScoreTextUI);
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
        if (textUI == _currentScoreTextUI)
        {
            if (_currentScoreAnim != null) StopCoroutine(_currentScoreAnim);
            _currentScoreAnim = StartCoroutine(ScaleEffect(textUI));
        }
        else if (textUI == _BestScoreTextUI)
        {
            if (_bestScoreAnim != null) StopCoroutine(_bestScoreAnim);
            _bestScoreAnim = StartCoroutine(ScaleEffect(textUI));
        }
    }

    private IEnumerator ScaleEffect(Text textUI)
    {
        var rect = textUI.rectTransform;
        Vector3 start = Vector3.one;
        Vector3 big = Vector3.one * 1.2f;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 6f;
            rect.localScale = Vector3.Lerp(start, big, t);
            yield return null;
        }

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 6f;
            rect.localScale = Vector3.Lerp(big, start, t);
            yield return null;
        }

        rect.localScale = Vector3.one;
    }
}
