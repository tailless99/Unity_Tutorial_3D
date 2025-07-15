using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private void Update() {
        // 월드 방향 이동
        transform.position += Vector3.forward * 5 * Time.deltaTime;

        // 로컬 이동
        transform.Translate(Vector3.right * 5 * Time.deltaTime); // Space.Self

        // 월드 방향 이동
        transform.Translate(Vector3.right * 5 * Time.deltaTime, Space.World);

        // 회전 - 쿼터니언과 오일러
        transform.rotation = Quaternion.identity; // (0, 0, 0)
        transform.rotation = Quaternion.Euler(new Vector3(30,60,120)); // 오일러 각을 쿼터니언으로 변환

        // 쿼터니언 -> 오일러 변환
        var newRotation = transform.rotation.eulerAngles + (Vector3.up * 5 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(newRotation);

        // 회전 함수들
        transform.Rotate(Vector3.up * 5 * Time.deltaTime); // Space.Self
        transform.Rotate(Vector3.up * 5 * Time.deltaTime, Space.World);
        transform.RotateAround(Vector3.zero, Vector3.up, 5 * Time.deltaTime);
        transform.LookAt(Vector3.zero); // 특정 방향을 바라보기


        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("마우스 왼쪽 버튼 클릭");
        }

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("마우스 왼쪽 버튼 클릭");
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("스페이스 키 클릭");
        }
    }
}
