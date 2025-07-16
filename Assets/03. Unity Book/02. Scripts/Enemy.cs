using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    public float speed = 5f;
    private Vector3 dir;

    private void Start() {
        int ranValue = Random.Range(0,10);

        if(ranValue < 3) { // 30%
            GameObject target = GameObject.Find("Player");
            dir = (target.transform.position - transform.position).normalized;
        }
        else { // 70%
            dir = Vector3.down;
        }
    }

    private void Update() {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        // 점수 추가
        var score = sm.GetScore() + 1;
        sm.SetScore(score);

        var explosion = Instantiate(explosionEffect);
        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
