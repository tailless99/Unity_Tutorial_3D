using UnityEngine;

public class StudyDelegate : MonoBehaviour {
    // Delegate : 대리자
    // 함수 참조 역할

    // 접근제한자 delegate 반환타입 변수명(매개변수)
    public delegate void MyDelegate();
    public MyDelegate myDelegate;
    public MyDelegate onkeyDown;

    public KeyCode keycode = KeyCode.Space;
    private float timer;
    private bool isTimer;

    private void Start() {
        // 옛날 방식
        //myDelegate = new MyDelegate(MethodA); 할당
        //myDelegate(); 사용

        // 표준 사용 방법
        //myDelegate += MethodA; // 할당
        //myDelegate += MethodB; // 할당
        //myDelegate += MethodC; // 할당
        //myDelegate?.Invoke(); // 사용
        
        myDelegate += Respond; // 할당
        myDelegate += StopTimer; // 할당
        myDelegate += StopBomb; // 할당
    }

    private void Update() {
        if (isTimer) {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown(keycode)) {
            onkeyDown?.Invoke();
        }
    }

    private void Respond() => Debug.Log("키가 눌렸습니다.");
    
    private void StopTimer() {
        isTimer = false;
        Debug.Log("타이머 정지");
    }
    
    private void StopBomb() => Debug.Log("폭탄 정지 기능");

    public void MethodA() => Debug.Log("Method A");
    public void MethodB() => Debug.Log("Method B");
    public void MethodC() => Debug.Log("Method C");
}
