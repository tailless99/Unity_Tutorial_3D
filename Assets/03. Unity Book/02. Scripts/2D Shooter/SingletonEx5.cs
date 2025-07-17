using Unity.VisualScripting;
using UnityEngine;

public class SingletonEx5 : MonoBehaviour
{
    private static SingletonEx5 instance;
    public static SingletonEx5 Instance {
        get {
            if (instance == null) {
                var obj = FindFirstObjectByType<SingletonEx5>(); // 찾아보는 기능

                // 찾은 경우
                if(obj != null) {
                    instance = obj;
                }
                // 못 찾은 경우
                else {
                    var newObj = new GameObject("Singleton"); // Singleton이라는 오브젝트 생성
                    newObj.AddComponent<SingletonEx5>();

                    instance = newObj.GetComponent<SingletonEx5>();
                }
            }
            return instance;
        }
    }

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
