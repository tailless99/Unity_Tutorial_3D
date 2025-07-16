using UnityEngine;

public class LocalData : MonoBehaviour
{
    private int score;

    private void Start() {
        
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            score++;

            // 로컬 데이터 저장
            PlayerPrefs.SetInt("Score", score);
            int loadScore = PlayerPrefs.GetInt("Score");
        }
    }
}
