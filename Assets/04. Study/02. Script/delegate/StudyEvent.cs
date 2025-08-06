using UnityEngine;

public class StudyEvent : MonoBehaviour
{
    public delegate void InputKeyHandler();
    public event InputKeyHandler onInputkey;

    private void Start() {
        onInputkey += InputKeyEvent;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            onInputkey?.Invoke();
        }
    }

    private void InputKeyEvent() {
        Debug.Log("key Evnet");
    }
}
