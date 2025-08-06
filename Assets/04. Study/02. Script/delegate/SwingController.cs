using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SwingController : MonoBehaviour {
    private Animator animator;
    private bool isSwing;

    public Action onStartSwing;
    public Action onEndSwing;

    private void Awake() {
        animator = GetComponent<Animator>();

        onStartSwing += SwingStart;
        onEndSwing += SwingEnd;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!isSwing) {
                StartCoroutine(SwingRoutine(onStartSwing, onEndSwing));
            }
        }
    }

    IEnumerator SwingRoutine(Action action1, Action action2) {
        // 애니메이션 시작
        animator.SetTrigger("Swing");
        action1?.Invoke();

        float animLength = animator.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(animLength);

        // 애니메이션 종료
        action2?.Invoke();
    }

    private void SwingStart() {
        isSwing = true;
        Debug.Log("스윙 시작");
    }

    private void SwingEnd() {
        isSwing = false;
        Debug.Log("스윙 종료");
    }
}
