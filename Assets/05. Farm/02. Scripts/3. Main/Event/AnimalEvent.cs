using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject followTarget;

    private BoxCollider boxCollider;

    public static Action failAction;

    private float timer;
    private bool isTimer;

    private void Start() {
        boxCollider = GetComponent<BoxCollider>();
        failAction += SetRandomPosition;
    }

    private void Update() {
        if (!isTimer)
            return;

        timer += Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTimer = true;
            SetRandomPosition();

            followTarget.SetActive(true);
            GameManager.Instance.SetCameraState(CameraState.Animal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"깃발 찾는데 걸린 시간은 {timer:F1}초 입니다.");
            isTimer = false;
            timer = 0f;

            SetFlag(Vector3.zero, false);
            GameManager.Instance.SetCameraState(CameraState.Outside);

            followTarget.SetActive(true);
        }
    }

    private void SetRandomPosition() {
        float randomX = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float randomY = Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y);

        var randomPos = new Vector3(randomX, 0, randomY);
        
        SetFlag(randomPos, true);
    }

    private void SetFlag(Vector3 pos, bool isActive) {
        flag.transform.SetParent(transform);
        flag.transform.position = pos;
        flag.SetActive(isActive);
    }
}