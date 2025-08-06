using UnityEngine;

namespace Patten {
    public class Pattern : MonoBehaviour {
        public class ScoreManager : MonoBehaviour {

            private void OnEnable() {
                StudyEventBus.onScoreChange += UpdateScore;
            }

            private void OnDisable() {
                StudyEventBus.onScoreChange -= UpdateScore;
            }

            private void UpdateScore(int newScore) {
                Debug.Log($"현재 점수 : {newScore}");
            }
        }
    }
}