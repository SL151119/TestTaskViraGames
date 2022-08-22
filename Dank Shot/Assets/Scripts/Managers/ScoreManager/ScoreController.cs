using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("Scores Text")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    [HideInInspector]
    public int _score;

    private int _bestScore;

    private void Start()
    {
        _score = 0;
        _bestScore = PlayerPrefs.GetInt("BestScore");
    }
    public void AddScore(int value)
    {
        _score += value;
        scoreText.text = _score.ToString();
    }

    public void UpdateBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt("BestScore", _bestScore);
        }
        bestScoreText.text = _bestScore.ToString();
    }
}
