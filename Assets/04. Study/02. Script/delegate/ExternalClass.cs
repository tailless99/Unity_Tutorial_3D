using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    public StudyDelegate studyDelegate;

    private void Start() {
        studyDelegate.onTimerStart += OnLog;
    }

    private void OnLog() {
        Debug.Log("msg");
    }
}
