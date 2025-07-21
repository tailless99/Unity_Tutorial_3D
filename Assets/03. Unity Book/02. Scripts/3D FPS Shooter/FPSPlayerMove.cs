using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerMove : MonoBehaviour {

    public Slider hpSlider;
    public GameObject hitEffect;

    public float moveSpeed = 7f;
    public float jumpPower = 10f;
    public float hp = 20f;
    public bool isJumping = false;

    private CharacterController cc;
    
    private float gravity = -20f;
    private float yVelocity = 0f;
    private int maxHp = 20;

    void Start() {
        cc = GetComponent<CharacterController>();
    }

    void Update() {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 크기와 방향이 있는 벡터
        dir = dir.normalized; // 방향만 있는 벡터

        // 카메라의 Transform 기준으로 변환
        dir = Camera.main.transform.TransformDirection(dir);

        // 중력 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); // 캐릭터 컨트롤러에 내장된 이동 기능

        if (cc.collisionFlags == CollisionFlags.Below) { // 아래쪽에 뭔가 닿은 상태일 때
            if (isJumping) {
                isJumping = false;
            }
            yVelocity = 0f;
        }

        // 점프 기능
        if (Input.GetButtonDown("Jump") && !isJumping) {
            isJumping = true;
            yVelocity = jumpPower;
        }
    }

    public void DamageAction(int damage) {
        hp -= damage;
        hpSlider.value = (float)hp / (float)maxHp;

        if(hp > 0) {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect() {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(.3f);
        hitEffect.SetActive(false);
    }
}
