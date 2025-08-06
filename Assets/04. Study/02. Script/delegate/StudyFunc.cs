using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    public enum Buff { A, B, C }
    public Buff buff;

    public Buff currentBuff;
    public float currentDmg;

    // 접근 제한자 Func<매개변수, 매개변수, 반환 타입> 변수명
    public Func<Buff, float, float> myFunc;

    // 다양하게 인수 수정 가능
    //public Func<int, int, int> myFunc;
    //public Func<int, int> myFunc2;
    //public Func<int, int, float, string, bool, string> myFunc3;
    //public Func<int> myFunc4;

    private void Start() {
        myFunc += CalculationDamge;
        myFunc?.Invoke(currentBuff, currentDmg);
    }

    private float CalculationDamge(Buff buff, float dmg) {
        int result = 0;

        switch (buff) {
            case Buff.A:
                result = 10;
                break;
            case Buff.B:
                result = 10;
                break;
            case Buff.C:
                result = 10;
                break;
        }

        return dmg * result;
    }
}
