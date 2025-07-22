using UnityEngine;

public class FPSPlayerFire : MonoBehaviour {
    public GameObject firePosition;
    public GameObject bombFactory;

    public int weaponPower = 5;
    public float throwPower = 15f;

    public GameObject bulletEffect;
    private ParticleSystem ps;
    private Animator animator;

    private void Start() {
        ps = bulletEffect.GetComponent<ParticleSystem>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run) return;

        if (Input.GetMouseButtonDown(0)) { // 마우스 왼쪽 버튼 클릭
            if(animator.GetFloat("MoveMotion") == 0) {
                animator.SetTrigger("Attack");
            }

            var ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            var hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo)) {
                // 레이캐스트를 몬스터가 맞은 경우
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                    var eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                // 레이캐스트를 맞은 대상이 몬스터가 아닌 경우
                else {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play();
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) { // 마우스 오른쪽 버튼 클릭
            var bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            var rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}
