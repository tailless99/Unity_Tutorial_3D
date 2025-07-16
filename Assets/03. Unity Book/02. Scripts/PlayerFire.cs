using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePos;

    private void Start() {
        //bulletFactory = Resources.Load<GameObject>("Bullet"); // 리소스 폴더에서 총알 프리팹 로드
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            var bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePos.transform.position; // 위치 초기화
            //bullet.transform.rotation = firePos.transform.rotation; // 회전 초기화

            // 위치와 회전을 함번에 적용하는 기능
            //bullet.transform.SetPositionAndRotation(firePos.transform.position, firePos.transform.rotation);
            // 부모 오브젝트 설정
            //bullet.transform.SetParent(부모); 
        }
    }
}
