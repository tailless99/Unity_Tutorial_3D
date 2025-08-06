using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    public Predicate<int> myProdicate;

    // 매개변수 1개만 사용 가능
    public int level = 10;

    private void Start() {
        myProdicate = n => n <= 10;
        string msg = myProdicate(level) ? "초보자 사냥터 입장 가능" : "초보자 사냥터 입장 불가";
        Debug.Log(msg);
    }
}
