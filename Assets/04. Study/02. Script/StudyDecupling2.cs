using UnityEngine;

public interface IDamageable {
    void TakeDamage(float damage);
}

public class StudyDecupling2 : MonoBehaviour {
    public class Player {
        public void AttackEnemy(IDamageable target, float damage) {
            target.TakeDamage(damage);
        }
    }

    public class Enemy {
        public float health = 10;

        public void TakeDamage(float damage) {
            health -= damage;
            Debug.Log("damage 만큼 공격 받음");
        }
    }
}