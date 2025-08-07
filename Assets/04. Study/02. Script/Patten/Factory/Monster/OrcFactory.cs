using Pattern.Factory;
using UnityEngine;

public class OrcFactory : MonsterFactory {
    public override Monster CreateMonster(string type) {
        switch (type) {
            case "Normal":
                return new GameObject("Goblin").AddComponent<Orc>();
                break;
            case "Warrior":
                return new GameObject("Goblin").AddComponent<OrcWarrior>();
                break;
            case "Archer":
                return new GameObject("Goblin").AddComponent<OrcArcher>();
                break;
            default:
                Debug.LogError($"Unknown Monster Type : {type}");
                break;
        }
        return null;
    }
}
