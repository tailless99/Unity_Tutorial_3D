using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        // 겹친 오브젝트의 레이어가 "DestroyZone"이 아닌 경우에만 파괴
        if (other.gameObject.layer != LayerMask.NameToLayer("DestroyZone")) {
            Destroy(other.gameObject);
        }
    }
}
