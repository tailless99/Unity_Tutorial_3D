using UnityEngine;

public class AttackDecorator : IAttack {
    protected IAttack attack;
    
    public AttackDecorator(IAttack attack) {
        this.attack = attack;
    }

    public virtual void Excute() {
        attack.Excute();
    }
}
