using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onUnityEvent;

    private void Start() {
        onUnityEvent.AddListener(delegate {
            Debug.Log("1");
            Debug.Log("2");
            Debug.Log("3");
            MethodA();
            MethodB();
            PrintLog("");
        });
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            onUnityEvent?.Invoke();
        }
    }

    private void MethodA() => Debug.Log("Method A");
    private void MethodB() => Debug.Log("Method B");
    private void PrintLog(string msg) => Debug.Log(msg);
}
