using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    private void OnCollisionEnter(Collision collision) { // 수류탄이 무언가와 충돌할 경우
        var eff = Instantiate(bombEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
