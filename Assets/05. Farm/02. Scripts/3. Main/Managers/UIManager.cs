using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject outSideUI;
    [SerializeField] private GameObject fieldUI;
    [SerializeField] private GameObject houseUI;
    [SerializeField] private GameObject animalUI;
    [SerializeField] private GameObject seedUI;
    [SerializeField] private GameObject InventoryUI;

    [SerializeField] private Button seedBtn;
    [SerializeField] private Button harvestBtn;
    [SerializeField] private Button[] plantButtons;


    private void Awake() {
        seedBtn.onClick.AddListener(OnSeedButton);
        harvestBtn.onClick.AddListener(OnHarvestButton);

        for(int i = 0; i < plantButtons.Length; i++) {
            int j = i; // 클로저 이슈 방지
            plantButtons[i].onClick.AddListener(() => GameManager.Instance.field.SetPlants(j));
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    private void OnSeedButton() {
        GameManager.Instance.field.SetState(FieldManager.FieldState.Seed);
        seedUI.SetActive(true);
    }

    private void OnHarvestButton() {
        GameManager.Instance.field.SetState(FieldManager.FieldState.Harvest);
        seedUI.SetActive(false);
    }

    public void ActivateFieldUI(bool isActive) {
        fieldUI.SetActive(isActive);
    }
}
