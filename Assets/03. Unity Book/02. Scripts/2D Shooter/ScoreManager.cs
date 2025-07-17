using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    public int currentScore = 0;
    public int bestScore = 0;

    public int Score {
        get { return currentScore; }
        set { 
            currentScore = value;
            currentScoreUI.text = "���� ���� : " + currentScore;

            if (currentScore > bestScore) {
                bestScore = currentScore;
                bestScoreUI.text = "�ְ� ���� : " + bestScore;

                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }

    private void Start() {
        currentScoreUI.text = "���� ���� : " + currentScore;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }
}
