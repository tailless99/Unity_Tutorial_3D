using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePos;

    private void Start() {
        //bulletFactory = Resources.Load<GameObject>("Bullet"); // ���ҽ� �������� �Ѿ� ������ �ε�
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            var bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePos.transform.position; // ��ġ �ʱ�ȭ
            //bullet.transform.rotation = firePos.transform.rotation; // ȸ�� �ʱ�ȭ

            // ��ġ�� ȸ���� �Թ��� �����ϴ� ���
            //bullet.transform.SetPositionAndRotation(firePos.transform.position, firePos.transform.rotation);
            // �θ� ������Ʈ ����
            //bullet.transform.SetParent(�θ�); 
        }
    }
}
