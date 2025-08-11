using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour {
    [SerializeField] private Transform centerPivot;

    [SerializeField] private Animator[] characterAnims;

    [SerializeField] Button[] turnButtons;
    [SerializeField] Button selectButton;

    private int currentIndex;
    private bool isTurn;

    private void Start() {
        turnButtons[0].onClick.AddListener(() => Turn(true));
        turnButtons[1].onClick.AddListener(() => Turn(false));

        selectButton.onClick.AddListener(() => Select());
    }

    public void Turn(bool isLeft) {
        if (!isTurn) {
            var value = isLeft ? -1 : 1;
            currentIndex += value;

            if (currentIndex < 0) currentIndex = 3;
            else if (currentIndex > 3) currentIndex = 0;

            var turnValue = value * 90;
            var targetRot = centerPivot.rotation * Quaternion.Euler(0, turnValue, 0);

            isTurn = true;
            StartCoroutine(TurnRoutine(targetRot));
        }
    }

    IEnumerator TurnRoutine(Quaternion targetRot) {
        while (true) {
            yield return null; // while true문 사용시 무조건 안에 yield retrun이 필요함

            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, 10f * Time.deltaTime);

            Debug.Log("Turn");

            var angle = Quaternion.Angle(centerPivot.rotation, targetRot);
            if (angle <= 0.1f) {
                isTurn = false;
                centerPivot.rotation = targetRot;
                yield break;
            }
        }
    }

    public void Select() {
        Debug.Log($"현재 선택한 캐릭터는 {currentIndex}번째 캐릭터입니다.");
        StartCoroutine(TurnRoutine());
    }

    IEnumerator TurnRoutine() {
        characterAnims[currentIndex].SetTrigger("Selected");
        
        yield return new WaitForSeconds(3f);
        Fade.onFadeAction?.Invoke(3f, Color.white, true, null);
        yield return new WaitForSeconds(3.5f);
    }
}
