using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private void Update() {
        // ���� ���� �̵�
        transform.position += Vector3.forward * 5 * Time.deltaTime;

        // ���� �̵�
        transform.Translate(Vector3.right * 5 * Time.deltaTime); // Space.Self

        // ���� ���� �̵�
        transform.Translate(Vector3.right * 5 * Time.deltaTime, Space.World);

        // ȸ�� - ���ʹϾ�� ���Ϸ�
        transform.rotation = Quaternion.identity; // (0, 0, 0)
        transform.rotation = Quaternion.Euler(new Vector3(30,60,120)); // ���Ϸ� ���� ���ʹϾ����� ��ȯ

        // ���ʹϾ� -> ���Ϸ� ��ȯ
        var newRotation = transform.rotation.eulerAngles + (Vector3.up * 5 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(newRotation);

        // ȸ�� �Լ���
        transform.Rotate(Vector3.up * 5 * Time.deltaTime); // Space.Self
        transform.Rotate(Vector3.up * 5 * Time.deltaTime, Space.World);
        transform.RotateAround(Vector3.zero, Vector3.up, 5 * Time.deltaTime);
        transform.LookAt(Vector3.zero); // Ư�� ������ �ٶ󺸱�


        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("���콺 ���� ��ư Ŭ��");
        }

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("���콺 ���� ��ư Ŭ��");
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("�����̽� Ű Ŭ��");
        }
    }
}
