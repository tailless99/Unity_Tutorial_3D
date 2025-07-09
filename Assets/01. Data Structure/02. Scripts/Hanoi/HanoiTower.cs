using System.Collections;
using Unity.Android.Gradle;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3, }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars; // L,C,B

    public static GameObject selectedDonut;
    public static bool isSelected;

    IEnumerator Start() {
        for(int i = (int)hanoiLevel - 1; i >= 0; i--) {
            GameObject donut = Instantiate(donutPrefabs[i]);
            donut.transform.position = new Vector3(-5f, .2f, 0);

            bars[0].PushDonut(donut);

            yield return new WaitForSeconds(.5f);
        }
    }

}
