using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager> {
    public int poolSize = 30;
    //public List<GameObject> enemyPool;
    public Queue<GameObject> enemyPool;
    public Transform[] spawnPoints;

    private float currentTime;      // 타이머

    private float minTime = .1f;
    private float maxTime = 1f;

    public float createTime = 1f;   // 생성 주기

    public GameObject enemyFactory;

    private void Start() {
        createTime = Random.Range(minTime, maxTime);

        //enemyPool = new List<GameObject>();
        enemyPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++) {
            var enemy = Instantiate(enemyFactory);
            enemy.SetActive(false);
            //enemyPool.Add(enemy);
            enemyPool.Enqueue(enemy);
        }
    }

    private void Update() {
        currentTime += Time.deltaTime;

        // 타이머가 생성 주기를 넘었다면
        if (currentTime > createTime) {
            // 큐
            if (enemyPool.Count > 0) {
                // 타이머 초기화
                currentTime = 0;
                createTime = Random.Range(minTime, maxTime);

                var ranIndex = Random.Range(0, spawnPoints.Length);
                
                var enemy = enemyPool.Dequeue();
                enemy.SetActive(true);
                enemy.transform.position = spawnPoints[ranIndex].transform.position;
            }

            // 리스트 방식
            /*
             * if (enemyPool.Count > 0) {
                // 타이머 초기화
                currentTime = 0;
                createTime = Random.Range(minTime, maxTime);

                var ranIndex = Random.Range(0, spawnPoints.Length);
                var enemy = enemyPool[0];

                enemy.SetActive(true);
                enemy.transform.position = spawnPoints[ranIndex].transform.position;

                enemyPool.Remove(enemy);
            }
            */
        }
    }
}
