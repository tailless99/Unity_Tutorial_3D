using System.Collections.Generic;
using UnityEngine;

public class StudyObjectPool : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>(); // 오브젝트가 들어갈 풀
    public GameObject objPrefab; // 생성될 오브젝트

    public int poolSize = 100;

    private void Start() {
        for(int i = 0; i < poolSize; i++) {
            GameObject newObj = Instantiate(objPrefab, transform);
            EnqueueObejct(newObj);
        }
    }

    private void CreateObject() {
        for(int i = 0; i < poolSize; i++) {
            GameObject newObj = Instantiate(objPrefab, transform);
            EnqueueObejct(newObj);
        }
    }

    // 오브젝트를 넣는 기능
    public void EnqueueObejct(GameObject obj) {
        objQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    // 오브젝트를 뽑는 기능
    public GameObject DequeueObject() {
        GameObject obj = objQueue.Dequeue();
        return obj;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (objQueue.Count < 10)
                CreateObject();

            GameObject obj = DequeueObject(); // 풀에서 오브젝트 뽑아오기
            obj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        }
    }
}
