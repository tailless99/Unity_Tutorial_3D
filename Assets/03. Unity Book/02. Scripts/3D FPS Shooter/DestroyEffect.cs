using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 2f;
    private float currentTime = 0f;

    private void Update() {
        currentTime += Time.deltaTime;

        if(currentTime > destroyTime) {
            Destroy(gameObject);
        }
    }
}
