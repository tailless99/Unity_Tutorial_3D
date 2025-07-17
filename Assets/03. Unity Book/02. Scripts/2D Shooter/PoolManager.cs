using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : Singleton<PoolManager>
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab;

    protected override void Awake() {
        base.Awake();
        pool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleassObject, OnDestoryObject, maxSize: 100);
    }

    private GameObject CreateObject() {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);

        return obj;
    }

    private void OnGetObject(GameObject obj) {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity= Vector3.zero;

        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }

    private void OnReleassObject(GameObject obj) {
        obj.SetActive(false);
    }

    private void OnDestoryObject(GameObject obj) {
        Destroy(obj);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            var obj = pool.Get(); // Pool에서 오브젝트를 하나 꺼내는 방법
            obj.SetActive(true);
        }
    }
}
