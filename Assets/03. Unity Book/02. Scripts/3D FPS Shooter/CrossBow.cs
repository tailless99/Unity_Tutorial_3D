using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CrossBow : MonoBehaviour {
    /// 화살을 발사하는 기능
    /// - 화살이 날아가는 기능

    public GameObject arrowPrefabs;
    public Transform shootPos;
    public bool isShoot;



    /// 누군가를 감지하는 기능
    /// - 진선상으로 감지
    /// - 감지했을 때 화살을 생성
    /// - 생성한 화살이 날아감
    private void Update() {
        var ray = new Ray(transform.position, transform.forward); ;
        RaycastHit hit; // 레이저 닿은 대상

        if(Physics.Raycast(ray, out hit)) {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine() {
        isShoot = true;
        var arrow = Instantiate(arrowPrefabs, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90f, 0, 0));
        arrow.transform.SetPositionAndRotation(shootPos.position, rot);

        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward * 100f);
    }
}