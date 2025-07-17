using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance {
        get;            // 접근 가능
        private set;    // 수정 불가
    }

    private void Awake() {
        if(Instance == null) { // Instance가 비어있으면 자신을 할당
            Instance = this;
        }
        else { // 이미 Instance가 할당되었는데 또 요청한다면 해당 객체 파괴
            Destroy(gameObject);
        }
    }
}
