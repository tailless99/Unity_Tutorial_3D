using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime;      // Ÿ�̸�

    private float minTime = 1;
    private float maxTime = 5;

    public float createTime = 1f;   // ���� �ֱ�

    public GameObject enemyFactory;

    private void Start() {
        createTime = Random.Range(minTime, maxTime);
    }

    private void Update() {
        currentTime += Time.deltaTime;

        // Ÿ�̸Ӱ� ���� �ֱ⸦ �Ѿ��ٸ�
        if (currentTime > createTime) {
            // ����
            var enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;

            // Ÿ�̸� �ʱ�ȭ
            currentTime = 0;
        }
    }
}
