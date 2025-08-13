using System;
using UnityEngine;

public class Crop : MonoBehaviour {
    [SerializeField] private string cropName;
    public Sprite icon;
    public Action useAction;

    private void Start() {
        useAction += Use;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Collider>().CompareTag("Player")) {
            Get(); // 획득 로직
        }
    }

    // 인벤토리에 작물 추가
    public void Get() {
        if (GameManager.Instance.item.CheckItemCount()) {
            GameManager.Instance.item.GetItem(this);
            gameObject.SetActive(false);
        }
        else {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
    }

    // 체력이나 스테미너 회복
    // 인벤토리에서 버튼 눌렀을 때 실행되는 기능
    public void Use() {

    }
}
