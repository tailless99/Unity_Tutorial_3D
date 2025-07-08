using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // ���ϴ� Ÿ�ֿ̹� ���� ȿ��
    private IEnumerator Start() {
        yield return new WaitForSeconds(bombTime);
        BombForce();
    }

    private void BombForce() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

        foreach(var collider in colliders) {
            Rigidbody colliderRb = collider.GetComponent<Rigidbody>();

            colliderRb.AddExplosionForce(1000f, transform.position, bombRange, 1f);
        }

        Destroy(gameObject);
    }
}
