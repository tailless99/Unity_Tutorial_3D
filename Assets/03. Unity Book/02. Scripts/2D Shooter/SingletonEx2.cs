using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance {
        get;            // ���� ����
        private set;    // ���� �Ұ�
    }

    private void Awake() {
        if(Instance == null) { // Instance�� ��������� �ڽ��� �Ҵ�
            Instance = this;
        }
        else { // �̹� Instance�� �Ҵ�Ǿ��µ� �� ��û�Ѵٸ� �ش� ��ü �ı�
            Destroy(gameObject);
        }
    }
}
