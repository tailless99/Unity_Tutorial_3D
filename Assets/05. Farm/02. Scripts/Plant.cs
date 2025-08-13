using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private enum PlantState { Level1, Level2, Level3 }
    private PlantState plantState;

    private DateTime startTime, growTime, harvestTime;

    private bool isHarvest = false;

    private void Awake() {
        startTime = DateTime.Now;
        growTime = startTime.AddSeconds(5);
        harvestTime = startTime.AddSeconds(10);

        // DateTime.Now : 현재 시간을 활용한 방법
        // Time.time : 게임 실행 시간
        // Time.deltTime : 시간 조각
    }

    private void Start() {
        SetState(PlantState.Level1);
    }

    private void SetState(PlantState newState) {
        if (plantState != newState)
            plantState = newState;

        for (int i = 0; i < 3; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild((int)newState).gameObject.SetActive(true);
    }
}
