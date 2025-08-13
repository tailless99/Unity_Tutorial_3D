using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private enum PlantState { Level1, Level2, Level3 }
    private PlantState plantState;

    private DateTime startTime, growTime, harvestTime;

    public int plantIndex; // 식물 넘버
    public bool isHarvest = false;

    private void Awake() {
        startTime = DateTime.Now;
        growTime = startTime.AddSeconds(5);
        harvestTime = startTime.AddSeconds(10);

        // DateTime.Now : 현재 시간을 활용한 방법
        // Time.time : 게임 실행 시간
        // Time.deltTime : 시간 조각
    }

    void OnEnable() {
        WeatherSystem.weatherAction += SetGrowth;
    }

    void OnDisable() {
        WeatherSystem.weatherAction -= SetGrowth;
    }

    private IEnumerator Start() {
        SetState(PlantState.Level1);

        while(plantState != PlantState.Level3) {
            if(DateTime.Now >= harvestTime) {
                SetState(PlantState.Level3);
                isHarvest = true;
            }
            else if (DateTime.Now >= growTime) {
                SetState(PlantState.Level2);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void SetState(PlantState newState) {
        if (plantState != newState || plantState == PlantState.Level1) {

            for (int i = 0; i < 3; i++) {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            transform.GetChild((int)newState).gameObject.SetActive(true);
        }
    }

    private void SetGrowth(WeatherSystem.WeatherType weatherType) {
        switch (weatherType) {
            case WeatherSystem.WeatherType.Sun:
                break;
            case WeatherSystem.WeatherType.Rain:
                break;
            case WeatherSystem.WeatherType.Snow:
                break;
        }
    }
}
