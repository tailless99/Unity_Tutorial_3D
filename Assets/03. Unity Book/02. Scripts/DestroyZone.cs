using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        // ��ģ ������Ʈ�� ���̾ "DestroyZone"�� �ƴ� ��쿡�� �ı�
        if (other.gameObject.layer != LayerMask.NameToLayer("DestroyZone")) {
            Destroy(other.gameObject);
        }
    }
}
