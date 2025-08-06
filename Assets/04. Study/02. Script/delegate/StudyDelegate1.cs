using UnityEngine;

public class StudyDelegate1 : MonoBehaviour
{
    public delegate void TimerStart();
    public TimerStart onTimerStart;

    public delegate void TimerEnd();
    public TimerEnd onTImerEnd;

    private float timer = 5f;
    private bool isTimer = true;

    private void Start() {
        onTimerStart?.Invoke();
    }

    private void OnEnable() {
        onTimerStart += StartEvent;
        onTImerEnd += EndEvent;
    }

    private void OnDisable() {
        onTimerStart -= StartEvent;
        onTImerEnd -= EndEvent;
    }

    private void Update() {
        if (!isTimer) return;

        timer -= Time.deltaTime;

        if(timer <= 0f) {
            isTimer = false;
            onTImerEnd?.Invoke();
        }
    }

    private void StartEvent() {
        Debug.Log("타이머 시작");
    }
    
    private void EndEvent() {
        Debug.Log("타이머 종료");
    }
}
