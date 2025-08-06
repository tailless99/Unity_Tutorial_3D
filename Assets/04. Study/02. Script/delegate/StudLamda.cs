using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StudLamda : MonoBehaviour
{
    public delegate void MyDelegate(string s);
    public MyDelegate myDelegate;

    public Button button;

    private void Start() {
        // 버튼에 1개의 기능을 등록하는 방법
        button.onClick.AddListener(ButtonEvent);

        // 익명함수로 여러 기능을 등록하는 방법
        button.onClick.AddListener(delegate {
            ButtonEvent();
            OnLog("Lanmda");
        });

        // 람다식으로 1개의 기능을 등록하는 방법
        button.onClick.AddListener(() => OnLog("Hello"));
    }

    private void ButtonEvent() {
        Debug.Log("Hello unity");
    }

    private void OnLog(string s) {
        Debug.Log("Hello unity");
    }
}
