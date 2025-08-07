using UnityEngine;

namespace Pattern.Factory {
    public abstract class Monster : MonoBehaviour {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Attack { get; protected set; }

        protected virtual void Initialize(string name, int health, int attack) {
            this.Name = name;
            this.Health = health;
            this.Attack = attack;
            Debug.Log($"생성 : 이름 - {name} / 체력 - {health} / 공격력 - {attack}");
        }
    }
}