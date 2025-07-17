using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    private Rigidbody rb;

    public float speed = 5f;
    private Vector3 dir;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        int ranValue = Random.Range(0,10);

        if (ranValue < 3) { // 30%
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else { // 70%
            dir = Vector3.down;
        }
    }

    private void Update() {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        // 점수 증가
        ScoreManager.Instance.Score++;

        var explosion = Instantiate(explosionEffect);
        explosion.transform.position = transform.position;

        if (collision.gameObject.name.Contains("Bullet")) {
            var player = PlayerFire.Instance;
            //player.bulletObjectPool.Add(collision.gameObject);
            player.bulletObjectPool.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        else {
            Destroy(collision.gameObject);
        }
        //EnemyManager.Instance.enemyPool.Add(this.gameObject);
        EnemyManager.Instance.enemyPool.Enqueue(this.gameObject);
        this.gameObject.SetActive(false);
    }

    private void OnDisable() {
        rb.linearVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}
