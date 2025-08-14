using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeatherSystem : MonoBehaviour
{
    public enum WeatherType { Sun, Rain, Snow }
    public WeatherType weatherType;

    public static event Action<WeatherType> weatherAction;

    [SerializeField] private GameObject[] weatherParticles;

    private IEnumerator Start() {
        while (true) {
            // 15초 주기
            yield return new WaitForSeconds(15f);

            int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;

            int ranIndex = Random.Range(0, weatherCount);
            weatherType = (WeatherType)ranIndex;

            foreach (var particle in weatherParticles)
                particle.SetActive(false);

            weatherParticles[ranIndex].SetActive(true);
            
            // 날씨가 바뀜에 따라 식물 성장 달라지거나, 그런 이벤트
            weatherAction?.Invoke(weatherType);
        }
    }
}
