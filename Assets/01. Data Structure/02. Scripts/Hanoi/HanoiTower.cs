using System.Collections;
using TMPro;
using Unity.Android.Gradle;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3, }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars; // L,C,B
    public TextMeshProUGUI countTextUI;

    public static GameObject selectedDonut;
    public static bool isSelected;
    public static BoardBar currBar;
    public static int moveCount;


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
}
