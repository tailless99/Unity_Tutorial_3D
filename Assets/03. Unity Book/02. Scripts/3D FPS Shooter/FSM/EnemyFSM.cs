using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour {
    private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die }
    private EnemyState m_State;
    
    public Slider hpSlider;
    public float findDistance = 8f;
    public float attackDistance = 3f;
    public float moveDistance = 20f;
    public float moveSpeed = 5f;
    public int attackPower = 3;
    public int hp = 15;

    private CharacterController cc;
    private Transform player;
    private Animator animator;

    private float currentCoolTime = 0f;
    private float attackDelay = 2f;
    private int maxHp = 15;
    private Vector3 originPos;
    private Quaternion originRot;


    private void Start() {
        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        originRot = transform.rotation;
        animator = transform.GetComponentInChildren<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        switch (m_State) {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }

        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Idle() {
        if (Vector3.Distance(transform.position, player.position) < findDistance) {
            m_State = EnemyState.Move;
            animator.SetTrigger("IdleToMove");
        }
    }

    private void Move() {
        // 정찰 이동
        if (Vector3.Distance(transform.position, originPos) > moveDistance) {
            m_State = EnemyState.Return;
        }
        // 추적 이동
        // 타겟이 공격 가능 거리보다 먼 경우 -> 이동
        else if (Vector3.Distance(transform.position, player.position) > attackDistance) {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        // 타겟이 공격 가능 거리보다 가까운 경우 -> 공격으로 상태 전환
        else {
            currentCoolTime = attackDelay;
            animator.SetTrigger("MoveToAttackDelay");
            m_State = EnemyState.Attack;
        }
    }

    private void Attack() {
        // 공격 범위 내에 있는 경우 -> 공격 실행
        if (Vector3.Distance(transform.position, player.position) < attackDistance) {
            currentCoolTime += Time.deltaTime;
            if(currentCoolTime > attackDelay) {
                currentCoolTime = 0f;
                animator.SetTrigger("StartAttack");
            }
        }
        // 공격 범위 밖에 있을 경우 -> 이동으로 전환
        else {
            currentCoolTime = 0;
            animator.SetTrigger("AttackToMove");
            m_State = EnemyState.Move;
        }
    }

    public void AttackAction() {
        player.GetComponent<FPSPlayerMove>().DamageAction(attackPower);
    }

    // 정찰
    private void Return() {
        // 원래 있던 곳으로 복귀
        if(Vector3.Distance(transform.position, originPos) > .1f){
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        else {
            transform.position = originPos;
            transform.rotation = originRot;
            hp = 15;
            animator.SetTrigger("MoveToIdle");
            m_State = EnemyState.Idle;
        }
    }

    public void HitEnemy(int hitPower) {
        // 연속 피격 방지
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return) return;
        hp -= hitPower;

        if(hp > 0) {
            animator.SetTrigger("Damaged");
            m_State = EnemyState.Damaged;
            Damaged();
        }
        else {
            animator.SetTrigger("Die");
            m_State = EnemyState.Die;
            Die();
        }
    }

    private void Damaged() {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess() {
        yield return new WaitForSeconds(1f);
        m_State = EnemyState.Move;

    }

    private void Die() {
        StopAllCoroutines();
        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess() {
        cc.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
