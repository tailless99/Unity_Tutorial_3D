using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime;      // 타이머

    private float minTime = 1;
    private float maxTime = 5;

    public float createTime = 1f;   // 생성 주기

    public GameObject enemyFactory;

    private void Start() {
        createTime = Random.Range(minTime, maxTime);
    }

    private void Update() {
        currentTime += Time.deltaTime;

        // 타이머가 생성 주기를 넘었다면
        if (currentTime > createTime) {
            // 생성
            var enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;

            // 타이머 초기화
            currentTime = 0;
        }
    }
}
