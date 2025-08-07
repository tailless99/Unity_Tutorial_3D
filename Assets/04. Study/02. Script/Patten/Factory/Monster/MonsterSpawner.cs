using Pattern.Factory;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
    private MonsterFactory currentFactory = null;
    private Monster currentMonster = null;

    private GoblinFactory goblinFactory;
    private OrcFactory orcFactory;

    private void Awake() {
        goblinFactory = new GameObject("GoblinFactory").AddComponent<GoblinFactory>();
        orcFactory = new GameObject("OrcFactory").AddComponent<OrcFactory>();

    }

    private void Start() {
        currentFactory = goblinFactory;
        currentMonster = currentFactory.CreateMonster("Normal");
        currentMonster = currentFactory.CreateMonster("Warrior");
        currentMonster = currentFactory.CreateMonster("Archer");

        currentFactory = orcFactory;
        currentMonster = currentFactory.CreateMonster("Normal");
        currentMonster = currentFactory.CreateMonster("Warrior");
        currentMonster = currentFactory.CreateMonster("Archer");
    }
}
