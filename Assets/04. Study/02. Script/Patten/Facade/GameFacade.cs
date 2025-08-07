using Unity.VisualScripting;
using UnityEngine;

public class GameFacade : Singleton<GameFacade>
{
    private InventorySystem inventorySystem;
    private QuestSystem questSystem;
    private SoundSystem soundSystem;

    private void Awake() {
        inventorySystem = GetComponent<InventorySystem>();
        questSystem = GetComponent<QuestSystem>();
        soundSystem = GetComponent<SoundSystem>();

        if(inventorySystem == null) {
            inventorySystem = transform.AddComponent<InventorySystem>();
        }

        if (questSystem == null) {
            questSystem = transform.AddComponent<QuestSystem>();
        }

        if (soundSystem == null) {
            soundSystem = transform.AddComponent<SoundSystem>();
        }
    }

    public void ItemEvent(int index, string itemName) {
        if(index == 0) {
            inventorySystem.AddItem(itemName);
        }
        else if (index == 0) {
            inventorySystem.AddItem(itemName);
        }
        else if (index == 0) {
            inventorySystem.AddItem(itemName);
        }
    }

    public void QuestEvent(int index, string itemName) {
        if (index == 0) {
            inventorySystem.AddItem(itemName);
        }
        else if (index == 0) {
            inventorySystem.AddItem(itemName);
        }
        else if (index == 0) {
            inventorySystem.AddItem(itemName);
        }
    }

    public void SoundEvent(int index, string itemName) {
        if (index == 0) {
            inventorySystem.AddItem(itemName);
        }
        else if (index == 0) {
            inventorySystem.AddItem(itemName);
        }
        else if (index == 0) {
            inventorySystem.AddItem(itemName);
        }
    }
}
