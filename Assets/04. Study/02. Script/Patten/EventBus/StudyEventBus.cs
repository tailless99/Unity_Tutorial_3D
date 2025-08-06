using System;
using UnityEngine;

public class StudyEventBus : MonoBehaviour
{
    public static event Action onStart;
    public static event Action<int> onScoreChange;

    public static void StartEvent() {
        onStart?.Invoke();
    }

    public static void ScoreChanged(int newScore) {
        onScoreChange?.Invoke(newScore);
    }
}
