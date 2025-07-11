using System.Collections;
using TMPro;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.UI;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3, }
    public HanoiLevel hanoiLevel = HanoiLevel.Lv1;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars; // L,C,B
    
    public TextMeshProUGUI countTextUI;
    public Button answerButton;

    public static GameObject selectedDonut;
    public static bool isSelected;
    public static BoardBar currBar;
    public static int moveCount;


    void Awake() {
        answerButton.onClick.AddListener(HanoiAnswer);
    }

    IEnumerator Start() {
        countTextUI.text = moveCount.ToString();

        for (int i = (int)hanoiLevel - 1; i >= 0; i--) {
            GameObject donut = Instantiate(donutPrefabs[i]);
            donut.transform.position = new Vector3(-5f, .2f, 0);

            bars[0].PushDonut(donut);
            moveCount = 0;

            yield return new WaitForSeconds(.5f);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            currBar.barStack.Push(selectedDonut);
            isSelected = false;
            selectedDonut = null;
        }
        countTextUI.text = moveCount.ToString();
    }

    public void HanoiAnswer() {
        HanoiRoutine((int)hanoiLevel, 0, 1, 2);
    }

    private void HanoiRoutine(int n, int from, int temp, int to) {
        // 도넛을 다 옮긴 상태
        if (n == 0) return;

        if(n == 1) {
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");
        }
        else {
            HanoiRoutine(n-1, from, to, temp);
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");

            HanoiRoutine(n - 1, temp, from, to);
        }
    }
}
