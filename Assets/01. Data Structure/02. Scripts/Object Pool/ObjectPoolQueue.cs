using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>(); // ������Ʈ���� �� ť
    
    public GameObject objPrefab; // ������ ������Ʈ
    public Transform parent; // ���� ������ �� �θ� ������Ʈ

    private void Start() {
        CreateObject();
    }

    private void CreateObject() { // ������Ʈ�� �����ϴ� ��� -> Pool�� ä��� ���
        for(int i = 0; i < 30; i++) {
            GameObject obj = Instantiate(objPrefab, parent); // ������Ʈ�� �����ϰ�, ���������� parent�� �ڽ����� ����
            EnqueueObject(obj);
        }
    }

    // �����͸� �ִ� ���
    public void EnqueueObject(GameObject newObj) {
        newObj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        newObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        objQueue.Enqueue(newObj);
        newObj.SetActive(false);
    }

    // �����͸� �������� ���
    public GameObject DequeueObject() {
        // ������ �����ϴٸ� �߰��� ����
        if (objQueue.Count < 10) CreateObject();

        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);
        return obj;
    }
}
