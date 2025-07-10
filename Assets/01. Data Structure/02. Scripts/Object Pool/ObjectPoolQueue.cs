using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>(); // 오브젝트들이 들어갈 큐
    
    public GameObject objPrefab; // 생성할 오브젝트
    public Transform parent; // 계층 구조상 들어갈 부모 오브젝트

    private void Start() {
        CreateObject();
    }

    private void CreateObject() { // 오브젝트를 생성하는 기능 -> Pool를 채우는 기능
        for(int i = 0; i < 30; i++) {
            GameObject obj = Instantiate(objPrefab, parent); // 오브젝트를 생성하고, 계층구조를 parent의 자식으로 변경
            EnqueueObject(obj);
        }
    }

    // 데이터를 넣는 기능
    public void EnqueueObject(GameObject newObj) {
        newObj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        newObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        objQueue.Enqueue(newObj);
        newObj.SetActive(false);
    }

    // 데이터를 꺼내쓰는 기능
    public GameObject DequeueObject() {
        // 갯수가 부족하다면 추가로 생성
        if (objQueue.Count < 10) CreateObject();

        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);
        return obj;
    }
}
