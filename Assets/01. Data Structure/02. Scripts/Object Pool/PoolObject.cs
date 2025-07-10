using Unity.VisualScripting;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPoolQueue pool;
    public float bulletSpeed = 70f;

    private void Awake() {
        pool = FindFirstObjectByType<ObjectPoolQueue>();
    }

    private void OnEnable() {
        Invoke("ReturnPool", 3f);
    }

    private void Update() {
        transform.position += Vector3.right * Time.deltaTime * bulletSpeed;
    }
    private void ReturnPool() {
        pool.EnqueueObject(this.gameObject);
    }
}
