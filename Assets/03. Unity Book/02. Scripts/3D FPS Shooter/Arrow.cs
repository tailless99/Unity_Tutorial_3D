using UnityEngine;

public class Arrow : MonoBehaviour {
    public float moveSpeed = 100f;
    public bool isMove = true;

    private void Update() {
        if (isMove)
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        var closetPos = other.ClosestPoint(transform.position);

        transform.position = closetPos;
        this.transform.SetParent(other.transform);
        isMove = false;
    }
}
