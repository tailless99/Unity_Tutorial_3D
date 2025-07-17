using UnityEngine;

public class PoolItem : MonoBehaviour
{
    private void OnEnable() {
        Invoke("ReturnObject", 3f);
    }

    private void ReturnObject() {
        PoolManager.Instance.pool.Release(this.gameObject);
    }
}
