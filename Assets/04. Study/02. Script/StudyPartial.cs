using UnityEngine;

// 원본 클래스 및 분할된 클래스에서 함수를 가져와서 사용
public partial class StudyPartial : MonoBehaviour
{
    private void Start() {
        MethodA();
        MethodB();
    }
}

// 클래스를 분리할 수 있다.
public partial class StudyPartial : MonoBehaviour {
    private void MethodA() {
        Debug.Log("Method A");
    }

    private void MethodB() {
        Debug.Log("Method B");
    }
}