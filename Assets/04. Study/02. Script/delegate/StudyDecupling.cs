using Unity.Android.Types;
using UnityEngine;



public class StudyDecupling : MonoBehaviour
{
    public class Player {
        public void AttackEnemy(IDamageable target, float damage) {
            target.TakeDamage(10);
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
