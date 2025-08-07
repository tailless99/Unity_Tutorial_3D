using UnityEngine;

public class SaveService : MonoBehaviour, ISaveService {
    public void LoadData() {
        Debug.Log("LoadData");
    }

    public void SaveDate() {
        Debug.Log("SaveDate");
    }
}
