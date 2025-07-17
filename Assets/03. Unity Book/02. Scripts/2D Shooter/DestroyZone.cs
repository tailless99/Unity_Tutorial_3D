using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Contains("Bullet")) {
            // PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else {
            EnemyManager.Instance.enemyPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false); // Enemy 비활성화
        }
    }
}
