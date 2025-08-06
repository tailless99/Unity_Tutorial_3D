using Unity.Collections;
using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    private int number = 1;

    private void Start() {
        NomalParameter(number);

        DefaultParameter(); // 디폴트 값 적용됨
        DefaultParameter(5);// 입력한 숫자값이 적용됨

        ReferenceParameter(ref number); // 변수의 주소값을 받아서 그곳에 변경된 값을 적용
        OutParameter(out number); // return 과 유사함. 매개변수를 반환한다.
    }

    // 일반적인 매개변수 -> Call by Value
    private void NomalParameter(int num) {
        number = num;
    }

    // 선택적 매개변수 (Default 매개 변수)
    private void DefaultParameter(int num = 3) {
        number = num;
    }

    // 오버로딩 : 매개변수를 다르게 해서 다른 기능을 구현하는 방법
    private void OVerloadingMethod() { Debug.Log("기능 A"); }
    private void OVerloadingMethod(int num) { Debug.Log("기능 B"); }
    private void OVerloadingMethod(float num) { Debug.Log("기능 C"); }
    private void OVerloadingMethod(bool isNum) { Debug.Log("기능 D"); }
    private void OVerloadingMethod(int num1, int num2) { Debug.Log("기능 E"); }


    // 참조 방식의 매개변수 -> Call by Reference
    // 파라매터 변수에 대한 수정의 개념
    private void ReferenceParameter(ref int num) {
        num = 10;
    }

    // 매개 변수에 값을 전달
    // 파라메터 변수를 반환하는 개념
    private void OutParameter(out int num) {
        num = 30;
    }

    // Collection을 매개변수로 넣은 경우
    private void ArrayParameter(int[] numbers) {
        foreach(var n in numbers) {
            Debug.Log(n);
        }
    }

    // params를 활용한 매개변수
    private void ParamsParameter(params int[] numbers) {
        foreach(var n in numbers) {
            Debug.Log(n);
        }
    }
}
