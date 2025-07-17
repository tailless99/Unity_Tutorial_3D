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
// ��ó�� ��
#if UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1")) {
            if (bulletObjectPool.Count > 0) {
                var bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePos.transform.position;
            }

            // ����Ʈ ���
            /*if (bulletObjectPool.Count > 0) {
                var bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bullet.transform.position = firePos.transform.position;
                bulletObjectPool.Remove(bullet);
            }*/

            // �迭���
            /*for(int i = 0; i < poolSize; i++) {
                GameObject bullet = bulletObjectPool[i];

                // ������ �Ѿ��� ��Ȱ��ȭ �������� Ȯ��
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
