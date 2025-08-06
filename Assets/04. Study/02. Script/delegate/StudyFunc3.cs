using System;
using UnityEngine;

public class StudyFunc3 : MonoBehaviour
{
    public float hp = 100;
    public Func<float> GetHp;
    public Func<float, float> GetRemainHP;
    public Func<string> GetAction;

    private void Start() {
        GetHp = () => hp;
        GetRemainHP = (dmg) => hp - dmg;

        GetAction = () => {
            if (GetHp() > 50)
                return "°ø°Ý";
            else if (GetHp() > 20)
                return "°ø°Ý";
            else if (GetHp() > 0)
                return "µµ¸Á";
            else
                return "Á×À½";
        };
    }
}
