using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePos;

    public int poolSize = 10;
    //public List<GameObject> bulletObjectPool;
    public Queue<GameObject> bulletObjectPool;

    private void Start() {
        //bulletObjectPool = new List<GameObject>();
        bulletObjectPool = new Queue<GameObject>();

        for(int i = 0; i < poolSize; i++) {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Enqueue(bullet);
            bullet.SetActive(false);
        }
    }

    private void Update() {
// 전처리 문
#if UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1")) {
            if (bulletObjectPool.Count > 0) {
                var bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePos.transform.position;
            }

            // 리스트 방식
            /*if (bulletObjectPool.Count > 0) {
                var bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bullet.transform.position = firePos.transform.position;
                bulletObjectPool.Remove(bullet);
            }*/

            // 배열방식
            /*for(int i = 0; i < poolSize; i++) {
                GameObject bullet = bulletObjectPool[i];

                // 선택한 총알이 비활성화 상태인지 확인
                if (!bullet.activeSelf) {
                    bullet.SetActive(true);
                    bullet.transform.position = firePos.transform.position;
                    break;
                }
            }*/
        }
#endif
    }
}
