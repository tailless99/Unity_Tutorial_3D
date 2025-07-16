using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    public int currentScore = 0;
    public int bestScore = 0;

    private void Start() {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }

    public void SetScore(int value) {
        currentScoreUI.text = "현재 점수 : " + currentScore;

        if (currentScore > bestScore) {
            bestScore = currentScore;
            bestScoreUI.text = "최고 점수 : " + bestScore;

            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public int GetScore() {
        return currentScore;
    }
}
